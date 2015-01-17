using UnityEngine;
using System.Collections;
using Leap;

/*
      ___       ___           ___           ___           ___           ___           ___           ___           ___           ___     
     /\__\     /\  \         /\  \         /\  \         /\__\         /\  \         /\  \         /\  \         /\  \         /\  \    
    /:/  /    /::\  \       /::\  \       /::\  \       /::|  |       /::\  \       /::\  \        \:\  \       /::\  \       /::\  \   
   /:/  /    /:/\:\  \     /:/\:\  \     /:/\:\  \     /:|:|  |      /:/\:\  \     /:/\ \  \        \:\  \     /:/\:\  \     /:/\:\  \  
  /:/  /    /::\~\:\  \   /::\~\:\  \   /::\~\:\  \   /:/|:|__|__   /::\~\:\  \   _\:\~\ \  \       /::\  \   /::\~\:\  \   /::\~\:\  \ 
 /:/__/    /:/\:\ \:\__\ /:/\:\ \:\__\ /:/\:\ \:\__\ /:/ |::::\__\ /:/\:\ \:\__\ /\ \:\ \ \__\     /:/\:\__\ /:/\:\ \:\__\ /:/\:\ \:\__\
 \:\  \    \:\~\:\ \/__/ \/__\:\/:/  / \/__\:\/:/  / \/__/~~/:/  / \/__\:\/:/  / \:\ \:\ \/__/    /:/  \/__/ \:\~\:\ \/__/ \/_|::\/:/  /
  \:\  \    \:\ \:\__\        \::/  /       \::/  /        /:/  /       \::/  /   \:\ \:\__\     /:/  /       \:\ \:\__\      |:|::/  / 
   \:\  \    \:\ \/__/        /:/  /         \/__/        /:/  /        /:/  /     \:\/:/  /     \/__/         \:\ \/__/      |:|\/__/  
    \:\__\    \:\__\         /:/  /                      /:/  /        /:/  /       \::/  /                     \:\__\        |:|  |    
     \/__/     \/__/         \/__/                       \/__/         \/__/         \/__/                       \/__/         \|__|    


                                                                                       Follow CopyRight 2014
                                                                           Developer:  Alex Voicu

 */



public class LeapMaster : MonoBehaviour {

	public Camera mainCamera; 
	public static float forwardFingerContraint = 0.7f; 

	private static Controller controller = new Controller();
	private static Frame frame           = Frame.Invalid;
	private static bool pointerAvailible = false;
	private float  screenToWorldDistance = 100.0f;

	private Vector2 puntoPosizioneSchermo        = new Vector3(0,0);
	private Vector3 puntoPosizioneMondo          = new Vector3(0,0,0);
	private Vector3 puntoPosizioneMondoSuSchermo = new Vector3(0,0,0);


