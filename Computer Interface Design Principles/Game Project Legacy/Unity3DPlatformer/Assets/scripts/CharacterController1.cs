using UnityEngine;
using System.Collections;

[DisallowMultipleComponent]
public class CharacterController1 : MonoBehaviour {

    Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {

        Move();
    }

    void Move()
    {
        anim.SetFloat("Forward", Input.GetAxisRaw("Vertical"));
    }
}
