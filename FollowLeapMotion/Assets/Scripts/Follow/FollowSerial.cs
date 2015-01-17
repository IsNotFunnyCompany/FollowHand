using UnityEngine;
using System.Collections;
using System.IO.Ports;
using System.Threading;


public class FollowSerial : MonoBehaviour {
	
	public static SerialPort serialPort = new SerialPort("COM3", 9600);

	float timePassed = 0.0f;

	void Start () 
	{
		OpenConnection();
	}

	void Update ()
	{
		//FollowSerial.sendAllProtocol(14,63,84,90,23,03);
	}
	
	public void OpenConnection() 
	{
		if (serialPort != null) 
		{
			if (serialPort.IsOpen) 
			{
				serialPort.Close();
			}
			else 
			{

				/*
				 * PROVARE A MODIFICARE IL READTIMEOUT
				 * */
				try{

				     serialPort.Open(); 
				     serialPort.ReadTimeout = 16; 

				}catch(System.IO.IOException exception)
				{
					Debug.Log("Eccezione PORTA Open()");
				}

			}
		}
	}
	
	void OnApplicationQuit() 
	{
		serialPort.Close();
	}

	public static void sendAllProtocol(int indice,int medio,int anuce,int mignolo,int pollice,int mano)
	{
		string writeString = "";
		int []protocolValues = new int[6];

		protocolValues [0] = indice;
		protocolValues [1] = medio;
		protocolValues [2] = anuce;
		protocolValues [3] = mignolo;
		protocolValues [4] = pollice;
		protocolValues [5] = mano;

		if(indice <= 90 && medio <= 90 && anuce <= 90 && mignolo <= 90 && pollice <= 90 && mano <= 90)
	    {
			for(int i=0;i<protocolValues.Length;i++)
			{
				int[] scomposto = new int[2];
				scomposto = scomposizione(protocolValues[i]);

				if(protocolValues[i] < 10)
				{
					if(protocolValues[i] < 1)
					{
						writeString += "aa";
					}else
					{
					    writeString += "a"+singleProtocolTrasform(protocolValues[i]);
				    }
				}
				else
				{
					writeString += singleProtocolTrasform(scomposto[0]) + singleProtocolTrasform(scomposto[1]);
				}
			}

			try{

		    //	Debug.Log("Protocollo: " + writeString);
				serialPort.Write(writeString);

			}catch(System.InvalidOperationException)
			{
			//	Debug.Log("La porta COM4 è chiusa");
			}		 
		}
		else
		{
			if(indice >= 90 || medio >= 90 || anuce >= 90 || mignolo >= 90 || pollice >= 90 || mano >= 90)
			{
                Debug.Log("Uno dei valori supera i 90 , ricontrolla la divisione");
			}
			
		}
	 
	}
	
	public static int[] scomposizione(int item)
	{
		int[] value = new int[2];

		if(item >= 10)
		{
			value[0] = item / 10;
			value[1] = item - (value[0] * 10);

		}
		
		return value;
	}


	public static string singleProtocolTrasform(int item)
	{
		string itemReturn = "";

		switch(item)
		{
		   case 0:
			itemReturn = "a";
		   break;

		   case 1:
			itemReturn = "b";
		   break;

		   case 2:
			itemReturn = "c";
		   break;

		   case 3:
			itemReturn = "d";
		   break;

		   case 4:
			itemReturn = "e";
		   break;

		   case 5:
			itemReturn = "f";
		   break;

		   case 6:
			itemReturn = "g";
		   break;

		   case 7:
			itemReturn = "h";
		   break;

		   case 8:
			itemReturn = "i";
		   break;

		   case 9:
			itemReturn = "l";
		   break;
		}

		return itemReturn;

	}
}
