using UnityEngine;
using System.Collections;

public class ThreePosition : MonoBehaviour {

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
			               position.medio = 45;
		    break;
			               			
			case "Medio":
			               position.pollice = 45;	
		    break;
			
			case "Anuce":
			               position.indice = 45;			
		    break;
			
			case "Mignolo":
			               position.anuce = 45;			
		    break;
			
			case "Pollice":
			               position.mignolo = 45;			
		    break;
		}
		
	}
}
