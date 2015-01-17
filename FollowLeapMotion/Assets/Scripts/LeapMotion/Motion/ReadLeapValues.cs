using UnityEngine;
using System.Collections;

public class ReadLeapValues : MonoBehaviour {
	
	// POSITIVE TIME
	public int count = 0;
	
	public int pollice = 0;
	public int indice  = 0;
	public int medio   = 0;
	public int anuce   = 0;	
	public int mignolo = 0;	
	
	// NEGATIVE TIME
	public int NegativeCount = 0;
	
	public int NegativePollice = 0;
	public int NegativeIndice  = 0;
	public int NegativeMedio   = 0;
	public int NegativeAnuce   = 0;	
	public int NegativeMignolo = 0;

	// GuiTEXT
	public GUIText polliceGUI;
	public GUIText indiceGUI;
	public GUIText medioGUI;
	public GUIText anuceGUI;	
	public GUIText mignoloGUI;
	public GUIText manoGUI;
	
	void Start () 
	{
	
	}
	
	void Update ()
	{

	    if((int)Time.time % 2 == 0)
		{
			
/************************
 * Positive values Time *
 ************************/
			
			pollice += (int)VanquishMasterLeap.followValues[4];
			indice  += (int)VanquishMasterLeap.followValues[2];
			medio   += (int)VanquishMasterLeap.followValues[0];
			anuce   += (int)VanquishMasterLeap.followValues[1];
			mignolo += (int)VanquishMasterLeap.followValues[3];
			
			count++;
//			Debug.Log("Pollice: "+VanquishMasterLeap.followValues[4]+" Indice: "+VanquishMasterLeap.followValues[2]+" Medio: "+VanquishMasterLeap.followValues[0]+" Anulare: "+VanquishMasterLeap.followValues[1]+" Mignolo: "+VanquishMasterLeap.followValues[3]+" Mano: "+VanquishMasterLeap.posizioneMano+" Time: " + Time.time);		
   
/************************
 * Negative values Time *
 ***********************/
			
			if(NegativePollice > 0 && NegativeIndice > 0 && NegativeMedio > 0 && NegativeAnuce > 0 && NegativeMignolo > 0 && NegativeCount > 0)
			{
				NegativePollice /= NegativeCount;
				NegativeIndice  /= NegativeCount;
				NegativeMedio   /= NegativeCount;
				NegativeAnuce   /= NegativeCount;
				NegativeMignolo /= NegativeCount;
				
Debug.Log("PolliceNegative: "+NegativePollice+"  IndiceNegative: "+NegativeIndice+"  MedioNegative: "+NegativeMedio+"  AnulareNegative: "+NegativeAnuce+"  MignoloNegative: "+NegativeMignolo);
			    FollowSerial.sendAllProtocol(NegativeIndice,NegativeMedio,NegativeAnuce,NegativeMignolo,NegativePollice,0);
			
				polliceGUI.text = "Pollice "+pollice;
				indiceGUI.text  = "Indice "+indice;
				medioGUI.text   = "Medio "+medio;
				anuceGUI.text   = "Anulare "+anuce;
				mignoloGUI.text = "Mignolo "+mignolo;
				manoGUI.text    = "Mano";

			}
			
			NegativePollice = 0;
			NegativeIndice  = 0;
			NegativeMedio   = 0;
			NegativeAnuce   = 0;
			NegativeMignolo = 0;
			
			NegativeCount = 0;
			
	    }
		else
	    {
			
/************************
 * Negative values Time *
 ************************/
			
			NegativePollice += (int)VanquishMasterLeap.followValues[4];
			NegativeIndice  += (int)VanquishMasterLeap.followValues[2];
			NegativeMedio   += (int)VanquishMasterLeap.followValues[0];
			NegativeAnuce   += (int)VanquishMasterLeap.followValues[1];
			NegativeMignolo += (int)VanquishMasterLeap.followValues[3];
			
			NegativeCount++;
			
/************************
 * Positive values Time *
 ************************/
			
			if(pollice > 0 && indice > 0 && medio > 0 && anuce > 0 && mignolo > 0 && count > 0)
			{
				pollice /= count;
				indice  /= count;
				medio   /= count;
				anuce   /= count;
				mignolo /= count;
				
Debug.Log("Pollice: "+pollice+"  Indice: "+indice+"  Medio: "+medio+"  Anulare: "+anuce+"  Mignolo: "+mignolo);
//			    FollowSerial.sendAllProtocol(indice,medio,anuce,mignolo,pollice,0);
			
				polliceGUI.text = "Pollice "+pollice;
				indiceGUI.text  = "Indice "+indice;
				medioGUI.text   = "Medio "+medio;
				anuceGUI.text   = "Anulare "+anuce;
				mignoloGUI.text = "Mignolo "+mignolo;
				manoGUI.text    = "Mano";

			}
			
			pollice = 0;
			indice  = 0;
			medio   = 0;
			anuce   = 0;
			mignolo = 0;
			
			count = 0;
	    }
	
		
	}
}

/*
 using UnityEngine;
using System.Collections;

public class ReadLeapValues : MonoBehaviour {

	public int count = 0;
	
	public int pollice = 0;
	public int indice  = 0;
	public int medio   = 0;
	public int anuce   = 0;	
	public int mignolo = 0;	
	
	void Start () 
	{
	
	}
	
	
	void Update ()
	{
	    if((int)Time.time % 2 == 0)
		{
			pollice += (int)VanquishMasterLeap.followValues[4];
			indice  += (int)VanquishMasterLeap.followValues[2];
			medio   += (int)VanquishMasterLeap.followValues[0];
			anuce   += (int)VanquishMasterLeap.followValues[1];
			mignolo += (int)VanquishMasterLeap.followValues[3];
			
			count++;
//			Debug.Log("Pollice: "+VanquishMasterLeap.followValues[4]+" Indice: "+VanquishMasterLeap.followValues[2]+" Medio: "+VanquishMasterLeap.followValues[0]+" Anulare: "+VanquishMasterLeap.followValues[1]+" Mignolo: "+VanquishMasterLeap.followValues[3]+" Mano: "+VanquishMasterLeap.posizioneMano+" Time: " + Time.time);		
   
	    }
		else
	    {
			if(pollice > 0 && indice > 0 && medio > 0 && anuce > 0 && mignolo > 0 && count > 0)
			{
				pollice /= count;
				indice  /= count;
				medio   /= count;
				anuce   /= count;
				mignolo /= count;
				
		//		Debug.Log("PolliceO: "+pollice+"  IndiceO: "+indice+"  MedioO: "+medio+"  AnulareO: "+anuce+"  MignoloO: "+mignolo);
			    FollowSerial.sendAllProtocol(indice,medio,anuce,mignolo,pollice,0);
			
			}
			
			pollice = 0;
			indice  = 0;
			medio   = 0;
			anuce   = 0;
			mignolo = 0;
			
			count = 0;
	    }
	
		
	}
}


 */