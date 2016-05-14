using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CharacterController : MonoBehaviour {

    static Animator anim;
    public float speed = 10.0F;
    public float rotationSpeed = 100.0F;
    // testing new movement
    public float inputDelay = 0.1f;
    public float forwardVel = 12;
    public float rotateVel = 100;
    public VirtualJoystick joystick;
    

    Quaternion targetRotation;
    Rigidbody rBody;
    float forwardInput, turnInput;

    public Quaternion TargetRotation
    {
        get { return targetRotation; }
    }
    
   
    void Start()
    {
        
        anim = GetComponent<Animator>();
        targetRotation = transform.rotation;
        if (GetComponent<Rigidbody>())
            rBody = GetComponent<Rigidbody>();
        else
            Debug.LogError("The character needs a rigid body.");

        forwardInput = turnInput = 0;
    }

    

    void GetInput()
    {

        forwardInput = joystick.Vertical(); //Input.GetAxis("Vertical");
        turnInput = joystick.Horizontal();//Input.GetAxis("Horizontal");
    }

    void Update()
    {
        GetInput();
        Turn();
        //------------------------------
        Movement();

    }

  

    public void Jump()
    {
        float translation = joystick.Vertical() * speed;
        translation *= Time.deltaTime;

        transform.Translate(0, 0, translation);

        if (translation != 0)
        {
            this.gameObject.GetComponent<Animator>().SetTrigger("isRunJump");
        }

        if (translation == 0)
        {
            this.gameObject.GetComponent<Animator>().SetTrigger("isJump");
        }
    }

    void Movement()
    {
        //controls idle jump - Input.GetAxis is used only for dedicated keyboard input
        float translation = /*Input.GetAxis("Vertical")*/ joystick.Vertical() * speed;

        translation *= Time.deltaTime;

        transform.Translate(0, 0, translation);


        //controls idle jump
        if (Input.GetButtonDown("Jump"))
        {
            anim.SetBool("isJumping", true);
        }

        else
        {
            anim.SetBool("isJumping", false);
        }

        //controls running animation movement
        if (translation != 0)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }

        //controls running jump

        if ((translation != 0) && (Input.GetButtonDown("Jump")))
        {
            anim.SetBool("isRunJumping", true);
        }
        else
        {
            anim.SetBool("isRunJumping", false);
        }
    }

    void FixedUpdate()
    {
        
            Run();
        
    }

    void Run()
    {
       
            if (Mathf.Abs(forwardInput) > inputDelay)
            {
                //move
                rBody.velocity = transform.forward * forwardInput * forwardVel;
            }
            else
                //zero velocity
                rBody.velocity = Vector3.zero;

        
    }
    

    void Turn()
    {
        if (Mathf.Abs(turnInput) > inputDelay)
        {
            targetRotation *= Quaternion.AngleAxis(rotateVel * turnInput * Time.deltaTime, Vector3.up);
        }
        transform.rotation = targetRotation;
    }


   }
