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
    }

    void GetInput()
    {

        forwardInput = joystick.Vertical();
        turnInput = joystick.Horizontal();
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
        anim.SetFloat("MoveX", Input.GetAxis("MoveX")); 
        //controls turning input with A and D keys or arrow keys
        anim.SetFloat("Turn", joystick.Horizontal());
        //for Joystick input
       // anim.SetFloat("Turn", joystick.Horizontal());
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
        //IF SHIFT KEY IS HELD DOWN THEREFORE WALK IS TRIGGERED

        if(anim.GetBool("Walk"))
        {   //remember that input.getAxis("Horizontal") etc have been renamed to MoveZ/X
            //Change Input.GetAxis("MoveZ") to joystick.Vertical() for Joystick Input
            //Change Input.GetAxis("MoveX") to joystick.Horizontal() for Joystick Input
            anim.SetFloat("MoveZ", Mathf.Clamp(joystick.Vertical(), -WALK_SPEED, WALK_SPEED));
            anim.SetFloat("MoveX", Mathf.Clamp(Input.GetAxis("MoveX"), -WALK_SPEED, WALK_SPEED));
          // anim.SetFloat("MoveZ", Mathf.Clamp(joystick.Vertical(), -WALK_SPEED, WALK_SPEED));
           // anim.SetFloat("MoveX", Mathf.Clamp(joystick.Horizontal(), -WALK_SPEED, WALK_SPEED));

        }
        
        

        else
        {  
           //Joystick Vertical function checks for joystick position. if value is 0 then it will get the MoveZ values from the W/S and Forward/Backward buttons
            anim.SetFloat("MoveZ", joystick.Vertical());
            // anim.SetFloat("MoveZ", Input.GetAxis("MoveZ"));
            // anim.SetFloat("MoveX", joystick.Horizontal());

        }
    }

    //controls jump for keyboard input
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
