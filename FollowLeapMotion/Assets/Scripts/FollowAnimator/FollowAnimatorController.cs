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


public class FollowAnimatorController : MonoBehaviour {


	public float speedAnimator = 1.5f;

	private FollowAnimatorLeap animatorLeap;
	private Animator           animator;
	private AnimatorStateInfo  firstAnimatorStateInfo;
	private CapsuleCollider    capsuleCollider;

	public float direction = 0.0f;
	public float speed     = 0.0f;

	static int idleAnimation = Animator.StringToHash("Base Layer.Idle");


	void Start() 
	{
		animator        = GetComponent<Animator>();
		capsuleCollider = GetComponent<CapsuleCollider>();

		animatorLeap = (GameObject.FindGameObjectWithTag("LeapMotion")as GameObject).GetComponent (typeof(FollowAnimatorLeap))as FollowAnimatorLeap;

	}

	
	void FixedUpdate() 
	{
		
    //   Key Input Follow
	/*	direction = Input.GetAxis("Horizontal");
		speed     = Input.GetAxis("Vertical");
		
		animator.SetFloat("Speed",speed);
		animator.SetFloat("Direction",direction);
		animator.speed = speedAnimator;
	*/	 
// Leap Motion ************************************************************************
	 if(FollowAnimatorLeap.handInScene)
	 {

		direction = animatorLeap.rollAnimator();
		speed     = animatorLeap.pitchAnimator();
			
	 }
	 else
	 {
        direction = 0.0f;
		speed     = 0.0f;
	 }

		animator.SetFloat("Speed",speed);
		animator.SetFloat("Direction",direction);
		animator.speed = speedAnimator;
		
		if(FollowAnimatorLeap.lateral)
		{
		    animator.SetBool("Dive",true);
			FollowAnimatorLeap.lateral = false;
	    }
		else
		{
		    animator.SetBool("Dive",false);
	    }
		
		if(FollowAnimatorLeap.jump)
		{
		    animator.SetBool("Jump",true);
			FollowAnimatorLeap.jump = false;
	    }
		else
		{
		    animator.SetBool("Jump",false);
	    }
//************************************************************************************/		
	/*	
		if(Input.GetKey("q"))
		{
			animator.SetBool("Dive",true);
		}
		else
		{
			animator.SetBool("Dive",false); 
		}
		
		if(Input.GetKey("e"))
		{
			animator.SetBool("Jump",true);
		}
		else
		{
			animator.SetBool("Jump",false);
		}
	*/	
		//Debug.Log(VanquishMasterLeap.roll);


	}
}



