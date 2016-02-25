#include <Servo.h> 

/* ITALIAN 
Questi valori si riferiscono ai 6 servo motori parallax 0-180 gradi che la mano InMoov utilizza per muovere le dita e il polso.
Questo codice utilizza un potenziomentro per testare la posizione dei servo motori. L'ho utilizzato quando la mano era già stata montata
percalibrare i motori con il movimento per avere il miglior risultato possibile.
Ecco un TUTORIAL con esempio e schema elettrico:
http://www.mauroalfieri.it/elettronica/tutorial-arduino-servo-2.html
*/ 
Servo pollice,indice,medio,anuce,mignolo,mano;  
int value;   
int potenziometro = 0;
 
void setup() 
{ 
 
   /*
   I servo motori vanno inseriti nei pin 3,5,6,9,10,11 perchè pwd, mentre il potenziometro nel pin analogico 0
   */
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
