#include <Servo.h> 

Servo Spollice,Sindice,Smedio,Sanuce,Smignolo,Smano;
int led = 12;
char protocol[12];

int indice = 0,
    medio = 0,
    anuce = 0,
    mignolo = 0,
    pollice = 0,
    mano = 0;

void setup()
{    
  Serial.begin(9600);
//  pinMode(led, OUTPUT); 

   Spollice.attach(3);  
   Sindice.attach(5); 
   Smedio.attach(6); 
   Sanuce.attach(9); 
   Smignolo.attach(10); 
   Smano.attach(11);  
}

int calcoloPeso(char character)
{
    int peso = 0;
    
    switch(character)
    {
       case 'a':
          peso = 0;
       break;
       
       case 'b':
          peso = 1;
       break;
       
       case 'c':
          peso = 2;
       break;
       
       case 'd':
          peso = 3;
       break;
       
       case 'e':
          peso = 4;
       break;
       
       case 'f':
          peso = 5;
       break;
       
       case 'g':
          peso = 6;
       break;
       
       case 'h':
          peso = 7;
       break;
       
       case 'i':
          peso = 8;
       break;
       
       case 'l':
          peso = 9;
       break;
    }
    
    return peso;
}

void movimentoServi(Servo servo,int posizione,int delayServo)
{
  if(posizione >= 0 && posizione <= 180)
  {
     servo.write(posizione);
     delay(delayServo);
  }
}

void convertireMovimentoMano(int dito,int minus,int maxum)
{
    dito = (dito * maxum)/180;
    if(dito < minus)
    {
       dito = minus;
    }
}

void loop() 
{
  int character = 12;
  
  while (Serial.available()) {

    Serial.readBytesUntil(character,protocol,12);
    
    indice  = (calcoloPeso(protocol[0]) * 10) + calcoloPeso(protocol[1]);
    medio   = (calcoloPeso(protocol[2]) * 10) + calcoloPeso(protocol[3]);
    anuce   = (calcoloPeso(protocol[4]) * 10) + calcoloPeso(protocol[5]);
    mignolo = (calcoloPeso(protocol[6]) * 10) + calcoloPeso(protocol[7]);
    pollice = (calcoloPeso(protocol[8]) * 10) + calcoloPeso(protocol[9]);
    mano    = (calcoloPeso(protocol[10]) * 10) + calcoloPeso(protocol[11]);
    
    indice  *= 2;
    medio   *= 2;
    anuce   *= 2;
    mignolo *= 2;
    pollice *= 2;
    mano    *= 2;
    
    // Proporzione FollowHand
    convertireMovimentoMano(pollice,30,150);
    convertireMovimentoMano(indice,20,165);
    convertireMovimentoMano(medio,40,155);
    convertireMovimentoMano(anuce,60,180);
    convertireMovimentoMano(mignolo,20,160);
    
    movimentoServi(Spollice,pollice,15);
    movimentoServi(Sindice,indice,15);
    movimentoServi(Smedio,medio,15);
    movimentoServi(Sanuce,anuce,15);
    movimentoServi(Smignolo,mignolo,15);
    movimentoServi(Smano,mano,15);
    
  }
}
