#include <OneWire.h>
#include <DallasTemperature.h>

float t1,t2 = 0;
int temp_sensor1 = 5; //- pinovi na koi sa povrzani
int temp_sensor2 = 6;
OneWire oneWirePin1(temp_sensor1);
OneWire oneWirePin2(temp_sensor2);
DallasTemperature sensor1(&oneWirePin1);
DallasTemperature sensor2(&oneWirePin2);

void get_temp(){
sensor1.requestTemperatures();  // Send the command to get temperatures
sensor2.requestTemperatures();
t1 = sensor1.getTempCByIndex(0); // Why "byIndex"? You can have more than one IC on the same bus. 0 refers to the first IC on the wire
t2 = sensor2.getTempCByIndex(0); 
}

void setup(void){
    Serial.begin(9600); //Begin serial communication
    sensor1.begin(); //start sensor 1
    sensor2.begin();}

void loop(void){ 
    get_temp();
    Serial.print("Temperature on Sensor 1 is: ");
    Serial.print(t1,2);
    Serial.print("Temperature on Sensor 2 is: ");
    Serial.println(t2,2);
    delay(1000); //Update value every 1 sec
}


