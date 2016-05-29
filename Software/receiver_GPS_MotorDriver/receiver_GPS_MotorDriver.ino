#include "HardwareSerial.h"

String receivedRFString="";
bool hasInstruction=false;
bool rfStringReady = false;


#define RFCHANNEL        0       // Let's use channel 0
#define SYNCWORD1        0xB5    // Synchronization word, high byte
#define SYNCWORD0        0x47    // Synchronization word, low byte
#define SOURCE_ADDR      5       // Sender address
#define DESTINATION_ADDR 4       // Receiver address


CCPACKET txPacket;  // packet object
byte count = 0;


void setup()
{
  Serial.begin(9600);

  panstamp.radio.setChannel(RFCHANNEL);
  panstamp.radio.setSyncWord(SYNCWORD1, SYNCWORD0);
  panstamp.radio.setDevAddress(SOURCE_ADDR);
  panstamp.radio.setCCregs();

  // Let's disable address check for the current project so that our device
  // will receive packets even not addressed to it.
  panstamp.radio.disableAddressCheck();
  // Declare RF callback function
  panstamp.setPacketRxCallback(rfPacketReceived);
}

/**
 * This function is called whenever a wireless packet is received
 */



void loop()
{
  //txPacket.length = 2;  // Let's send a single data byte plus the destination address
  if (rfStringReady)
  {
    Serial.print("-Transmitter: ");
    Serial.print(receivedRFString);
    Serial.println();
    rfStringReady=false;
    receivedRFString="";
  }
  
  String instruction="";
  if(Serial.available()>0)
  {
    char cChar=Serial.read();
    delay(10);
    instruction="";
    while(cChar != ',')
    {
      instruction+=cChar;
      cChar = Serial.read();
      delay(10);
    }
    hasInstruction=true;
  }
  if (hasInstruction)
  {
    Serial.print("-Receiver: Sending instruction:  ");
    Serial.println(instruction);
    sendRFString(instruction);
    hasInstruction=false;
  }
   
  //delay(5000);                           // Transmit every 5 seconds
  // For low-power applications replace "delay" by "panstamp.sleepWd(WDTO_8S)" for example
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
void rfPacketReceived(CCPACKET *packet)
{   
  if (packet->length > 1 && packet->data[0]==SOURCE_ADDR)
  {   
      //digitalWrite(8,HIGH);
      for (int i=1;i<packet->length;i++)
      {
        receivedRFString+=(char)packet->data[i];
      }
      //Serial.println(receivedRFString);
      //receivedRFString="";
      rfStringReady=true;
  }
}
