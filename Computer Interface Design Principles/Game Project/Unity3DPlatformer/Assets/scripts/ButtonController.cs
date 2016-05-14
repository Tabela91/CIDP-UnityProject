using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonController : MonoBehaviour {

	public void Jump()
    {
        GetComponent<Animator>().SetBool("isJumping", true);
    }
}
