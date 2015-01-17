using UnityEngine;
using System.Collections;

public class FollowcolorCube : MonoBehaviour 
{
	public Color colorRed  = Color.black;
	public Color colorBlue = Color.white;
	public float duration = 1.0F;
	
	void Update()
	{
		float lerp = Mathf.PingPong(Time.time, duration) / duration;
		renderer.material.color = Color.Lerp(colorRed, colorBlue, lerp);
	}
}
