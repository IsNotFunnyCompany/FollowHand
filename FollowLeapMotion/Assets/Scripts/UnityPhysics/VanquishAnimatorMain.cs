using UnityEngine;
using System.Collections;

/*

          _____                    _____                    _____                    _____                    _____                _____                   _______                   _____          
         /\    \                  /\    \                  /\    \                  /\    \                  /\    \              /\    \                 /::\    \                 /\    \         
        /::\    \                /::\____\                /::\    \                /::\____\                /::\    \            /::\    \               /::::\    \               /::\    \        
       /::::\    \              /::::|   |                \:::\    \              /::::|   |               /::::\    \           \:::\    \             /::::::\    \             /::::\    \       
      /::::::\    \            /:::::|   |                 \:::\    \            /:::::|   |              /::::::\    \           \:::\    \           /::::::::\    \           /::::::\    \      
     /:::/\:::\    \          /::::::|   |                  \:::\    \          /::::::|   |             /:::/\:::\    \           \:::\    \         /:::/~~\:::\    \         /:::/\:::\    \     
    /:::/__\:::\    \        /:::/|::|   |                   \:::\    \        /:::/|::|   |            /:::/__\:::\    \           \:::\    \       /:::/    \:::\    \       /:::/__\:::\    \    
   /::::\   \:::\    \      /:::/ |::|   |                   /::::\    \      /:::/ |::|   |           /::::\   \:::\    \          /::::\    \     /:::/    / \:::\    \     /::::\   \:::\    \   
  /::::::\   \:::\    \    /:::/  |::|   | _____    ____    /::::::\    \    /:::/  |::|___|______    /::::::\   \:::\    \        /::::::\    \   /:::/____/   \:::\____\   /::::::\   \:::\    \  
 /:::/\:::\   \:::\    \  /:::/   |::|   |/\    \  /\   \  /:::/\:::\    \  /:::/   |::::::::\    \  /:::/\:::\   \:::\    \      /:::/\:::\    \ |:::|    |     |:::|    | /:::/\:::\   \:::\____\ 
/:::/  \:::\   \:::\____\/:: /    |::|   /::\____\/::\   \/:::/  \:::\____\/:::/    |:::::::::\____\/:::/  \:::\   \:::\____\    /:::/  \:::\____\|:::|____|     |:::|    |/:::/  \:::\   \:::|    |
\::/    \:::\  /:::/    /\::/    /|::|  /:::/    /\:::\  /:::/    \::/    /\::/    / ~~~~~/:::/    /\::/    \:::\  /:::/    /   /:::/    \::/    / \:::\    \   /:::/    / \::/   |::::\  /:::|____|
 \/____/ \:::\/:::/    /  \/____/ |::| /:::/    /  \:::\/:::/    / \/____/  \/____/      /:::/    /  \/____/ \:::\/:::/    /   /:::/    / \/____/   \:::\    \ /:::/    /   \/____|:::::\/:::/    / 
          \::::::/    /           |::|/:::/    /    \::::::/    /                       /:::/    /            \::::::/    /   /:::/    /             \:::\    /:::/    /          |:::::::::/    /  
           \::::/    /            |::::::/    /      \::::/____/                       /:::/    /              \::::/    /   /:::/    /               \:::\__/:::/    /           |::|\::::/    /   
           /:::/    /             |:::::/    /        \:::\    \                      /:::/    /               /:::/    /    \::/    /                 \::::::::/    /            |::| \::/____/    
          /:::/    /              |::::/    /          \:::\    \                    /:::/    /               /:::/    /      \/____/                   \::::::/    /             |::|  ~|          
         /:::/    /               /:::/    /            \:::\    \                  /:::/    /               /:::/    /                                  \::::/    /              |::|   |          
        /:::/    /               /:::/    /              \:::\____\                /:::/    /               /:::/    /                                    \::/____/               \::|   |          
        \::/    /                \::/    /                \::/    /                \::/    /                \::/    /                                      ~~                      \:|   |          
         \/____/                  \/____/                  \/____/                  \/____/                  \/____/                                                                \|___|          


                                                                                                    Alex Voicu Develop 2014/03/10
*/


[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Rigidbody))]


public class VanquishAnimatorMain : MonoBehaviour {


	public float                speedAnimator = 1.5f;

	private VanquishMasterLeap vanquishMaster;
	private Animator           animator;
	private AnimatorStateInfo  firstAnimatorStateInfo;
	private CapsuleCollider    capsuleCollider;

	public float direction = 0.0f;
	public float speed     = 0.0f;

	static int idleAnimation = Animator.StringToHash("TimeAndSpace.Idle");


	void Start() 
	{
		animator        = GetComponent<Animator>();
		capsuleCollider = GetComponent<CapsuleCollider>();

		vanquishMaster = (GameObject.FindGameObjectWithTag("LeapMotion")as GameObject).GetComponent (typeof(VanquishMasterLeap))as VanquishMasterLeap;

	}

	void Update(){

	/*	if(direction < -0.5f)
		{
			camera.gameObject.transform.rotation.y = -2;
		}
		if(direction >  0.5f)
		{
			camera.gameObject.transform.rotation.y = 2;
		}
     */   
	}
	void FixedUpdate() 
	{
		/*
		direction = Input.GetAxis("Horizontal");
		speed     = Input.GetAxis("Vertical");
        */
	// PARTE LEAP MOTION
//	 if(VanquishMasterLeap.handInScene){

//		    direction = vanquishMaster.rollAnimator ();
//		    speed     = vanquishMaster.pitchAnimator();
		
	//	}else{

	//		direction = 0.0f;
	//		speed     = 0.0f;
	//	}

		animator.SetFloat("Velocita",speed);
		animator.SetFloat("Direzione",direction);
		animator.speed = speedAnimator;

		//Debug.Log(VanquishMasterLeap.roll);


	}
}










































