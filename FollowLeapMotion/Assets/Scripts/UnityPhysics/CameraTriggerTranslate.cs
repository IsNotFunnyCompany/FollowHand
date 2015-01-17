using UnityEngine;
using System.Collections;

public class CameraTriggerTranslate : MonoBehaviour {

	public GameObject cameraObject;

	private VanquishFollowCamera camera;

	void Start () {
	
		camera = cameraObject.GetComponent<VanquishFollowCamera>();

	}
	

	void OnTriggerEnter(Collider collider)
	{
		//Debug.Log("Entrato: " + collider.gameObject.name);
		camera.triggerTranslate = true;
	}

	void OnTriggerExit(Collider collider)
	{
		camera.triggerTranslate = false;	
	}


	void Update () {
	
	}
}
