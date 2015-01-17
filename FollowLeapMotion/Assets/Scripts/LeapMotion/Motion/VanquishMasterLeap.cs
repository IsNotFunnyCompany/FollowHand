using UnityEngine;
using System.Collections;
using System.Threading;
using Leap;

/*
          ____                   _______                   _____            _____           _______                   _____          
         /\    \                 /::\    \                 /\    \          /\    \         /::\    \                 /\    \         
        /::\    \               /::::\    \               /::\____\        /::\____\       /::::\    \               /::\____\        
       /::::\    \             /::::::\    \             /:::/    /       /:::/    /      /::::::\    \             /:::/    /        
      /::::::\    \           /::::::::\    \           /:::/    /       /:::/    /      /::::::::\    \           /:::/   _/___      
     /:::/\:::\    \         /:::/~~\:::\    \         /:::/    /       /:::/    /      /:::/~~\:::\    \         /:::/   /\    \     
    /:::/__\:::\    \       /:::/    \:::\    \       /:::/    /       /:::/    /      /:::/    \:::\    \       /:::/   /::\____\    
   /::::\   \:::\    \     /:::/    / \:::\    \     /:::/    /       /:::/    /      /:::/    / \:::\    \     /:::/   /:::/    /    
  /::::::\   \:::\    \   /:::/____/   \:::\____\   /:::/    /       /:::/    /      /:::/____/   \:::\____\   /:::/   /:::/   _/___  
 /:::/\:::\   \:::\    \ |:::|    |     |:::|    | /:::/    /       /:::/    /      |:::|    |     |:::|    | /:::/___/:::/   /\    \ 
/:::/  \:::\   \:::\____\|:::|____|     |:::|    |/:::/____/       /:::/____/       |:::|____|     |:::|    ||:::|   /:::/   /::\____\
\::/    \:::\   \::/    / \:::\    \   /:::/    / \:::\    \       \:::\    \        \:::\    \   /:::/    / |:::|__/:::/   /:::/    /
 \/____/ \:::\   \/____/   \:::\    \ /:::/    /   \:::\    \       \:::\    \        \:::\    \ /:::/    /   \:::\/:::/   /:::/    / 
          \:::\    \        \:::\    /:::/    /     \:::\    \       \:::\    \        \:::\    /:::/    /     \::::::/   /:::/    /  
           \:::\____\        \:::\__/:::/    /       \:::\    \       \:::\    \        \:::\__/:::/    /       \::::/___/:::/    /   
            \::/    /         \::::::::/    /         \:::\    \       \:::\    \        \::::::::/    /         \:::\__/:::/    /    
             \/____/           \::::::/    /           \:::\    \       \:::\    \        \::::::/    /           \::::::::/    /     
                                \::::/    /             \:::\    \       \:::\    \        \::::/    /             \::::::/    /      
                                 \::/____/               \:::\____\       \:::\____\        \::/____/               \::::/    /       
                                                          \::/    /        \::/    /                                 \::/____/        
                                                           \/____/          \/____/                                                 
                                                                                                                                      

                                                                                 Alex Voicu Developer 14/03/2014
*/


public class VanquishMasterLeap : MonoBehaviour
{

	private Controller controller;

	public static float pitch = 0.0f;
	public static float roll  = 0.0f;
	public static float yaw   = 0.0f;

	public static GameObject[] followFingers = new GameObject[6]; 
	public static Vector3[]    followVector  = new Vector3[5];
	public static float[]      followValues  = new float[6];    
	
	public static int[]        followFingersId = new int[5]; 
	public static int[]        followFingersIdFour = new int[5];   // i valori devono essere sempre 5 perchè altrimenti non si può capire quale dito scompare
	public static int          fingerHide;

	private static float tempo;
	public  static int number=0;
	private static bool mandato = false;
	