	/*

      _____                    _____                    _____                    _____                   _______         
     /\    \                  /\    \                  /\    \                  /\    \                 /::\    \        
    /::\    \                /::\    \                /::\____\                /::\    \               /::::\    \       
    \:::\    \              /::::\    \              /::::|   |               /::::\    \             /::::::\    \      
     \:::\    \            /::::::\    \            /:::::|   |              /::::::\    \           /::::::::\    \     
      \:::\    \          /:::/\:::\    \          /::::::|   |             /:::/\:::\    \         /:::/~~\:::\    \    
       \:::\    \        /:::/__\:::\    \        /:::/|::|   |            /:::/__\:::\    \       /:::/    \:::\    \   
       /::::\    \      /::::\   \:::\    \      /:::/ |::|   |           /::::\   \:::\    \     /:::/    / \:::\    \  
      /::::::\    \    /::::::\   \:::\    \    /:::/  |::|___|______    /::::::\   \:::\    \   /:::/____/   \:::\____\ 
     /:::/\:::\    \  /:::/\:::\   \:::\    \  /:::/   |::::::::\    \  /:::/\:::\   \:::\____\ |:::|    |     |:::|    |
    /:::/  \:::\____\/:::/__\:::\   \:::\____\/:::/    |:::::::::\____\/:::/  \:::\   \:::|    ||:::|____|     |:::|    |
   /:::/    \::/    /\:::\   \:::\   \::/    /\::/    / ~~~~~/:::/    /\::/    \:::\  /:::|____| \:::\    \   /:::/    / 
  /:::/    / \/____/  \:::\   \:::\   \/____/  \/____/      /:::/    /  \/_____/\:::\/:::/    /   \:::\    \ /:::/    /  
 /:::/    /            \:::\   \:::\    \                  /:::/    /            \::::::/    /     \:::\    /:::/    /   
/:::/    /              \:::\   \:::\____\                /:::/    /              \::::/    /       \:::\__/:::/    /    
\::/    /                \:::\   \::/    /               /:::/    /                \::/____/         \::::::::/    /     
 \/____/                  \:::\   \/____/               /:::/    /                  ~~                \::::::/    /      
                           \:::\    \                  /:::/    /                                      \::::/    /       
                            \:::\____\                /:::/    /                                        \::/____/        
                             \::/    /                \::/    /                                          ~~              
                              \/____/                  \/____/                                                           


	*/

	public Controller leapController             // un accesso diretto al controller Leap           
	{
		get
		{
			return controller; 
		}
	}

	public Frame leapCurrentFrame                // il più recente Frame letto dal Leap   
	{
		get
		{ 
			return frame; 
		}
	}

	public bool leapPointerAvailible             // c'è un dito rilevato nella scena?
	{
		get
		{ 
			return pointerAvailible; 
		}
	}

	public Vector2 leapPointerPositionScreen     // la posizione 2d del dito nella scena se è stato rilevato
	{
		get 
		{
			return pointerAvailible ? puntoPosizioneSchermo : Vector2.zero;
		}
	}

	public Vector3 leapPointerPositionWorld      // la posizione del dito rilevato nel mondo virtuale
	{
		get 
		{
			return pointerAvailible ? puntoPosizioneMondo : Vector3.zero;
		}
	}
	
	public Vector3 leapPointerPositionScreenToWorld    // la posizione del dito trasportato nel mondo 
	{                                                  // virtuale a una distanza di screenToWorldDistance
		get
		{
			return puntoPosizioneMondoSuSchermo; 
		}
	}

	public float leapScreenToWorldDistance       // la distanza calcolate con leapPointerPositionScreenToWorld
	{                                            // di default è 10.0f
		get
		{
			return screenToWorldDistance;
		}
		set
		{
			screenToWorldDistance = value;
		}
	}


