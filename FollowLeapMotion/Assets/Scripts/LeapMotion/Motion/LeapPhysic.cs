using UnityEngine;
using System.Collections;
using Leap;

/*
      ___         ___                       ___                       ___     
     /  /\       /__/\          ___        /  /\        ___          /  /\    
    /  /::\      \  \:\        /__/|      /  /:/_      /  /\        /  /:/    
   /  /:/\:\      \__\:\      |  |:|     /  /:/ /\    /  /:/       /  /:/     
  /  /:/~/:/  ___ /  /::\     |  |:|    /  /:/ /::\  /__/::\      /  /:/  ___ 
 /__/:/ /:/  /__/\  /:/\:\  __|__|:|   /__/:/ /:/\:\ \__\/\:\__  /__/:/  /  /\
 \  \:\/:/   \  \:\/:/__\/ /__/::::\   \  \:\/:/~/:/    \  \:\/\ \  \:\ /  /:/
  \  \::/     \  \::/         ~\~~\:\   \  \::/ /:/      \__\::/  \  \:\  /:/ 
   \  \:\      \  \:\           \  \:\   \__\/ /:/       /__/:/    \  \:\/:/  
    \  \:\      \  \:\           \__\/     /__/:/        \__\/      \  \::/   
     \__\/       \__\/                     \__\/                     \__\/    

[+] Le classi statiche non possono implementare interfacce
[]

 */

namespace Leap
{

	interface vectorPhysic		
	{
		Vector3 Flip(Vector vector);
		Vector3 Scale(Vector3 vector);
		Vector3 Offset(Vector3 vector);
		Vector3 ToUnity(this Vector vector);
		Vector3 ToUnityScaled(this Vector vector);
		Vector3 ToUnityTranslated(this Vector vector);
	}
 
	public static class LeapPhysic 
	{
		public static Vector3 inputScale  = new Vector3(0.04f,0.04f,0.04f);
		public static Vector3 inputOffset = new Vector3(0,-8,0);


		private static Vector3 Flip(Vector vector)
		{
			return new Vector3 (vector.x,vector.y,-vector.z);
		}

		private static Vector3 Scale(Vector3 vector)
		{
			return new Vector3(vector.x * inputScale.x,vector.y * inputScale.y,vector.z * inputScale.z);	
		}

		private static Vector3 Offset(Vector3 vector)
		{
			return vector + inputOffset;
		}

		// DIREZIONE

		public static Vector3 ToUnity(this Vector vector)
		{
			return Flip (vector);
		}

		// ACCELERAZIONE/VELOCITY

		public static Vector3 ToUnityScaled(this Vector vector)
		{
			return Scale (Flip(vector));
		}

		// POSIZIONE 

		public static Vector3 ToUnityTranslated(this Vector vector)
		{
			return Offset (Scale (Flip (vector)));

		}

	}	
}