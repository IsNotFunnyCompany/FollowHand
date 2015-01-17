using UnityEngine;
using System.Collections;

public class FollowMouse : MonoBehaviour {
	
	// numero tocchi
/*	public int pollice = 0;
	public int indice  = 0;
	public int medio   = 0;
	public int anuce   = 0;
	public int mignolo = 0;
	public int mano    = 0; 
*/
	public int[] send;

	void Start ()
	{
		send = new int[6];
	}
	
	void Update () 
	{
	    if(Input.GetMouseButton(0))
	    {
	        RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			
			if(Physics.Raycast(ray,out hit))
			{
	            switch(hit.collider.name)
				{
				    case "PolliceON":
					
					send[4] = 90;
					Debug.Log("PolliceON");
					
					break;

				    case "PolliceOFF":
					
					send[4] = 0;
					Debug.Log("PolliceOFF");
					
					break;

                    case "IndiceON":
					
					send[0] = 90;
					Debug.Log("IndiceON");
					
					break;

				    case "IndiceOFF":
					
					send[0] = 0;
					Debug.Log("IndiceOFF");
					
					break;
					
		            case "MedioON":
					
					send[1] = 90;
					Debug.Log("MedioON");
					
					break;

				    case "MedioOFF":
					
					send[1] = 0;
					Debug.Log("MedioOFF");
					
					break;

					case "AnulareON":
					
					send[2] = 90;
					Debug.Log("AnuceON");
					
					break;

				    case "AnulareOFF":
					
					send[2] = 0;
					Debug.Log("AnuceOFF");
					
					break;
					
					case "MignoloON":
					
					send[3] = 90;
					Debug.Log("MignoloON");
					
					break;

				    case "MignoloOFF":
					
					send[3] = 0;
					Debug.Log("MignoloOFF");
					
					break;

					case "ManoON":
					
					send[5] = 90;
					Debug.Log("ManoON");
					
					break;

				    case "ManoOFF":
					
					send[5] = 0;
					Debug.Log("ManoOFF");
					
					break;

				    case "reset":
					
					FollowSerial.sendAllProtocol(0,0,0,0,0,0);
					for(int i=0;i<5;i++)
					{
						send[i] = 0;
					}
					
					break;
					
				    case "HandClose":
					
			      //  FollowSerial.sendAllProtocol(90,90,90,90,0,0);
				//	FollowSerial.sendAllProtocol(send[0],send[1],send[2],send[3],send[4],send[5]);
					for(int i=0;i<4;i++)
					{
						send[i] = 90;
					}
				    FollowSerial.sendAllProtocol(send[0],send[1],send[2],send[3],send[4],send[5]);	
				    break;
					
	            }
				
				FollowSerial.sendAllProtocol(send[0],send[1],send[2],send[3],send[4],send[5]);
        	}

			Debug.Log ("Pollice: "+send[4]+" Indice: "+send[0]+" Medio: "+send[1]+" Anuce: "+send[2]+" Mignolo: "+send[3]+" Mano: "+send[5]);
			//FollowSerial.sendAllProtocol(send[0],send[1],send[2],send[3],send[4],send[5]);
	    }

	//	FollowSerial.sendAllProtocol ();

	}
}
