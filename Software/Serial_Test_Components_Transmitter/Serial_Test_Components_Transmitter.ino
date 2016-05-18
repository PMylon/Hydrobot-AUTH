#include <TinyGPS++.h>
#include <SoftwareSerial.h>
#include "MotorDriver.h"
#include "HardwareSerial.h"
/*
   This sample sketch demonstrates the normal use of a TinyGPS++ (TinyGPSPlus) object.
   It requires the use of SoftwareSerial, and assumes that you have a
   4800-baud serial GPS device hooked up on pins 4(rx) and 3(tx).
*/
#define RFCHANNEL        0       // Let's use channel 0
#define SYNCWORD1        0xB5    // Synchronization word, high byte
#define SYNCWORD0        0x47    // Synchronization word, low byte
#define SOURCE_ADDR      4       // Sender address
#define DESTINATION_ADDR 5       // Receiver address


#define CLOCKWISE 0
#define COUNTERCLOCKWISE 1
#define motorA 1
#define motorB 0

//RF related declerations
CCPACKET txPacket;  // packet object
byte count = 0;
char temp[] = "hello world!";
String receivedRFString="";
bool rfStringReady = false;

//Motor related declerations
static int PWMA = 3; //Speed control 
//static int AIN1 = 5; //Direction
static int AIN2 = 4; //Direction
//static int STBY = 9; //standby

static int PWMB = 6; //Speed control 
//static int BIN1 = 0; //Direction
static int BIN2 = 7; //Direction

static int PWMC1 = 5;
static int PWMC2 = 9;

MotorDriver motorDriver(PWMA,AIN2,PWMB,BIN2);

//GPS related declerations
static const int GPS_RX_pin = 8;
static const uint32_t GPSBaud = 9600;
static int i=0;
String lastLocation = "";
// The TinyGPS++ object
TinyGPSPlus gps;

// The serial connection to the GPS device
SoftwareSerial ss(GPS_RX_pin, A7);

//


void setup()
{
  //analogReference(INTERNAL);
  pinMode(PWMC1, OUTPUT);
  pinMode(PWMC2, OUTPUT);
  Serial.begin(9600);
  ss.begin(GPSBaud);

  
  panstamp.radio.setChannel(RFCHANNEL);
  panstamp.radio.setSyncWord(SYNCWORD1, SYNCWORD0);
  panstamp.radio.setDevAddress(SOURCE_ADDR);
  panstamp.radio.setCCregs();

  // Let's disable address check for the current project so that our device
  // will receive packets even not addressed to it.
  panstamp.radio.disableAddressCheck();
  // Declare RF callback function
  panstamp.setPacketRxCallback(rfPacketReceived);
  //Serial.println("setup done");
}



void loop()
{
  // This sketch displays information every time a new sentence is correctly encoded.
  //Serial.println("before the while");
  while (ss.available() > 0)
  {
    //Serial.println("before if in the while");
    //Serial.print((char)ss.read());
    if (gps.encode(ss.read()))
    {
      displayInfo();
      //while(true);
      //delay(2000);
    }
  }

  if (millis() > 5000 && gps.charsProcessed() < 10)
  {
  // Serial.println(F("No GPS detected: check wiring."));
    //while(true);
  }
  
  if(Serial.available()>0)
  {
    String instruction="";
    char cChar=Serial.read();
    delay(10);
    instruction="";
    while(cChar != ',')
    {
      instruction+=cChar;
      cChar = Serial.read();
      delay(10);
    }
    interpretInstruction(instruction);
  }
  
}

