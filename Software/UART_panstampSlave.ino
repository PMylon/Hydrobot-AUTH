/* Panstamp UART slave sketch */
/* Author: Panagiotis Mylonas
 * Date: 6/6/2016
 */

/* TODO */
//1) Put MCU into sleep until it wakes from interrupt, in order to conserve power.

 /* Headers */
#include "HardwareSerial.h"

/* Type Definitions */
typedef union imu_packet
{
  float f;
  uint8_t b[4]; // float is 4-bytes on the Arduino platform.
}imu_packet_t;

/* Globals */
imu_packet_t impack;
float yaw, pitch, roll;
uint8_t request;

/* ISRs */
// See: https://forum.arduino.cc/index.php?topic=349921.0

void setup() {
 // just for testing.
 yaw = 45.23;
 pitch = 18.32;
 roll = -11.8934;
 Serial.begin(9600);
}

void loop() {
  if (Serial.available() > 0)
  {
    request = Serial.read();
    if (request == 'O') // Orientation
    {
      // getOrientation. 
      // Send yaw, pitch and roll
      impack.f = yaw;
      Serial.write(impack.b, 4);
      impack.f = pitch;
      Serial.write(impack.b, 4);
      impack.f = roll;
      Serial.write(impack.b, 4);
    }
  }
}

