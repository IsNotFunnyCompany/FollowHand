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


public class LeapCollider : MonoBehaviour
{

	private Controller controller;

	public static GameObject[] followFingers = new GameObject[6]; 
	public static Vector3[]    followVector  = new Vector3[5];
	
	
	
public static void OnFrame(Controller controller)
{
	if(controller.IsConnected)
	{
	   Frame frame = controller.Frame();

		if (!frame.Hands.IsEmpty) 
		{

			Hand hand = frame.Hands[0];
			FingerList fingers = hand.Fingers;
			/*	
			Debug.Log("1: " + hand.Fingers[0] + " 2: "+hand.Fingers[1]+ " 3: "+hand.Fingers[2]+ " 4: "+hand.Fingers[3]+ " 5: "+hand.Fingers[4] );
				
			if(!hand.Fingers[4].IsValid)
			{
			    Debug.Log("************************************************************************************************");
			}
			*/	
			if (!fingers.IsEmpty)
			{		
				followFingers[5].transform.position = hand.PalmPosition.ToUnityTranslated();
			    followFingers[5].renderer.enabled   = true;
					
					//if(hand.Fingers[i] == 0)
					
				for(int i=0;i<fingers.Count;i++)
				{		
				    // Visualizzo a video tutte le dita GameObject
					followFingers[i].renderer.enabled = true;
					// Prelievo i valori dei vettori creati dalle dita
                    followVector[i] = hand.Fingers[i].TipPosition.ToUnityTranslated();
                    followFingers[i].transform.position = followVector[i];	
				}			
					
				for(int i=0;i<5;i++)
				{
					if(!hand.Fingers[i].IsValid)
			        {
			             followFingers[i].renderer.enabled = false;
			        }
				}
            }
			else
			{

				for(int i=0;i<5;i++)
				{		
				    // Visualizzo a video tutte le dita GameObject
					followFingers[i].renderer.enabled = false;
				}	
			}
					
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
}

  void Update() 
  {
	    OnFrame(controller);
  }
}