	public static float posizioneMano;
	private static float tollerance = 50.0f;
	
//	public static bool handInScene = false;
	
/*	
	public static float pitchAnimator()
	{
		return -(pitch/25);
	}
	
	public static float rollAnimator()
	{
		return -(roll/25);
	}
	
    public static float yawAnimator()
	{
		return -(yaw/25);
	}
	
*/
	
public static void OnFrame(Controller controller)
{
	if(controller.IsConnected)
	{
	   Frame frame = controller.Frame();

		if (!frame.Hands.IsEmpty) 
		{

			Hand hand = frame.Hands[0];
			FingerList fingers = hand.Fingers;
				
			Vector normal = hand.PalmNormal;
			Vector direction = hand.Direction;
				
			pitch = direction.Pitch * 180.0f / (float)Mathf.PI;
			roll  = normal.Roll     * 180.0f / (float)Mathf.PI;
			yaw   = direction.Yaw   * 180.0f / (float)Mathf.PI;
				 
			followFingers[5].transform.position = hand.PalmPosition.ToUnityTranslated();
			followFingers[5].renderer.enabled   = true; 
				
            posizioneMano = followFingers[5].transform.position.y * 180.0f / (float)Mathf.PI;	
				
			// Il roll deve essere implementato dopo che si ha capito come verrà montato la mano inmoov
			if(roll<0)
			{
					followValues[5] = -(int)roll;
				//	Debug.Log("Roll < 0: " + followValues[5] + "DESTRA");

			}else
			{
					//followValues[5] =
				//	Debug.Log("Roll > 0: " + followValues[5] + "SINISTRA");
			}
				
			
			if (!fingers.IsEmpty && fingers.Count == 5)
			{
					
	/*********************** Ordine Vector4,2,0,1,3
	 * followFingers[]  [2]*
	 * Pollice: 0          *  Pollice: 4
	 * Indice:  1          *  Indice:  2
	 * Medio:   2          *  Medio:   0
	 * Anuce:   3          *  Anuce:   1
	 * Mignolo: 4          *  Mignolo: 3
	 * Mano:    5          *
	 **********************/
				
				//handInScene = true;
				
				for(int i=0;i<fingers.Count;i++)
				{		
					// estraggo tutti gli id della mano con 5 dita	
					followFingersId[i] = hand.Fingers[i].Id;
				    // Visualizzo a video tutte le dita GameObject
					followFingers[i].renderer.enabled = true;
					// Prelievo i valori dei vettori creati dalle dita
                    followVector[i] = hand.Fingers[i].TipPosition.ToUnityTranslated();
					
					//Debug.Log("I: " + i + " FollowVector: " + followVector[i]);
                    // Tutte le dita GameObject vengono posizionate nello spazio di unity
                    followFingers[i].transform.position = followVector[i];	
					followValues[i]  = followFingers[i].transform.position.y * 180.0f / (float)Mathf.PI;
					// se la posizione y delle dita è < della posizione del palmo e se i valori sono positivi
					if((posizioneMano + tollerance) > followValues[i] && posizioneMano > 0 && followValues[i] > 0)
					{
							followValues[i] = (posizioneMano+tollerance)-followValues[i];
							Debug.Log("PosizioneMano: " + posizioneMano + " Dito: " + followValues[i]);
					}
					else
					{
			     		followValues[i] = 0;
			     		Debug.Log("Il Dito "+i+" ha superato la mano pur avendo tolleranza "+ tollerance);	
					}
					
					// se il valore supera i 180 gradi assume il valore massimo
					if(followValues[i]>180)
					{
						followValues[i] = 180;	
					}
					
					// il valore per essere trasmesso serialmente deve essere in un range tra 0 e 90
					followValues[i] /= 2;	
				}

					
//Debug.Log("Pollice: "+followFingersId[4]+" Indice: "+followFingersId[2]+" Medio: "+followFingersId[0]+" AnulareN: "+followFingersId[1]+" Mignolo: "+followFingersId[3]);		

//Debug.Log("PolliceN: "+(int)followValues[4]+" IndiceN: "+(int)followValues[2]+" MedioN: "+(int)followValues[0]+" AnulareN: "+(int)followValues[1]+" MignoloN: "+(int)followValues[3]+" ManoN: "+(int)posizioneMano);		
//Debug.Log("PolliceN: "+(int)followValues[4]+" IndiceN: "+(int)followValues[2]+" MedioN: "+(int)followValues[0]+" AnulareN: "+(int)followValues[1]+" MignoloN: "+(int)followValues[3]+" ManoN: "+(int)posizioneMano);		
					
	}
	
	/*if(!fingers.IsEmpty && fingers.Count == 4)
	{
		// fingers.Count+1 è dato dal fatto che per poter effettuare il controllo nella scena 
		// ci devono essere 4 dita presenti , per per il confronto software bisogna analizzare 
		// tutte e 5 le dita per scoprire qual'è quella mancante
		for(int i=0;i<fingers.Count+1;i++)
		{
			followFingersIdFour[i] = hand.Fingers[i].Id;
			
			if(followFingersId[i] != followFingersIdFour[i])
			{
				fingerHide = i;		
			}
			
		}
	}
	*/
//		Debug.Log("Pollice5: "+followFingersId[4]+" Indice5: "+followFingersId[2]+" Medio5: "+followFingersId[0]+" AnulareN5: "+followFingersId[1]+" Mignolo5: "+followFingersId[3]);		
//		Debug.Log("Pollice4: "+followFingersIdFour[3]+" Indice4: "+followFingersIdFour[2]+" Medio4: "+followFingersIdFour[0]+" AnulareN4: "+followFingersIdFour[1]+" Mignolo4: "+followFingersIdFour[4]);		
				
					
/*		switch(fingerHide)
		{
			case 0:
				// medio
				Debug.Log("Medio: "+fingerHide);		
			break;
						
			case 1:
				// anulare
				Debug.Log("Anulare: "+fingerHide);		
			break;
						
			case 2:
				// indice
				Debug.Log("Indice: "+fingerHide);		
			break;
						
			case 3:
				// mignolo
				Debug.Log("Mignolo: "+fingerHide);		
			break;
						
			case 4:
				// pollice
				Debug.Log("Pollice: "+fingerHide);		
			break;						
						
		}
*/
	
				
	if(fingers.Count < 5)
	{
		//NON CI SONO DITA NELLA SCENA , MA LA MANO SI QUINDI INVIARE SUL SERIALE VALORI A 0
					
	//	handInScene = false;
					
		for(int i=0;i<5;i++)
		{
			followFingers[i].renderer.enabled = false;
			// mettendo a zero tutti i valori ,i valori della mano ci sono ancora
			followValues[i] = 0;

						// Anche se la mano c'è ancora non deve essere più visualizzata

						followFingers[5].renderer.enabled = false;
						posizioneMano = 0;
		}
	
	}
				
					
}
else
{
     // SPOSTATO
	//followFingers[5].renderer.enabled = false;
	//posizioneMano = 0;
}
	}
}
	
	

void Start()
{
	  controller = new Controller ();

		for(int i=0;i<6;i++)
		{
			switch(i)
			{
			case 0:
				followFingers[0] = GameObject.FindGameObjectWithTag("pollice");  
			break;
			case 1:
				followFingers[1] = GameObject.FindGameObjectWithTag("indice");
			break;
			case 2:
				followFingers[2] = GameObject.FindGameObjectWithTag("medio");
			break;
			case 3:
				followFingers[3] = GameObject.FindGameObjectWithTag("anuce");
			break;
			case 4:
				followFingers[4] = GameObject.FindGameObjectWithTag("mignolo");
			break;
			case 5:
				followFingers[5] = GameObject.FindGameObjectWithTag("mano");
			break;

			}
		}

		for(int r=0;r<6;r++)
		{
			followValues[r] = 1;
		}
}


  void Update() 
  {
	    OnFrame(controller);
		
/*		
 *******************SIMPLE DEBUG**************************************************************************************************************************
 * 
				    if(followValues[4]>45)
					{
						FollowSerial.sendAllProtocol(0,0,0,0,90,0);
					}
		            else
			        {
						FollowSerial.sendAllProtocol(0,0,0,0,0,0);
					}
		
					if((int)followValues[2]>45)
					{
						FollowSerial.sendAllProtocol(90,0,0,0,0,0);
					}

					if((int)followValues[0]>45)
					{
						FollowSerial.sendAllProtocol(0,90,0,0,0,0);
					}

					if((int)followValues[1]>45)
					{
						FollowSerial.sendAllProtocol(0,0,90,0,0,0);
					}

					if((int)followValues[3]>45)
					{
						FollowSerial.sendAllProtocol(0,0,0,90,0,0);
					}
		*/

  }
}
