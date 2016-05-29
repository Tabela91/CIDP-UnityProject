using UnityEngine;
using UnityEngine.UI; //needed to use Slider 
using System.Collections;

public class HealthBar : MonoBehaviour {

    public static int health = 100; //health value
    public GameObject player; //player object
    public Slider healthBar; // healthbar slider
    public GameObject retryMenu; //retry menu panel]
    public bool playedClip = false; //bool to control death sound clip

    

    // Use this for initialization
    void Start () {
        
        health = 100;
        //Uncomment below for testing health depletion and death animation trigger
        InvokeRepeating("ReduceHealth", 1, 1);
        
        //places retrymenu panel in retryMenu game object. Disables it so that the menu does not appear at game start
        retryMenu = GameObject.Find("DeathMenu");
        retryMenu.SetActive(false);
    }

    void Update()
    {
        StartCoroutine("ShowRetry", 3f);
    }

    IEnumerator ShowRetry(float waitTime)
    {
        if (playedClip)
        {
            //waits a set amount of seconds
            yield return new WaitForSeconds(waitTime);
            //shows the retry menu
            retryMenu.SetActive(true);
        }
    }

    //method for Health Bar
    void ReduceHealth()
    {
        health = health - 5;//health reduced by this value whenever method is invoked
        //this if statement will stop health value from exceeded 100 if the value ever exceeds it the cap.
        if(health >100)
        {
            health = 100;
        }
        healthBar.value = health; //Reflects the current health value in the health bar slider
        AudioSource audio = GetComponent<AudioSource>();
        //controls death state
        if (health <= 0)
        {
            //disables CharacterController script so the player can no longer move on deat
                player.GetComponent<Movement>().enabled = false;
            //Sets isDead trigger to initiate death animation
                player.GetComponent<Animator>().SetTrigger("isDead");
            //checks if the clip has been played yet
            if (!playedClip)
            {
                //plays clip then sets bool to true, this way the clip is only played once. 
                audio.Play();
                playedClip = true;
            }
            
            

        }

        
    }

  
}
