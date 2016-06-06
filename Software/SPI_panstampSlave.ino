/* Panstamp slave sketch */
/* Author: Panagiotis Mylonas
 * Date: 6/6/2016
 */

/* TODO */
//1) Put MCU into sleep until it wakes from interrupt, in order to conserve power.

 /* Headers */
#include "HardwareSerial.h"
#include <SPI.h>

/* Type Definitions */
typedef union imu_packet
{
  float f;
  uint8_t b[4]; // float is 4-bytes on the Arduino platform.
}imu_packet_t;

/* Globals */
imu_packet_t impack;
float yaw, pitch, roll;

/* ISRs */
// Called when incoming SPI data arrives
ISR (SPI_STC_vect)
{
  uint8_t request = SPDR;

  switch(request)
  {
    case 0:
      impack.f = 0;
      SPDR = 0;
      break;
    case 'Y': // Yaw request
      impack.f = yaw;
      SPDR = impack.b[0]; // Send 1st byte of yaw.
      break;
    case 'P': // Pitch request
      impack.f = pitch;
      SPDR = impack.b[0]; // Send 1st byte of pitch.
      break;
    case 'R': // Roll request
      impack.f = roll;
      SPDR = impack.b[0]; // Send 1st byte of roll.
      break;
    case '1': // Send 2nd byte.
      SPDR = impack.b[1];
      break;
    case '2': // Send 3rd byte.
      SPDR = impack.b[2];
      break;
    case '3': // Send fourth byte.
      SPDR = impack.b[3];
      break;  
  }
}
void setup() {
  // Enable SPI in slave mode.
  SPCR |= bit(SPE);

  //pinMode(MOSI, INPUT);
  //pinMode(SCK, INPUT);
  //pinMode(SS, INPUT); 
  
  pinMode(MISO, OUTPUT);

  // Enable interrupt for SPI.
  SPCR |= bit(SPIE);

}

void loop() {
 // just for testing.
 yaw = 45.23;
 pitch = 18.32;
 roll = -11.8934;
}
