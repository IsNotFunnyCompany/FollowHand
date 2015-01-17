using UnityEngine;
using System.Collections;

public class ZeroPosition : MonoBehaviour {
	
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
			               position.medio = 0;
		    break;
			               			
			case "Medio":
			               position.pollice = 0;	
		    break;
			
			case "Anuce":
			               position.indice = 0;			
		    break;
			
			case "Mignolo":
			               position.anuce = 0;			
		    break;
			
			case "Pollice":
			               position.mignolo = 0;			
		    break;
		}
		
	}
	
}
