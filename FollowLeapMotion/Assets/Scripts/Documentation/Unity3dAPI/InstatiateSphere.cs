using UnityEngine;
using System.Collections;

public class InstatiateSphere : MonoBehaviour {

	public Transform bullet; 

	void Start ()
	{
		//Instantiate(bullet, new Vector3(2.0F, 0, 0), Quaternion.identity);
	}

	void Update () 
	{
		Instantiate(bullet, new Vector3(2.0F, 0, 0), Quaternion.identity);
	}
}
