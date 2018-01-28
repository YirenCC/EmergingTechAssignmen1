const int button1 = 2;//up
const int button2 = 3;//down
const int button3 = 4;//forword
const int button4 = 5;//backword

void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600);

  pinMode(button1, INPUT);
  pinMode(button2, INPUT);
  pinMode(button3, INPUT);
  pinMode(button4, INPUT);
}

void loop() {
  // put your main code here, to run repeatedly:
  if(digitalRead(button1)==HIGH){
    Serial.println("1");
    Serial.flush();
    delay(20);
    }
    if(digitalRead(button2)==HIGH){
    Serial.println("2");
    Serial.flush();
    delay(20);
    }
    if(digitalRead(button3)==HIGH){
    Serial.println("3");
    Serial.flush();
    delay(20);
    }
    if(digitalRead(button4)==HIGH){
    Serial.println("4");
    Serial.flush();
    delay(20);
    }
    if(digitalRead(button1)==LOW && digitalRead(button2)==LOW && digitalRead(button3)==LOW && digitalRead(button4)==LOW){
    Serial.println("9");
    Serial.flush();
    delay(20);
    } 
}

