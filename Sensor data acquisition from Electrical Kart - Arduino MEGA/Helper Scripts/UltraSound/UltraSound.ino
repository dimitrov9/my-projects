//Start :
//define the pins that we will use for the first ultrasonic sensor
//----------------------------------------------------------------------------------------------------------------------
#define trigPin1 9                                   //pin number 9 in arduino MEGA2560
#define echoPin1 10                                   // we'll use this pin to read the signal from the first sensor
//----------------------------------------------------------------------------------------------------------------------

//define the pins that we will use for the second ultrasonic sensor
//----------------------------------------------------------------------------------------------------------------------
#define trigPin2 12
#define echoPin2 13
//----------------------------------------------------------------------------------------------------------------------

//used variables
//----------------------------------------------------------------------------------------------------------------------
float duration, distance, UltraSensor1, UltraSensor2; //we'll use these variable to store and generate data

//----------------------------------------------------------------------------------------------------------------------

//Make the setup of your pins
//----------------------------------------------------------------------------------------------------------------------
void setup()
{// START SETUP FUNCTION
Serial.begin (9600);                              // we will use the serial data transmission to display the distance value on the serial monitor 

// setup pins first sensor
pinMode(trigPin1, OUTPUT);                        // from where we will transmit the ultrasonic wave
pinMode(echoPin1, INPUT);                         //from where we will read the reflected wave 

//setup pins second sensor
pinMode(trigPin2, OUTPUT);
pinMode(echoPin2, INPUT);

}// END SETUP FUNCTION
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

//write the code in the loop function
void loop() 
{
// START THE LOOP FUNCTION
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
}
Serial.println("---------------------------------------------------------------------------------------------------------");
//----------------------------------------------------------------------------------------------------------------------
}
/****************************----------------------- END PROGRAM -----------------------****************************/