	/*

          _____                    _____                    _____                    _____                    _____                   _______         
         /\    \                  /\    \                  /\    \                  /\    \                  /\    \                 /::\    \        
        /::\    \                /::\    \                /::\    \                /::\    \                /::\    \               /::::\    \       
       /::::\    \              /::::\    \              /::::\    \               \:::\    \               \:::\    \             /::::::\    \      
      /::::::\    \            /::::::\    \            /::::::\    \               \:::\    \               \:::\    \           /::::::::\    \     
     /:::/\:::\    \          /:::/\:::\    \          /:::/\:::\    \               \:::\    \               \:::\    \         /:::/~~\:::\    \    
    /:::/__\:::\    \        /:::/__\:::\    \        /:::/__\:::\    \               \:::\    \               \:::\    \       /:::/    \:::\    \   
    \:::\   \:::\    \      /::::\   \:::\    \      /::::\   \:::\    \               \:::\    \              /::::\    \     /:::/    / \:::\    \  
  ___\:::\   \:::\    \    /::::::\   \:::\    \    /::::::\   \:::\    \               \:::\    \    ____    /::::::\    \   /:::/____/   \:::\____\ 
 /\   \:::\   \:::\    \  /:::/\:::\   \:::\____\  /:::/\:::\   \:::\    \               \:::\    \  /\   \  /:::/\:::\    \ |:::|    |     |:::|    |
/::\   \:::\   \:::\____\/:::/  \:::\   \:::|    |/:::/  \:::\   \:::\____\_______________\:::\____\/::\   \/:::/  \:::\____\|:::|____|     |:::|    |
\:::\   \:::\   \::/    /\::/    \:::\  /:::|____|\::/    \:::\  /:::/    /\::::::::::::::::::/    /\:::\  /:::/    \::/    / \:::\    \   /:::/    / 
 \:::\   \:::\   \/____/  \/_____/\:::\/:::/    /  \/____/ \:::\/:::/    /  \::::::::::::::::/____/  \:::\/:::/    / \/____/   \:::\    \ /:::/    /  
  \:::\   \:::\    \               \::::::/    /            \::::::/    /    \:::\~~~~\~~~~~~         \::::::/    /             \:::\    /:::/    /   
   \:::\   \:::\____\               \::::/    /              \::::/    /      \:::\    \               \::::/____/               \:::\__/:::/    /    
    \:::\  /:::/    /                \::/____/               /:::/    /        \:::\    \               \:::\    \                \::::::::/    /     
     \:::\/:::/    /                  ~~                    /:::/    /          \:::\    \               \:::\    \                \::::::/    /      
      \::::::/    /                                        /:::/    /            \:::\    \               \:::\    \                \::::/    /       
       \::::/    /                                        /:::/    /              \:::\____\               \:::\____\                \::/____/        
        \::/    /                                         \::/    /                \::/    /                \::/    /                 ~~              
         \/____/                                           \/____/                  \/____/                  \/____/                                  


	*/

	public static bool openHand(Hand hand)
	{
		return hand.Fingers.Count > 2;
	}

	public static bool openRelativeHand(Pointable pointFinger,Hand hand)
	{
		return Vector3.Dot (pointFinger.TipPosition.ToUnity () - hand.PalmPosition.ToUnity ().normalized,
		                   hand.Direction.ToUnity ()) > forwardFingerContraint;
		                  
	}

	public static ArrayList ArrayListFingers(Hand hand)
	{
		ArrayList dita = new ArrayList();

		foreach(Finger dito in hand.Fingers)
		{
			if(openRelativeHand(dito,hand))
			{
				dita.Add(dito);
			}
		}

		return dita;
	}

	public static Finger fingerPoint(Hand hand){

		Finger dito = Finger.Invalid;
		ArrayList listaDita = ArrayListFingers(hand);

		if(listaDita.Count > 0)
		{
			float maxAsseZ = float.MaxValue;

			foreach(Finger finger in listaDita)
			{
				if(finger.TipPosition.z < maxAsseZ)
				{
					maxAsseZ = finger.TipPosition.z;
					dito = finger;

				}
			}
		}

		return dito;
	}

	public Vector2[] getScreenFingerPosition(Hand hand)
	{
		Vector2[] arrayFingerPositionToScreen = new Vector2[hand.Fingers.Count];

		for(int i=0;i<hand.Fingers.Count;i++)
		{
			arrayFingerPositionToScreen[i] = leapMotionPositionToScreen(hand.Fingers[i].TipPosition);
		}

		return arrayFingerPositionToScreen;
	}

	public Vector3[] getWorldFingerPosition(Hand hand)
	{
		Vector3[] arrayFingerPositionToWorld = new Vector3[hand.Fingers.Count];

		for(int i=0;i<hand.Fingers.Count;i++)
		{
			arrayFingerPositionToWorld[i] = hand.Fingers[i].TipPosition.ToUnityTranslated();
		}

		return arrayFingerPositionToWorld;
	}

