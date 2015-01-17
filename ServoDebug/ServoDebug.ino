#include <Servo.h> 
 
Servo pollice,indice,medio,anuce,mignolo,mano;  
int value;   
int potenziometro = 0;
 
void setup() 
{ 
   pollice.attach(3);  
   indice.attach(5); 
   medio.attach(6); 
   anuce.attach(9); 
   mignolo.attach(10); 
   mano.attach(11);
} 
 
 void movimentoServi(Servo servo,int posizione,int delayServo)
 {
   servo.write(posizione);
   delay(delayServo);
 }
 
void loop() 
{ 
   value = analogRead(potenziometro);
   value = map(value, 0, 1023, 0, 179);
   movimentoServi(pollice,value,15);
   movimentoServi(indice,value,15);
   movimentoServi(medio,value,15);
   movimentoServi(anuce,value,15);
   movimentoServi(mignolo,value,15);
   movimentoServi(mano,value,15);
} 
