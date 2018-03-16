#include "TinyGPS++.h"
//#include "SoftwareSerial.h"

//SoftwareSerial serial_connection(10, 11); //RX=pin 10, TX=pin 11
TinyGPSPlus gps;//This is the GPS object that will pretty much do all the grunt work with the NMEA data
//TinyGPSCustom magneticVariation(gps, "GPRMC", 10);
void setup()
{
  Serial.begin(9600);//This opens up communications to the Serial monitor in the Arduino IDE
  Serial1.begin(9600);//This opens up communications to the GPS
  Serial.println("GPS Start");//Just show to the monitor that the sketch has started
}

void loop()
{
  while(Serial1.available())//While there are characters to come from the GPS
  {
    gps.encode(Serial1.read());//This feeds the serial NMEA data into the library one char at a time
  }
//      Serial.print("charsProcessed");
//      Serial.println(gps.charsProcessed());
//
//      Serial.print("sentencesWithFix");
//      Serial.println(gps.sentencesWithFix());
//
//      Serial.print("failedChecksum");
//      Serial.println(gps.failedChecksum());
//
//      Serial.print("passedChecksum");
//      Serial.println(gps.passedChecksum());
//
//if (magneticVariation.isUpdated())
//{
//  Serial.print("Magnetic variation is ");
//  Serial.println(magneticVariation.value());
//}

      
  if(gps.location.isUpdated())//This will pretty much be fired all the time anyway but will at least reduce it to only after a package of NMEA data comes in
  {
    //Get the latest info from the gps object which it derived from the data sent by the GPS unit
    Serial.println("Satellite Count:");
    Serial.println(gps.satellites.value());
    Serial.println("Latitude:");
    Serial.println(gps.location.lat(), 6);
    Serial.println("Longitude:");
    Serial.println(gps.location.lng(), 6);
    Serial.println("Speed KMH:");
    Serial.println(gps.speed.kmph());
    Serial.println("Altitude meters:");
    Serial.println(gps.altitude.meters());
    Serial.println("Time:");
    Serial.print(gps.time.hour() + 2);
    Serial.print(":");
    Serial.print(gps.time.minute());
    Serial.print(":");
    Serial.println(gps.time.second());
    Serial.println("Date:");
    Serial.print(gps.date.day());
    Serial.print(".");
    Serial.print(gps.date.month());
    Serial.print(".");
    Serial.print(gps.date.year());
    Serial.println("");
  }
}

/*
 * $GPRMC,183729,A,3907.356,N,12102.482,W,000.0,360.0,080301,015.5,E*6F
 primer za NMEA poraka pred da bide desifrirana
*/
