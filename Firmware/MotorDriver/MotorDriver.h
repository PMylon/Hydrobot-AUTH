#ifndef MotorDriver_h
#define MotorDriver_h

#include "Arduino.h"

class MotorDriver
{
	public:
		MotorDriver(int PWMA,int AIN1, int AIN2, int PWMB, int BIN1, int BIN2,int STBY);
		void move(int motor, int speed, int direction);
		void stop(int motor);
		void standbyStop();
	private:
		int _PWMA,_AIN1,_AIN2,_PWMB,_BIN1,_BIN2,_STBY;
};

#endif