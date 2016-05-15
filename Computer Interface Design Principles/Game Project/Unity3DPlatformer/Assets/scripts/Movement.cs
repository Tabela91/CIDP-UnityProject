using UnityEngine;
using System.Collections;
[DisallowMultipleComponent]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class Movement : MonoBehaviour {

    Animator anim;
    bool isWalking = false;
    const float WALK_SPEED = .25f;
    public float speed = 10.0f;
    public VirtualJoystick joystick;
    float forwardInput, turnInput;

    


    void Awake()
    {
        anim = GetComponent<Animator>();
        forwardInput = turnInput = 0;
    }

   

    void Update()
    {
        
        Jump();
        Walking();
        Turning();
        Move();
    }

    void Turning()
    { 
        //controls strafing left or right with Q or E keys
        anim.SetFloat("Turn", Input.GetAxis("MoveX")); 
        //anim.SetFloat("Turn", joystick.Horizontal()); for Joystick input
    }

    void Walking()
    {
        if(Input.GetKeyDown (KeyCode.LeftShift))
        {
            isWalking = !isWalking;
            anim.SetBool("Walk", isWalking);
        }
    }

    void Move()
    {
        if(anim.GetBool("Walk"))
        {   //remember that input.getAxis("Horizontal") etc have been renamed to MoveZ/X
            //Change Input.GetAxis("MoveZ") to joystick.Vertical() for Joystick Input
            //Change Input.GetAxis("MoveX") to joystick.Horizontal() for Joystick Input
            anim.SetFloat("MoveZ", Mathf.Clamp(Input.GetAxis("MoveZ"), -WALK_SPEED, WALK_SPEED));
            anim.SetFloat("MoveX", Mathf.Clamp(Input.GetAxis("MoveX"), -WALK_SPEED, WALK_SPEED));

        }
        
        

        else
        {  // For Keyboard Movement
            anim.SetFloat("MoveZ", Input.GetAxis("MoveZ"));
            anim.SetFloat("MoveX", Input.GetAxis("MoveX"));
          
            

            /*For Joystick Input
            anim.SetFloat("MoveZ", joystick.Vertical());
            anim.SetFloat("MoveX", joystick.Horizontal());
    */
        }
    }

    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            anim.SetTrigger("Jump");

    }

    //Button Jump Trigger. Needed to be separate function to work successfully 
    public void ClickJump()
    {
        anim.SetTrigger("Jump");
    }
	
}
