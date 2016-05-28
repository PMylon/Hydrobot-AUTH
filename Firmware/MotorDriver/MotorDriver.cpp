#include "Arduino.h"
#include "MotorDriver.h"

MotorDriver::MotorDriver(int PWMA, int AIN2, int PWMB, int BIN2,int PWMC1,int PWMC2)
{
	//initialize pins for the motor driver
  pinMode(PWMA, OUTPUT);
  pinMode(AIN2, OUTPUT);
  
  pinMode(PWMB, OUTPUT);
  pinMode(BIN2, OUTPUT);
  
  pinMode(PWMC1, OUTPUT);
  pinMode(PWMC2, OUTPUT);
  
  _PWMA = PWMA;
  _AIN2 = AIN2;
  _PWMB = PWMB;
  _BIN2 = BIN2;
  _PWMC1 = PWMC1;
  _PWMC2 = PWMC2;
}

void MotorDriver::move(int motor, int speed, int direction)
{
	//Move specific motor at speed and direction
//motor: 0 for B 1 for A
//speed: 0 is off, and 255 is full speed
//direction: 0 clockwise, 1 counter-clockwise

  //digitalWrite(_STBY, HIGH); //disable standby

  boolean inPin2 = HIGH;
  int motorCSpeed1 = speed;
  int motorCSpeed2 = 0;

  if(direction == 1){
    inPin2 = LOW;
	motorCSpeed1=0;
	motorCSpeed2 = speed;
  }

  if(motor == 1){
    //digitalWrite(_AIN1, inPin1);
    digitalWrite(_AIN2, inPin2);
    analogWrite(_PWMA, speed);
  }else if(motor ==0){
    //digitalWrite(_BIN1, inPin1);
    digitalWrite(_BIN2, inPin2);
    analogWrite(_PWMB, speed);
  }
  else 
  {
	analogWrite(_PWMC1,motorCSpeed1);
	analogWrite(_PWMC2,motorCSpeed2);
  }
}

void MotorDriver::stop(int motor)
{
	move(motor,0,0);
}

void MotorDriver::standbyStop()
{
	//enable standby  
  //digitalWrite(_STBY, LOW); 
}