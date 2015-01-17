using UnityEngine;
using System.Collections;
using Leap;

public class FollowAnimatorLeap : MonoBehaviour 
{
	
	private Controller controller;
	
	public static float pitch = 0.0f;
	public static float roll  = 0.0f;
	public static float yaw   = 0.0f;
	
	public static bool handInScene = false;
	public static bool lateral = false;
	public static bool jump = false;
	
	public float pitchAnimator()
	{
		return -(pitch / 25);
	}
	
	public float rollAnimator()
	{
		return -(roll / 25);
	}
	
	public float yawAnimator()
	{
		return -(yaw / 25);
	}
	
	public static void controllerGesture(Controller controller)
	{
		if(!controller.IsGestureEnabled(Gesture.GestureType.TYPECIRCLE))	
		{
		    controller.EnableGesture(Gesture.GestureType.TYPECIRCLE);
	    }
		if(!controller.IsGestureEnabled(Gesture.GestureType.TYPEKEYTAP))	
		{
		    controller.EnableGesture(Gesture.GestureType.TYPEKEYTAP);
	    }
		if(!controller.IsGestureEnabled(Gesture.GestureType.TYPESCREENTAP))	
		{
		    controller.EnableGesture(Gesture.GestureType.TYPESCREENTAP);
	    }
		if(!controller.IsGestureEnabled(Gesture.GestureType.TYPESWIPE))	
		{
		    controller.EnableGesture(Gesture.GestureType.TYPESWIPE);
	    }
		
	}
	
	public static void OnFrame(Controller controller)
	{
		if(controller.IsConnected)
		{
			Frame frame = controller.Frame();
			
			if(!frame.Hands.IsEmpty)
			{
				handInScene = true;
				
				Hand hand = frame.Hands[0];
				
				Vector direction = hand.Direction;
				Vector normal    = hand.PalmNormal;
				
				pitch = direction.Pitch * 180.0f / (float)Mathf.PI;
				roll  = normal.Roll     * 180.0f / (float)Mathf.PI;
				yaw   = direction.Yaw   * 180.0f / (float)Mathf.PI;
				
			//	Debug.Log("Pitch: " + pitch + " Roll: " + roll + " Yaw: " + yaw);
				
			}
			else
			{
				handInScene = false;
			}
			
			GestureList gestures = frame.Gestures();
			
			for(int i = 0;i < gestures.Count; i++)
			{
		        Gesture gesture = gestures[i];
				
				switch(gesture.Type)	
				{
				   case Gesture.GestureType.TYPECIRCLE:
					    
					     CircleGesture circleGesture = new CircleGesture(gesture);
					     
					     if(circleGesture.Pointable.Direction.AngleTo(circleGesture.Normal) <= Mathf.PI / 4)	
					     {
		                     jump = true;
	                     }
					     else
					     {
		                     lateral = true;
						    // jump = true;
	                     }
					
				   break;
					
				   case Gesture.GestureType.TYPESWIPE:
				
				         SwipeGesture swipe = new SwipeGesture(gesture);
				
			       break;
				
			       case Gesture.GestureType.TYPEKEYTAP:
				
				         KeyTapGesture keyTap = new KeyTapGesture(gesture);

		           break;
				
			       case Gesture.GestureType.TYPESCREENTAP:
				
				         ScreenTapGesture screenTap = new ScreenTapGesture(gesture);	
					
			       break;
	            }
	        }
			
		}
	}
	
	void Start ()
	{
	    controller = new Controller();
		
	}
	
	
	void Update ()
	{
	    OnFrame(controller);
		controllerGesture(controller);
	}
}
