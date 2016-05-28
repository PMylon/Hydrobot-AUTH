#ifndef MotorDriver_h
#define MotorDriver_h

#include "Arduino.h"

class MotorDriver
{
	public:
		MotorDriver(int PWMA, int AIN2, int PWMB, int BIN2,int PWMC1,int PWMC2);
		void move(int motor, int speed, int direction);
		void stop(int motor);
		void standbyStop();
	private:
		int _PWMA,_AIN2,_PWMB,_BIN2,_PWMC1,_PWMC2;
};

#endif