using UnityEngine;
using System.Collections;

public class DesktopMotion : MonoBehaviour {
		
	private Camera camera;
	private LeapMaster leapMaster;

	void Start() 
	{
		if(camera == null)
		{
			camera = (GameObject.FindGameObjectWithTag("MainCamera")as GameObject).GetComponent(typeof(Camera)) as Camera;
		}

		if(leapMaster == null)
		{
			leapMaster = (GameObject.FindGameObjectWithTag("LeapMotion")as GameObject).GetComponent(typeof(LeapMaster)) as LeapMaster;
		}

	}

	void Update() 
	{
		if(leapMaster != null)
		{
			if(leapMaster.leapPointerAvailible)
			{
				leapMaster.leapScreenToWorldDistance = 3.0f;
				this.transform.position              = leapMaster.leapPointerPositionScreenToWorld;

				if(!renderer.enabled)
				{
					renderer.enabled = true;
				}
			}
			else
			{
				renderer.enabled = false;
			}
		}
	}
}
