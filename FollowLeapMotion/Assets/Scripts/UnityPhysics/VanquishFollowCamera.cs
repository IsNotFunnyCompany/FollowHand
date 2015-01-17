using UnityEngine;
using System.Collections;

/*

          _____                    _____                    _____                    _____                    _____          
         /\    \                  /\    \                  /\    \                  /\    \                  /\    \         
        /::\    \                /::\    \                /::\____\                /::\    \                /::\    \        
       /::::\    \              /::::\    \              /::::|   |               /::::\    \              /::::\    \       
      /::::::\    \            /::::::\    \            /:::::|   |              /::::::\    \            /::::::\    \      
     /:::/\:::\    \          /:::/\:::\    \          /::::::|   |             /:::/\:::\    \          /:::/\:::\    \     
    /:::/  \:::\    \        /:::/__\:::\    \        /:::/|::|   |            /:::/__\:::\    \        /:::/__\:::\    \    
   /:::/    \:::\    \      /::::\   \:::\    \      /:::/ |::|   |           /::::\   \:::\    \      /::::\   \:::\    \   
  /:::/    / \:::\    \    /::::::\   \:::\    \    /:::/  |::|___|______    /::::::\   \:::\    \    /::::::\   \:::\    \  
 /:::/    /   \:::\    \  /:::/\:::\   \:::\    \  /:::/   |::::::::\    \  /:::/\:::\   \:::\    \  /:::/\:::\   \:::\____\ 
/:::/____/     \:::\____\/:::/  \:::\   \:::\____\/:::/    |:::::::::\____\/:::/__\:::\   \:::\____\/:::/  \:::\   \:::|    |
\:::\    \      \::/    /\::/    \:::\  /:::/    /\::/    / ~~~~~/:::/    /\:::\   \:::\   \::/    /\::/   |::::\  /:::|____|
 \:::\    \      \/____/  \/____/ \:::\/:::/    /  \/____/      /:::/    /  \:::\   \:::\   \/____/  \/____|:::::\/:::/    / 
  \:::\    \                       \::::::/    /               /:::/    /    \:::\   \:::\    \            |:::::::::/    /  
   \:::\    \                       \::::/    /               /:::/    /      \:::\   \:::\____\           |::|\::::/    /   
    \:::\    \                      /:::/    /               /:::/    /        \:::\   \::/    /           |::| \::/____/    
     \:::\    \                    /:::/    /               /:::/    /          \:::\   \/____/            |::|  ~|          
      \:::\    \                  /:::/    /               /:::/    /            \:::\    \                |::|   |          
       \:::\____\                /:::/    /               /:::/    /              \:::\____\               \::|   |          
        \::/    /                \::/    /                \::/    /                \::/    /                \:|   |          
         \/____/                  \/____/                  \/____/                  \/____/                  \|___|          


                                                                                 Alex Voicu Developer 2014/03/10

 */

/*

    IDEE:
         - quando con il mouse ci si sposta a sinistra o a destra far si che la telecamera si sposti leggeremente verso quella direzione

 */

public class FollowAnimatorCamera : MonoBehaviour {


//	public GameObject robotMain;
	public Transform  normalPosition;
	public Transform  firePosition;
	public Transform  comunicationPosition;
	public Transform  ambientPosition;

	public bool triggerTranslate = false;

	public float      cameraSpeed = 3f;


	private VanquishAnimatorMain animatorMain;

	void Start() 
	{
		// animatorMain = robotMain.GetComponent<VanquishAnimatorMain>();
	}
	

	void FixedUpdate()
	{
		if(triggerTranslate)
		{
			cameraPosition(ambientPosition);
		}



		if(Input.GetMouseButton(0))
		{
			cameraPosition(firePosition);
		}
		else if(Input.GetMouseButton(1))
		{
			cameraPosition(comunicationPosition);
		}
		else
		{
			cameraPosition(normalPosition);
		}
	}

	/*
         Per snellire un po' il codice utilizzare funzioni e ogni modo o tecnica per rendere più efficente l'applicazione:

         Un applicazione più snella è , più è facile da gestire e modificare.
	*/

	public void cameraPosition(Transform transformPosition)
	{
		transform.position = Vector3.Lerp(transform.position , transformPosition.position , Time.deltaTime * cameraSpeed);
		transform.forward  = Vector3.Lerp(transform.forward  , transformPosition.forward  , Time.deltaTime * cameraSpeed);
	}

	/*public void movementCamera(float direction)
	{
		if(direction < -0.5f){ transform.Rotate = -2; }
		if(direction >  0.5f){  transform.Rotate = 2;  }
	}
	*/	
}



































