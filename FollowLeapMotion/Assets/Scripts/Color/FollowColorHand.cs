using UnityEngine;
using System.Collections;

public class FollowColorHand : MonoBehaviour 
{
	public Color colorRed  = Color.red;
	public Color colorBlue = Color.blue;
	public float duration = 1.0F;

	void Update()
	{
		float lerp = Mathf.PingPong(Time.time, duration) / duration;
		renderer.material.color = Color.Lerp(colorRed, colorBlue, lerp);
	}
}
