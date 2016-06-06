/* Panstamp master sketch */
/* Author: Panagiotis Mylonas
 * Date: 6/6/2016
 */

/* Caveats: PIN10 MUST BE OUTPUT! */

/* Headers */
#include "HardwareSerial.h"
#include <SPI.h>

/* Type Definitions */
typedef union imu_packet
{
  float f;
  uint8_t b[4]; // float is 4-bytes on the Arduino platform.
}imu_packet_t;

/* Constants */
const uint8_t PanstampSlavePin = 10; 
const uint32_t transSpeed = 2000000; // panstamp core clock is 8MHz. SPI clock divisor is set to 4 (default).

/* Globals */
imu_packet_t impack;
float yaw, pitch, roll;

/* Function Prototypes */
uint8_t SPI_transferWithDelay(const uint8_t _byte);

void setup() {
  Serial.begin(9600); // Used for debugging
  // Set the Slave Select Pin as Output
  pinMode(PanstampSlavePin, OUTPUT);
  //digitalWrite(PanstampSlavePin, HIGH);  // ensure SS stays high for now
  // Init SPI
  SPI.begin();
}

void loop() {
  /* Begin transmission */
  SPI.beginTransaction(SPISettings(transSpeed, MSBFIRST, SPI_MODE0));
  digitalWrite(PanstampSlavePin, LOW);
  
  /* Receive yaw */
  
  // Send to slave panstamp, request for Yaw.
  SPI_transferWithDelay('Y');
  impack.b[0] = SPI_transferWithDelay('1'); // reading byte0 (response from previous transfer). Initiate request for next byte.   
  impack.b[1] = SPI_transferWithDelay('2'); // reading byte1
  impack.b[2] = SPI_transferWithDelay('3'); // reading byte2
  impack.b[3] = SPI_transferWithDelay(0); //  reading byte 3. Used to indicate termination of packet.
  yaw = impack.f;
  

  /* Receive pitch */

  // Send to slave panstamp, request for Pitch.
  SPI_transferWithDelay('P');
  impack.b[0] = SPI_transferWithDelay('1'); // reading byte0 (response from previous transfer). Initiate request for next byte.   
  impack.b[1] = SPI_transferWithDelay('2'); // reading byte1
  impack.b[2] = SPI_transferWithDelay('3'); // reading byte2
  impack.b[3] = SPI_transferWithDelay(0); //  reading byte 3. Used to indicate termination of packet.
  pitch = impack.f;
  
  /* Receive roll */

  // Send to slave panstamp, request for Roll.
  SPI_transferWithDelay('R');
  impack.b[0] = SPI_transferWithDelay('1'); // reading byte0 (response from previous transfer). Initiate request for next byte.   
  impack.b[1] = SPI_transferWithDelay('2'); // reading byte1
  impack.b[2] = SPI_transferWithDelay('3'); // reading byte2
  impack.b[3] = SPI_transferWithDelay(0); //  reading byte3. Used to indicate termination of packet.
  roll = impack.f;
  
  /* End transmission */
  digitalWrite(PanstampSlavePin, HIGH);
  SPI.endTransaction();

  /* Output imu packet to serial */
  Serial.print("Yaw: ");
  Serial.print(yaw);
  Serial.print(" Pitch: ");
  Serial.print(pitch);
  Serial.print(" Roll: ");
  Serial.println(roll);
  // Use proper delay.
  delay(100);
}

/* Functions */
uint8_t SPI_transferWithDelay(const uint8_t _byte)
{
  uint8_t b = SPI.transfer (_byte);
  delayMicroseconds (10);
  return b;
} 

