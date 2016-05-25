using UnityEngine;
using System.Collections;

public class PickUp : MonoBehaviour
{

    //when player runs through the object
    //when this trigger happens from something else colliding with the pickup
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //adds 10 value to health and destroys pick up
            HealthBar.health += 20;
            Destroy(this.gameObject);
        }


        //collision event 
        //when player hits object
        /*
        void OnCollisionEnter (Collision col)
        {
            if (col.gameObject.tag == "Respawn")
            {
                //adds 10 value to health and destroys pick up
                HealthBar.health += 10;
                //Destroy(this.gameObject);
            }
        }
        */
    }
}
