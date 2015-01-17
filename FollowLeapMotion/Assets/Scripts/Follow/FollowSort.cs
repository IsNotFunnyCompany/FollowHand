using UnityEngine;
using System.Collections;

public class FollowSort : MonoBehaviour {

	private float[] dita;

	void Start ()
	{
/*		dita = new float[5];
		dita [0] = 34.0f;
		dita [1] = 12.0f;
		dita [2] = 67.0f;
		dita [3] = 2.0f;
		dita [4] = 44.0f;
*/
	}
	

	void Update () 
	{

	}
	
	public FollowSort(float[] fingers)
	{
		this.dita = fingers;
		followSort (dita);
	}



	/*
                ██████╗  ██████╗ ██╗   ██╗██████╗ ██╗     ███████╗███████╗ ██████╗ ██████╗ ████████╗
                ██╔══██╗██╔═══██╗██║   ██║██╔══██╗██║     ██╔════╝██╔════╝██╔═══██╗██╔══██╗╚══██╔══╝
                ██████╔╝██║   ██║██║   ██║██████╔╝██║     █████╗  ███████╗██║   ██║██████╔╝   ██║   
                ██╔══██╗██║   ██║██║   ██║██╔══██╗██║     ██╔══╝  ╚════██║██║   ██║██╔══██╗   ██║   
                ██████╔╝╚██████╔╝╚██████╔╝██████╔╝███████╗███████╗███████║╚██████╔╝██║  ██║   ██║   
                ╚═════╝  ╚═════╝  ╚═════╝ ╚═════╝ ╚══════╝╚══════╝╚══════╝ ╚═════╝ ╚═╝  ╚═╝   ╚═╝   
	 */



	private void followSort(float []ditaMano) 
	{

		for(int i=0;i<ditaMano.Length;i++)
		{
			bool fenomenoScambio = false;

			for(int j=0;j<ditaMano.Length-1;j++)
			{
				if(ditaMano[j] > ditaMano[j+1])	
				{
					float ditaJnormal  = ditaMano[j];

					ditaMano[j] = ditaMano[j+1];
					ditaMano[j+1] = ditaJnormal;

					fenomenoScambio = true;
				}
			}

			if(!fenomenoScambio)
			{
				break;
			} 
		}
	}


	public float[] getFingers()
	{
		return dita;
	}

    
}