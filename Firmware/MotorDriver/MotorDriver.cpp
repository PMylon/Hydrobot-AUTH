#include "Arduino.h"
#include "MotorDriver.h"

MotorDriver::MotorDriver(int PWMA,int AIN1, int AIN2, int PWMB, int BIN1, int BIN2,int STBY)
{
	//initialize pins for the motor driver
  pinMode(STBY, OUTPUT);
  pinMode(PWMA, OUTPUT);
  pinMode(AIN1, OUTPUT);
  pinMode(AIN2, OUTPUT);
  
  pinMode(PWMB, OUTPUT);
  pinMode(BIN1, OUTPUT);
  pinMode(BIN2, OUTPUT);
  _PWMA = PWMA;
  _AIN1 = AIN1;
  _AIN2 = AIN2;
  _PWMB = PWMB;
  _BIN1 = BIN1;
  _BIN2 = BIN2;
  _STBY = STBY;
}

void MotorDriver::move(int motor, int speed, int direction)
{
	//Move specific motor at speed and direction
//motor: 0 for B 1 for A
//speed: 0 is off, and 255 is full speed
//direction: 0 clockwise, 1 counter-clockwise

  digitalWrite(_STBY, HIGH); //disable standby

  boolean inPin1 = LOW;
  boolean inPin2 = HIGH;

  if(direction == 1){
    inPin1 = HIGH;
    inPin2 = LOW;
  }

  if(motor == 1){
    digitalWrite(_AIN1, inPin1);
    digitalWrite(_AIN2, inPin2);
    analogWrite(_PWMA, speed);
  }else{
    digitalWrite(_BIN1, inPin1);
    digitalWrite(_BIN2, inPin2);
    analogWrite(_PWMB, speed);
  }
}

void MotorDriver::stop(int motor)
{
	move(motor,0,0);
}

void MotorDriver::standbyStop()
{
	//enable standby  
  digitalWrite(_STBY, LOW); 
}