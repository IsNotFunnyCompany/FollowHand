#include <Servo.h> 

/*
Questo codice è da utilizzare compilandolo in Arduino quando tutto è collegato e pronto da far funzionare
*/

// inizializzo i 6 servo motori, 5 dita e il polso
Servo Spollice,Sindice,Smedio,Sanuce,Smignolo,Smano;
int led = 12;

// la stringa di caratteri che arriva dalla porta seriale (unity 3d) e che viene ricevuta da arduino
char protocol[12];

// i valori che in fine arriveranno ai servo motori
int indice = 0,
    medio = 0,
    anuce = 0,
    mignolo = 0,
    pollice = 0,
    mano = 0;

void setup()
{    
   Serial.begin(9600);

   Spollice.attach(3);  
   Sindice.attach(5); 
   Smedio.attach(6); 
   Sanuce.attach(9); 
   Smignolo.attach(10); 
   Smano.attach(11);  
}

/*

Questa funzione assegna a ogni carattere un numero, perchè dalla porta seriale Arduino non legge numeri ma stringhe di caratteri
perciò per dire alle dita di posizionarsi in una particolare posizione numerica bisogna convertire il tutto in numeri.

*/

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

/*
Questa funzione viene utilizzata per muovere i servo motori nella posizione desiderata
*/

void movimentoServi(Servo servo,int posizione,int delayServo)
{
  if(posizione >= 0 && posizione <= 180)
  {
     servo.write(posizione);
     delay(delayServo);
  }
}

/*
Questa funzione l'ho utilizzata per rendere più preciso il movimento delle dita sulla mia mano robotica, per una questione di montaggio
il movimento viene reso più dolce e fluido, nel caso stai facendo una mano robot puoi togliere questa funzione testando il funzionamento
anche senza altrimementi potrebbe essere un ostacolo ciò
*/

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
  // lunghezza caratteri letti dalla seriale USB di Arduino
  int character = 12;
  
  while (Serial.available()) {

    Serial.readBytesUntil(character,protocol,12);
    
    /*
    La logica è questa:
    
    1) unity 3d manda una stringa di caratteri sulla porta seriale di 12 caratteri
    2) i valori mandati da unity 3d sono la metà dei valori originali
    esempio:
    NON mando i valori: 180,121 ecc. sulla porta seriale ma la metà per risparmiare spazio: 90,21 ecc.
    
    180 = 90*2      -> Pollice
    50 = 25*2       -> Mignolo
    
    ecc.
    
    3) Il primo valore è la parte decimale primaria e il secondo la parte numerica secondaria
    esempio:
    ef = 45 = (4*10)+(5)
    la = 90 = (9*10)+(0)
    
    ecc.
    
    4) I valori visto che sono la metà vengono moltiplicati per 3
    
    */
    
    // punto 3) (vedi sopra)
    indice  = (calcoloPeso(protocol[0]) * 10) + calcoloPeso(protocol[1]);
    medio   = (calcoloPeso(protocol[2]) * 10) + calcoloPeso(protocol[3]);
    anuce   = (calcoloPeso(protocol[4]) * 10) + calcoloPeso(protocol[5]);
    mignolo = (calcoloPeso(protocol[6]) * 10) + calcoloPeso(protocol[7]);
    pollice = (calcoloPeso(protocol[8]) * 10) + calcoloPeso(protocol[9]);
    mano    = (calcoloPeso(protocol[10]) * 10) + calcoloPeso(protocol[11]);
    
    // punto 4) (vedi sopra)
    indice  *= 2;
    medio   *= 2;
    anuce   *= 2;
    mignolo *= 2;
    pollice *= 2;
    mano    *= 2;
    
    // Proporzione creata perchè la mia mano robot per problemi hardware e di costruzione non faceva muovere i servo motori da 0 a 180
    // ma alcune dita partiva da 30 e raggiungeva il dito chiuso a 150 gradi.
    // ATTENZIONE: Questa funzione è stata utilizzata dopo un debug con il file ServoDebug.ino nella cartella ServoDebug.
    convertireMovimentoMano(pollice,30,150);
    convertireMovimentoMano(indice,20,165);
    convertireMovimentoMano(medio,40,155);
    convertireMovimentoMano(anuce,60,180);
    convertireMovimentoMano(mignolo,20,160);
    
    // Invio il movimento ai servo motori
    movimentoServi(Spollice,pollice,15);
    movimentoServi(Sindice,indice,15);
    movimentoServi(Smedio,medio,15);
    movimentoServi(Sanuce,anuce,15);
    movimentoServi(Smignolo,mignolo,15);
    movimentoServi(Smano,mano,15);
    
  }
}
