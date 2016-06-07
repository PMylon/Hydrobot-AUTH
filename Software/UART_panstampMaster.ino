/* Panstamp UART master sketch */
/* Author: Panagiotis Mylonas
 * Date: 6/6/2016
 */

/* Headers */
#include "HardwareSerial.h"

/* Type Definitions */
typedef union imu_packet
{
  float f;
  uint8_t b[4]; // float is 4-bytes on the Arduino platform.
}imu_packet_t;

/* Constants */

/* Globals */
imu_packet_t impack;
float yaw, pitch, roll;

void setup() {
  Serial.begin(9600); 
}

void loop() {
    
  // Send to slave panstamp, request for Yaw, Pitch, Roll (Orientation).
  Serial.write('O');
  while (Serial.available() < 12); // 4bytes per euler angle
  Serial.readBytes(impack.b, 4); 
  yaw = impack.f;
  Serial.readBytes(impack.b, 4);
  pitch = impack.f;
  Serial.readBytes(impack.b, 4);
  roll = impack.f;
 
  /* Output imu packet to serial */
  Serial.print("Yaw: ");
  Serial.print(yaw);
  Serial.print(" Pitch: ");
  Serial.print(pitch);
  Serial.print(" Roll: ");
  Serial.println(roll);
  // Use proper delay.
  delay(1000);
}
