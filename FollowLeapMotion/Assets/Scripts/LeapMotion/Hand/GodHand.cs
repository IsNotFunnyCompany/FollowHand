using UnityEngine;
using System.Collections;
using Leap;

public class GodHand : MonoBehaviour {

//--PUBLIC:
	public GameObject []fingers;
	public GameObject []colliders;

//--PRIVATE:
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
		Hand firstHand = leapMaster.manoInPrimoPiano();

		if(firstHand.IsValid)
		{
			Vector3[] fingersPosition     = leapMaster.getWorldFingerPosition(firstHand);
			gameObject.transform.position = firstHand.PalmPosition.ToUnityTranslated();

			if(gameObject.renderer.enabled != true)
			{
				gameObject.renderer.enabled = true;
			}

			for(int i = 0;i < fingers.GetLength(0);i++)
			{
				if(i < fingersPosition.GetLength(0))
				{
					fingers[i].transform.position = fingersPosition[i];

					if(fingers[i].renderer.enabled == false)
					{
						fingers[i].renderer.enabled = true;
					}

					if(colliders != null && i < colliders.GetLength(0))
					{
						(colliders[i].GetComponent(typeof(SphereCollider))as SphereCollider).enabled = true;
					}
				}
				else
				{
					fingers[i].renderer.enabled = false;

					if(colliders != null && i < colliders.GetLength(0))
					{
						(colliders[i].GetComponent(typeof(SphereCollider))as SphereCollider).enabled = true;
					}
				}
			}
		}
		else
		{
			gameObject.renderer.enabled = false;

			foreach(GameObject finger in fingers)
			{
				if(finger.renderer.enabled == true)
				{
					finger.renderer.enabled = false;
				}
			}

		}
	}
}
