using UnityEngine;
using System.Collections;

public class FollowQWERTY : MonoBehaviour {

	private int[] qwertyState;
	private int[] qwertySend;

	
	public GUIText pollice;
	public GUIText indice;
	public GUIText medio;
	public GUIText anuce;
	public GUIText mignolo;
	public GUIText mano;


	void Start () 
	{
		qwertySend  = new int[6];
		qwertyState = new int[6];

		for(int i = 0;i < 6;i++)
		{
			qwertyState[i] = 1;
			qwertySend[i] = 0; 
		}
	}

	void Update () 
	{
		if(Input.GetKeyUp("q"))
		{
			Debug.Log("q");
			qwertyState[0]++;

			qwertySend[0] = zeroOr_one(qwertyState[0]);
		}

		if(Input.GetKeyDown("q"))
		{
			Debug.Log("q");
			qwertyState[0]++;
			
			qwertySend[0] = zeroOr_one(qwertyState[0]);
		}

		if(Input.GetKeyDown("w"))
		{
			Debug.Log("w");
			qwertyState[1]++;

			qwertySend[1] = zeroOr_one(qwertyState[1]);
		}
	
		if(Input.GetKeyDown("e"))
		{
			Debug.Log("e");
			qwertyState[2]++;

			qwertySend[2] = zeroOr_one(qwertyState[2]);
		}

		if(Input.GetKeyDown("r"))
		{
			Debug.Log("r");
			qwertyState[3]++;

			qwertySend[3] = zeroOr_one(qwertyState[3]);
		}
	
		if(Input.GetKeyDown("t"))
		{
			Debug.Log("t");
			qwertyState[4]++;

			qwertySend[4] = zeroOr_one(qwertyState[4]);
		}
	
		if(Input.GetKeyDown("y"))
		{
			Debug.Log("y");
			qwertyState[5]++;

			qwertySend[5] = zeroOr_one(qwertyState[5]);
		}


		Debug.Log("PolliceSTATE: "+qwertyState[0]+ 
		          " IndiceSTATE: "+qwertyState[1]+
		          " MedioSTATE: "+qwertyState[2]+
		          " AnuceSTATE:"+qwertyState[3]+
		          " MignoloSTATE: "+qwertyState[4]+
		          " ManoSTATE: "+qwertyState[5]);

		Debug.Log("Pollice: "+qwertySend[0]+ 
		          " Indice: "+qwertySend[1]+
		          " Medio: "+qwertySend[2]+
		          " Anuce:"+qwertySend[3]+
		          " Mignolo: "+qwertySend[4]+
		          " Mano: "+qwertySend[5]);

		/*if( (int)Time.time % 2 == 0 || (int) Time.time % 2 != 0)
		{
			Debug.Log("Pollice: "+transformation(qwertyState[0])+ 
			          " Indice: "+transformation(qwertyState[1])+
			          " Medio: "+transformation(qwertyState[2])+
			          " Anuce:"+transformation(qwertyState[3])+
			          " Mignolo: "+transformation(qwertyState[4])+
			          " Mano: "+transformation(qwertyState[5]));

		}*/

	}
	

	public int zeroOr_one(int number)
	{
		if(number % 2 == 0)
		{
			return 90;
		}
		else
		{
			return 0;
		}


	}


}
