using UnityEngine;
using System.Collections;

public class FourPosition : MonoBehaviour {

	public int indice = 0; 
	public int medio = 0;
	public int anuce = 0;
	public int mignolo = 0;
	public int pollice = 0;
	
	private SendPosition position;
	
	void Start()
	{
		position = (GameObject.FindGameObjectWithTag("LeapMotion")as GameObject).GetComponent (typeof(SendPosition))as SendPosition;
	}
	
	void OnTriggerStay(Collider collider)
	{
		switch(collider.gameObject.name)
		{
		    case "Indice":
			               position.medio = 70;
		    break;
			               			
			case "Medio":
			               position.pollice = 70;	
		    break;
			
			case "Anuce":
			               position.indice = 70;			
		    break;
			
			case "Mignolo":
			               position.anuce = 70;			
		    break;
			
			case "Pollice":
			               position.mignolo = 70;			
		    break;
		}
		
	}
}
