/* boolean connectESP8266_toInternet(String wifiNetworkName,String wifiNetworkPassword, int port);  Set your home wifi network SSID and PASSWORD  (Put this function on start of void setup)
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
#include <OneWire.h>
#include <DallasTemperature.h>
#include <TinyGPS++.h>
#define trigPin1 8         
#define echoPin1 9                            
#define trigPin2 12
#define echoPin2 13

float duration, distance, UltraSensor1, UltraSensor2, t1, t2, vout, vin = 0.0;
float R1 = 30000.0; 
float R2 = 7500.0; 
int analogInput = A1;
int val = 0;
TinyGPSPlus gps;
volatile int cnt = 0;
unsigned long rpm, speed_val = 0;
unsigned long timeold, temp = 0;


// temperaturni senzori
int temp_sensor1 = 5; //- pinovi na koi sa povrzani
int temp_sensor2 = 6;
OneWire oneWirePin1(temp_sensor1);
OneWire oneWirePin2(temp_sensor2);
//temp za baterija
DallasTemperature sensor1(&oneWirePin1);
//temp za motor
DallasTemperature sensor2(&oneWirePin2);

VirtuinoEsp8266_WebServer virtuino(Serial2,115200);    

// Connect the  ESP01 module to Arduino Mega - Due Serial1 port as the plan below
//  http://iliaslamprou.mysch.gr/virtuino/esp8266_arduino_mega_connection_plan.png

// Arduino Mega settings -> Open VirtuinoEsp8266_WebServer file on the virtuino library folder ->  disable the line: #define ESP8266_USE_SOFTWARE_SERIAL 

// Arduino Due settings  -> 1.Open VirtuinoBluetooth.h on the virtuino library folder ->  disable the line: #define BLUETOOTH_USE_SOFTWARE_SERIAL 
//                       -> 2.Open VirtuinoEsp8266_WebServer file on the virtuino library folder ->  disable the line: #define ESP8266_USE_SOFTWARE_SERIAL 
                               

void setup() 
{
  virtuino.DEBUG=true;                                            // set this value TRUE to enable the serial monitor status.It is neccesary to get your esp8266 local ip
  Serial.begin(9600);
  Serial2.begin(115200);
  // Enable this line only if DEBUG=true
  virtuino.createLocalESP8266_wifiServer("ESP","ESPmodulwifi",80,2);
  //virtuino.connectESP8266_toInternet("username","password",8000);  // Set your home wifi router SSID and PASSWORD. ESP8266 will connect to Internet. Port=80
  //virtuino.esp8266_setIP(192,168,0,100);                                          // Set a local ip. Forward port 80 to this IP on your router

  //virtuino.createLocalESP8266_wifiServer("ESP8266 NETWORK NAME","PASSWORD",80,2);   //Enable this line to create a wifi local netrork using ESP8266 as access point
                                                                                      //Do not use less than eight characters for the password. Port=80                                                                                   //Default access point ESP8266 ip=192.168.4.1. 
 
  virtuino.password="1234";                                     // Set a password to your web server for more protection 
                                                                // avoid special characters like ! $ = @ # % & * on your password. Use only numbers or text characters                         
    Serial1.begin(9600);
    sensor1.begin();
    sensor2.begin();
    pinMode(analogInput, INPUT);
    pinMode(trigPin1, OUTPUT);                   
    pinMode(echoPin1, INPUT);                     
    pinMode(trigPin2, OUTPUT);
    pinMode(echoPin2, INPUT);
     
}

void loop(){
   virtuino.run();           //  necessary command to communicate with Virtuino android app
   get_temp();   

    Serial.println(arduino.waitForResponse(


// Temperature sensors
    Serial.print("Temperature on Sensor 1 is: ");
    Serial.print(sensor1.getTempCByIndex(0)); // Why "byIndex"? You can have more than one IC on the same bus. 0 refers to the first IC on the wire
    Serial.print("  ");
    Serial.print("Sensor 2 is: ");
    Serial.print(sensor2.getTempCByIndex(0)); 
    Serial.println();
// write to memory
    virtuino.vMemoryWrite(0,sensor1.getTempCByIndex(0));
    virtuino.vMemoryWrite(1,sensor2.getTempCByIndex(0));
    virtuino.vDelay(2000); //Update value every 2 sec



// Sonar sensors
    SonarSensor(trigPin1, echoPin1);              // look bellow to find the difinition of the SonarSensor function
    UltraSensor1 = distance;                      // store the distance in the first variable
    SonarSensor(trigPin2,echoPin2);               // call the SonarSensor function again with the second sensor pins
    UltraSensor2 = distance;                      // store the new distance in the second variable
    delay(2000);
    // display the distances on the serial monitor for the first sensor
    //----------------------------------------------------------------------------------------------------------------------
    Serial.print("distance measured by the first sensor: ");
    if (UltraSensor1 >= 400 || UltraSensor1 <= 2){
      Serial.println("Out of range");
    }
    else {
    Serial.print(UltraSensor1);
    Serial.println(" cm");
    virtuino.vMemoryWrite(2,UltraSensor1);
    }
    //----------------------------------------------------------------------------------------------------------------------
    
    //display the distance on the serial monitor for the second sensor
    //----------------------------------------------------------------------------------------------------------------------
    Serial.print("distance measured by the second sensor: ");
    if (UltraSensor2 >= 400 || UltraSensor2 <= 2){
      Serial.println("Out of range");
    }
    else {
    Serial.print(UltraSensor2);
    Serial.println(" cm");
    virtuino.vMemoryWrite(3,UltraSensor2);
    }


// Get voltage
    val = analogRead(analogInput);
    vout = (val * 5.0) / 1024.0;
    vin = vout / (R2/(R1+R2));
    //Serial.print("INPUT V= ");
    //Serial.println(vin,2);
// write to memory
    virtuino.vMemoryWrite(4,vin);
    virtuino.vDelay(2000); //Update value every 2 sec 



// GPS
    while(Serial1.available())//While there are characters to come from the GPS
  {
    gps.encode(Serial1.read());//This feeds the serial NMEA data into the library one char at a time
  }
    if(gps.location.isUpdated())//This will pretty much be fired all the time anyway but will at least reduce it to only after a package of NMEA data comes in
  {
    //Get the latest info from the gps object which it derived from the data sent by the GPS unit
    //Serial.println("Satellite Count:");
    //Serial.println(gps.satellites.value());
    //Serial.println("Latitude:");
    //Serial.println(gps.location.lat(), 6);
    //Serial.println("Longitude:");
    //Serial.println(gps.location.lng(), 6);
    //Serial.println("Speed KMH:");
    //Serial.println(gps.speed.kmph());
    //Serial.println("Altitude meters:");
    //Serial.println(gps.altitude.meters());
    //Serial.println("Time:");
    //Serial.print(gps.time.hour() + 2);
    //Serial.print(":");
    //Serial.print(gps.time.minute());
    //Serial.print(":");
    //Serial.println(gps.time.second());
    //Serial.println("Date:");
    //Serial.print(gps.date.day());
    //Serial.print(".");
    //Serial.print(gps.date.month());
    //Serial.print(".");
   //Serial.print(gps.date.year());
    //Serial.println("");


  double latitude = gps.location.lat();
  double longitude = gps.location.lng();

  int latDeg = (int)latitude;
  int lngDeg = (int)longitude;
  int latMin = (int)((latitude - latDeg)*100);
  int lngMin = (int)((longitude - lngDeg)*100);
  double latSec = (((latitude - latDeg)*100) - latMin)*100;
  double lngSec = (((longitude - lngDeg)*100) - lngMin )*100;

// write to memory
    virtuino.vMemoryWrite(5, gps.satellites.value());
    virtuino.vMemoryWrite(6, latDeg);
    virtuino.vMemoryWrite(7, lngDeg);
    virtuino.vMemoryWrite(8, latMin);
    virtuino.vMemoryWrite(9, lngMin);
    virtuino.vMemoryWrite(10, latSec);
    virtuino.vMemoryWrite(11, lngSec);
    virtuino.vMemoryWrite(12, gps.speed.kmph());
    virtuino.vMemoryWrite(13, gps.altitude.meters());
//    virtuino.vMemoryWrite(14, gps.time.hour() + 2);
//    virtuino.vMemoryWrite(15, gps.time.minute());
//    virtuino.vMemoryWrite(16, gps.time.second());
//    virtuino.vMemoryWrite(17, gps.date.day());
//    virtuino.vMemoryWrite(18, gps.date.month());
//    virtuino.vMemoryWrite(19, gps.date.year());
  }
 
 }

  void get_temp(){
  sensor1.requestTemperatures();  // Send the command to get temperatures
  sensor2.requestTemperatures();
  t1 = sensor1.getTempCByIndex(0); // Why "byIndex"? You can have more than one IC on the same bus. 0 refers to the first IC on the wire
  t2 = sensor2.getTempCByIndex(0); 
  }

  void SonarSensor(int trigPinSensor,int echoPinSensor)//it takes the trigPIN and the echoPIN 
{
  //START SonarSensor FUNCTION
  //generate the ultrasonic wave
//---------------------------------------------------------------------------------------------------------------------- 
digitalWrite(trigPinSensor, LOW);// put trigpin LOW 
delayMicroseconds(2);// wait 2 microseconds
digitalWrite(trigPinSensor, HIGH);// switch trigpin HIGH
delayMicroseconds(10); // wait 10 microseconds
digitalWrite(trigPinSensor, LOW);// turn it LOW again
//----------------------------------------------------------------------------------------------------------------------

//read the distance
//----------------------------------------------------------------------------------------------------------------------
duration = pulseIn(echoPinSensor, HIGH);//pulseIn funtion will return the time on how much the configured pin remain the level HIGH or LOW; in this case it will return how much time echoPinSensor stay HIGH
distance= (duration/2) * 0.0343; // first we have to divide the duration by two  
}// END SonarSensor FUNCTION
