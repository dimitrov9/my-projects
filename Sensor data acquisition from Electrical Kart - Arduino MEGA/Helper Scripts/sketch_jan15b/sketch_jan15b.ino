/*
 1. Upload this code and open the serial monitor
 2. On the serial monitor enter the command AT 
 3. If the response is OK, your esp8266 serial baud rate is 115200. 
    Close this sketch and run the example code. 
    Then on the void setup make this change: espSerial.begin(115200); and upload the code.
    
    If you want to change the speed to 9600 use the command AT+UART_CUR=9600,8,1,0,0

 4. Otherwise if you can't see anything on the serial display reset the ESP8266 module
    change the esp8266 serial baud rate to 9600 or other, until you get a response. 
    Then enter the command AT+UART_CUR=115200,8,1,0,0 to change the speed to 115200 
 
*/

// AT                             Command to display the OK message
// AT+GMR                         Command to display esp8266 version info
// AT+UART_CUR=9600,8,1,0,0       Command to change the ESP8266 serial baud rate  to 9600   
// AT Command to change the ESP8266 serial baud rate  to 115200   AT+UART_CUR=115200,8,1,0,0

// Hardware serial test - Arduino MEGA
void setup() {
 Serial.begin(9600);
 Serial2.begin(115200);    // or 115200
}
void loop() { 
 
  while (Serial.available()) { 
      char ch = Serial.read();
      Serial2.print(ch);
    }
  
  while (Serial2.available()) { 
      char ch = Serial2.read();
      Serial.print(ch);
    }
}
