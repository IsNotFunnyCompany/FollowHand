using UnityEngine;
using System.Collections;

public class SendPosition : MonoBehaviour {

	public int pollice = 0;
	public int indice  = 0;
	public int medio   = 0;
	public int anuce   = 0;	
	public int mignolo = 0;	
	
	// GuiTEXT
	public GUIText polliceGUI;
	public GUIText indiceGUI;
	public GUIText medioGUI;
	public GUIText anuceGUI;	
	public GUIText mignoloGUI;
	
	public int positiveCount = 0,negativeCount = 0;
	
	void Start () 
	{
	    FollowSerial.sendAllProtocol(0,0,0,0,0,0);
	}
	
	void Update ()
	{

	    if((int)Time.time % 2 == 0)
		{
	
			positiveCount++;
			if(positiveCount >= 31)
			{
				
				//FollowSerial.sendAllProtocol(pollice,mignolo,medio,indice,anuce,0);
				
				
				// indice = anulare
				// medio = indice
				// anulare = miglolo
				// mignolo = pollice
				// pollice = medio
				
				
				FollowSerial.sendAllProtocol(medio,pollice,indice,anuce,mignolo,0);
				
				polliceGUI.text = pollice.ToString();
				indiceGUI.text  = indice.ToString();
				medioGUI.text   = medio.ToString();
				anuceGUI.text   = anuce.ToString();
				mignoloGUI.text = mignolo.ToString();
				
				
				Debug.Log("Indice: "+indice+" Medio: "+medio+" Anuce: "+anuce+" Mignolo: "+mignolo+" Pollice: "+pollice);
				//Debug.Log("Count Positive:" + positiveCount);
				positiveCount = 0;
			}

	    }
		else
	    {
		
		    negativeCount++;
			if(negativeCount >= 31)
			{
				//FollowSerial.sendAllProtocol(pollice,mignolo,medio,indice,anuce,0);
				
				FollowSerial.sendAllProtocol(medio,pollice,indice,anuce,mignolo,0);
				
				
				polliceGUI.text = pollice.ToString();
				indiceGUI.text  = indice.ToString();
				medioGUI.text   = medio.ToString();
				anuceGUI.text   = anuce.ToString();
				mignoloGUI.text = mignolo.ToString();
				
				Debug.Log("Indice: "+indice+" Medio: "+medio+" Anuce: "+anuce+" Mignolo: "+mignolo+" Pollice: "+pollice);
				//Debug.Log("Count Negative:" + negativeCount);
				negativeCount = 0;
			}			
	    }
	}
}