	public Vector2 leapMotionPositionToScreen(Vector motionVector)
	{
		return mainCamera.WorldToScreenPoint(motionVector.ToUnityTranslated());
	}

	public Hand manoInPrimoPiano()
	{
		float MaxAsseZ = float.MaxValue;
		Hand mano = Hand.Invalid;

		foreach(Hand mani in frame.Hands)
		{
			if(mani.PalmPosition.z < MaxAsseZ)
			{
				MaxAsseZ = mani.PalmPosition.z;
				mano = mani;
			}
		}
		return mano;
	}

	/*

           _____                    _____                    _____                _____                _____          
         /\    \                  /\    \                  /\    \              /\    \              |\    \         
        /::\____\                /::\____\                /::\    \            /::\    \             |:\____\        
       /:::/    /               /::::|   |                \:::\    \           \:::\    \            |::|   |        
      /:::/    /               /:::::|   |                 \:::\    \           \:::\    \           |::|   |        
     /:::/    /               /::::::|   |                  \:::\    \           \:::\    \          |::|   |        
    /:::/    /               /:::/|::|   |                   \:::\    \           \:::\    \         |::|   |        
   /:::/    /               /:::/ |::|   |                   /::::\    \          /::::\    \        |::|   |        
  /:::/    /      _____    /:::/  |::|   | _____    ____    /::::::\    \        /::::::\    \       |::|___|______  
 /:::/____/      /\    \  /:::/   |::|   |/\    \  /\   \  /:::/\:::\    \      /:::/\:::\    \      /::::::::\    \ 
|:::|    /      /::\____\/:: /    |::|   /::\____\/::\   \/:::/  \:::\____\    /:::/  \:::\____\    /::::::::::\____\
|:::|____\     /:::/    /\::/    /|::|  /:::/    /\:::\  /:::/    \::/    /   /:::/    \::/    /   /:::/~~~~/~~      
 \:::\    \   /:::/    /  \/____/ |::| /:::/    /  \:::\/:::/    / \/____/   /:::/    / \/____/   /:::/    /         
  \:::\    \ /:::/    /           |::|/:::/    /    \::::::/    /           /:::/    /           /:::/    /          
   \:::\    /:::/    /            |::::::/    /      \::::/____/           /:::/    /           /:::/    /           
    \:::\__/:::/    /             |:::::/    /        \:::\    \           \::/    /            \::/    /            
     \::::::::/    /              |::::/    /          \:::\    \           \/____/              \/____/             
      \::::::/    /               /:::/    /            \:::\    \                                                   
       \::::/    /               /:::/    /              \:::\____\                                                  
        \::/____/                \::/    /                \::/    /                                                  
         ~~                       \/____/                  \/____/                                                   


	 */

	void Start()
	{
		if(mainCamera == null)
		{

			mainCamera = (GameObject.FindGameObjectWithTag("MainCamera") as GameObject).GetComponent(typeof(Camera)) as Camera;

		}
	}

	void Update()
	{
		frame = controller.Frame();

		Hand   firstHand   = manoInPrimoPiano();
		Finger firstFinger = Finger.Invalid;

		if(firstHand.IsValid)
		{
			firstFinger = fingerPoint(firstHand);

			if(firstFinger.IsValid)
			{
				pointerAvailible     = true;
				puntoPosizioneMondo  = firstFinger.TipPosition.ToUnityTranslated();
				// NON FUNZIONA SE LA CAMERA NON E' NELL WORLD ORIGIN

				puntoPosizioneSchermo        = mainCamera.WorldToScreenPoint(leapPointerPositionWorld);
				puntoPosizioneMondoSuSchermo = mainCamera.ScreenToWorldPoint(new Vector3(
					                                                                           leapPointerPositionScreen.x,
					                                                                           leapPointerPositionScreen.y,
					                                                                           screenToWorldDistance
					                                                                        ));
			}
			else
			{
				pointerAvailible = false;
			}

		}


	}


}


