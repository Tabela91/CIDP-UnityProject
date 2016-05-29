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

    


    void Awake()
    {
        anim = GetComponent<Animator>();
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
        //IF SHIFT KEY IS PRESSED THEREFORE WALK IS TOGGLED ON
        if(anim.GetBool("Walk"))
        {   
            anim.SetFloat("MoveZ", Mathf.Clamp(joystick.Vertical(), -WALK_SPEED, WALK_SPEED));
            anim.SetFloat("MoveX", Mathf.Clamp(Input.GetAxis("MoveX"), -WALK_SPEED, WALK_SPEED));
        }
        
        

        else
        {  
           //Joystick Vertical function checks for joystick position. if value is 0 then it will get the MoveZ values from the W/S and Forward/Backward buttons
            anim.SetFloat("MoveZ", joystick.Vertical());

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
