/*========= VirtuinoEsp8266 Class methods  
 
 * boolean connectESP8266_toInternet(String wifiNetworkName,String wifiNetworkPassword, int port);  Set your home wifi network SSID and PASSWORD  (Put this function on start of void setup)
 *
 * boolean createLocalESP8266_wifiServer(String wifiNetworkName,String wifiNetworkPassword, int port, int mode); Use this function to create an ESP8266 wifi local network
 *                                                                   set port to 80 
 *                                                                   set mode=2 to use ESP8266 only as access point 
 *                                                                   set mode=3 to use ESP8266 as access point and internet station.
 *
 *  bool esp8266_setIP(byte a1, byte a2, byte a3, byte a4);           set ESP8266 local IP. Use this function after connectESP8266_toInternet function 
 *
 * ========= Virtuino general methods  
 *  void vDigitalMemoryWrite(int digitalMemoryIndex, int value)       write a value to a Virtuino digital memory   (digitalMemoryIndex=0..31, value range = 0 or 1)
 *  int  vDigitalMemoryRead(int digitalMemoryIndex)                   read  the value of a Virtuino digital memory (digitalMemoryIndex=0..31, returned value range = 0 or 1)
 *  void vMemoryWrite(int memoryIndex, float value);                  write a value to Virtuino memory             (memoryIndex=0..31, value range as float value)
 *  float vMemoryRead(int memoryIndex);                               read a value of  Virtuino memory             (memoryIndex=0..31, returned a float value
 *  run();                                                            neccesary command to communicate with Virtuino android app  (on start of void loop)
 *  int getPinValue(int pin);                                         read the value of a Pin. Usefull to read the value of a PWM pin
 *  void vDelay(long milliseconds);                                   Pauses the program (without block communication) for the amount of time (in miliseconds) specified as parameter
 *  void vDelay(long milliseconds);                                   Pauses the program (without block communication) for the amount of time (in miliseconds) specified as parameter
 *  void clearTextBuffer();                                           Clear the text received text buffer
 *  int textAvailable();                                              Check if there is text in the received buffer
 *  String getText(byte ID);                                          Read the text from Virtuino app
 * void sendText(byte ID, String text);                               Send text to Virtuino app  
 */
 
#include "VirtuinoEsp8266_WebServer.h"
                                             
// Code to use HardwareSerial
VirtuinoEsp8266_WebServer virtuino(Serial2,115200);    // enable this line and disable all Software serial lines
                                                        // Open VirtuinoESP8266_WebServer.h file on the virtuino library folder
                                                        // and disable the line: #define ESP8266_USE_SOFTWARE_SERIAL 

float integer=5;
bool bol=1;

void setup() 
{
  virtuino.DEBUG=true;                                            // set this value TRUE to enable the serial monitor status.It is neccesary to get your esp8266 local ip
  Serial.begin(9600);                                             // Enable this line only if DEBUG=true

  Serial2.begin(115200);               // Enable this line if you want to use hardware serial (Mega, DUE etc.)

  //virtuino.connectESP8266_toInternet("BlueHall","snowflake",8000);  // Set your home wifi router SSID and PASSWORD. ESP8266 will connect to Internet. Port=80
  //virtuino.esp8266_setIP(192,168,1,140);                                          // Set a local ip. Forward port 80 to this IP on your router

  virtuino.createLocalESP8266_wifiServer("ESP","ESPmodulwifi",80,2);
  virtuino.password="1234";                                     // Set a password to your web server for more protection 
                                                                // avoid special characters like ! $ = @ # % & * on your password. Use only numbers or text characters
}

void loop(){
   virtuino.run();           //  necessary command to communicate with Virtuino android app

    //------ enter your loop code below here
    //------ avoid to use delay() function in your code. Use the command virtuino.vDelay() instead of delay()

    // your code .....
    virtuino.vMemoryWrite(0,integer);
    virtuino.vDigitalMemoryWrite(1,bol);
    
    integer=virtuino.vMemoryRead(1);
    bol=virtuino.vDigitalMemoryRead(0);   

    

    virtuino.vDelay(5000);

     //----- end of your code
 }


