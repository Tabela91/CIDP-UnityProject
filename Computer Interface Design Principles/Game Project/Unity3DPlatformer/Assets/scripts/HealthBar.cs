using UnityEngine;
using UnityEngine.UI; //needed to use Slider 
using System.Collections;

public class HealthBar : MonoBehaviour {

    public static int health = 100; //health value
    public GameObject player; //player object
    public Slider healthBar; // healthbar slider

    // Use this for initialization
    void Start () {
        //for testing health, repeats ReduceHealth method
        //InvokeRepeating("ReduceHealth", 1, 1);
    }

    //method for Health Bar
    void ReduceHealth()
    {
        health = health - 20;//health reduced by this value whenever method is invoked
        healthBar.value = health; //Reflects the current health value in the health bar slider
        //controls death state
        if (health <= 0)
        {
            //disables CharacterController script so the player can no longer move on deat
                player.GetComponent<CharacterController>().enabled = false;
            //Sets isDead trigger to initiate death animation
                player.GetComponent<Animator>().SetTrigger("isDead");
        }
    }

  
}