void interpretInstruction(String instruction)
{
  String toSend="";
  //move motors instruction
  if (instruction.substring(0,3) == "MOT")
  {
    int motor = motorB;
    int motorSpeed = 0;
    int motorDirection = CLOCKWISE;
    if (instruction.charAt(3)=='A')
    {
      motor=motorA;
      if (instruction.charAt(4)=='R')
      {
        motorSpeed = instruction.substring(5,8).toInt();
        motorDirection = COUNTERCLOCKWISE;
      }
      else if (instruction.charAt(4)=='L')
      {
        motorSpeed = instruction.substring(5,8).toInt();
      }
      
      motorDriver.move(motor,motorSpeed,motorDirection);
    }
    else if(instruction.charAt(3)=='B')
    {
      if (instruction.charAt(4)=='R')
      {
        motorSpeed = instruction.substring(5,8).toInt();
        motorDirection = COUNTERCLOCKWISE;
      }
      else if (instruction.charAt(4)=='L')
      {
        motorSpeed = instruction.substring(5,8).toInt();
      }
      
      motorDriver.move(motor,motorSpeed,motorDirection);
    }
    else if(instruction.charAt(3)=='C')
    {
      if (instruction.charAt(4)=='R')
      {
        motorSpeed = instruction.substring(5,8).toInt();
        
      analogWrite(PWMC2,motorSpeed);
      analogWrite(PWMC1,0);
      }
      else if (instruction.charAt(4)=='L')
      {
        motorSpeed = instruction.substring(5,8).toInt();
        
      analogWrite(PWMC1,motorSpeed);
      analogWrite(PWMC2,0);
      }
    }
    //motorDriver.move(motor,motorSpeed,motorDirection);
    Serial.print("motor: ");
    Serial.print(motor);
    Serial.print(" motorSpeed: ");
    Serial.print(motorSpeed);
    Serial.print(" motorDirection: ");
    Serial.print(motorDirection);
    Serial.println();
    toSend+="Moving motor ";
    toSend+=instruction.charAt(3);
    toSend+=" at speed ";
    toSend+=String(motorSpeed);
    toSend+=" and direction ";
    toSend+=instruction.charAt(4);
    Serial.println(toSend);
    //sendRFString(toSend);
  }
  else if(instruction.substring(0,3) == "RQT")
  {
    int temp = analogRead(0);
    float tempC = (temp*100*3.3);
    tempC = tempC/1024;
    Serial.print(" analog temp reading = :");
    Serial.print(temp);
    Serial.print(" analog tempC = :");
    Serial.println(tempC,1);
  }
  else if(instruction.substring(0,3) == "RQP")
  {
    int temp = analogRead(1);
    double temp2 = temp/(double)1024;
    double tempVoltage = temp2*3.3;
    double pressure = (tempVoltage/5.1 +0.04)/0.004;
    Serial.print(" analog pressure reading = :");
    Serial.print(temp);
    Serial.print(" analog pressure voltage = :");
    Serial.print(tempVoltage,5);
    Serial.print(" pressure = :");
    Serial.println(pressure,5);
  }
  else if(instruction.substring(0,3) == "RQL")
  {
    Serial.println(lastLocation);
  }
  
}

void displayInfo()
{
  String toSend="";
  toSend+="LOC"; 
  if (gps.location.isValid())
  {
    toSend+=String(gps.location.lat(),6);
    toSend+=",";
    toSend+=String(gps.location.lng(),6);
  }
  else
  {
    toSend+="INVALID";
  }

  toSend+="UTC";
  if (gps.date.isValid())
  {
    toSend+=String(gps.date.day());
    toSend+="/";
    toSend+=String(gps.date.month());
    toSend+="/";
    toSend+=String(gps.date.year());
  }
  else
  {
    toSend+="INVALID";
  }
  toSend+=" ";
  if (gps.time.isValid())
  {
    if (gps.time.hour()+3 < 10) toSend+="0";
    toSend+=String(gps.time.hour()+3);
    toSend+=":";
    if (gps.time.minute() < 10) toSend+="0";
    toSend+=String(gps.time.minute());
    toSend+=":";
    if (gps.time.second() < 10) toSend+="0";
    toSend+=String(gps.time.second());
  }
  else
  {
    //Serial.print(F("INVALID"));
    toSend+="INVALID";
  }
  //digitalWrite(LED1, !digitalRead(LED1));
  //Serial.println(toSend);
  lastLocation = toSend;
  //sendRFString(toSend);
  toSend="";
}




void rfPacketReceived(CCPACKET *packet)
{   
  if (packet->length > 1 && packet->data[0]==SOURCE_ADDR)
  {   
      digitalWrite(8,HIGH);
      for (int i=1;i<packet->length;i++)
      {
        receivedRFString+=(char)packet->data[i];
      }
      interpretInstruction(receivedRFString);
      sendRFString(receivedRFString);
      receivedRFString="";
      //Serial.println("in rfpacketreceived");
      rfStringReady=true;
  }
}
void sendRFString(String toSendRF)
{
  txPacket.length = toSendRF.length()+1;
  txPacket.data[0] = DESTINATION_ADDR;
  for (int i=0;i<toSendRF.length();i++)
  {
    txPacket.data[i+1] = (byte)toSendRF.charAt(i);
  }
  panstamp.radio.sendData(txPacket);
}