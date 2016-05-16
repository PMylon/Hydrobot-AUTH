#include "MotorDriver.h"

#define CLOCKWISE 0
#define COUNTERCLOCKWISE 1
#define motorA 1
#define motorB 0

//Declarations for the Motor Driver
static int PWMA = 3; //Speed control 
static int AIN1 = 5; //Direction
static int AIN2 = 4; //Direction
static int STBY = 9; //standby

static int PWMB = 8; //Speed control 
static int BIN1 = 0; //Direction
static int BIN2 = 1; //Direction

MotorDriver motorDriver(PWMA,AIN1,AIN2,PWMB,BIN1,BIN2,STBY);


void setup() {
  // put your setup code here, to run once:

}

void loop() {
  motorDriver.move(motorA, 255, CLOCKWISE); //motor 1, full speed, left
  //move(2, 255, 1); //motor 2, full speed, left

  delay(1000); //go for 1 second
  motorDriver.stop(motorA); //stop
  delay(250); //hold for 250ms until move again

  motorDriver.move(motorA, 128, COUNTERCLOCKWISE); //motor 1, half speed, right
  //move(2, 128, 0); //motor 2, half speed, right

  delay(1000);
  motorDriver.stop(motorA);
  delay(250);
}
