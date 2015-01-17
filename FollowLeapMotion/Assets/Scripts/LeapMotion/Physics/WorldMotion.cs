using UnityEngine;
using System.Collections;

public class WorldMotion : MonoBehaviour {

	private LeapMaster leapMaster;

	void Start() 
	{
		if(leapMaster == null)
		{
			leapMaster = (GameObject.FindGameObjectWithTag("LeapMotion")as GameObject).GetComponent(typeof(LeapMaster))as LeapMaster;
		}
	}

	void Update()
	{
		if(leapMaster != null)
		{
			if(leapMaster.leapPointerAvailible)
			{
				this.transform.position = leapMaster.leapPointerPositionWorld;

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
