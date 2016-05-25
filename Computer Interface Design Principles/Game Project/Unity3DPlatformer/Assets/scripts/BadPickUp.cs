using UnityEngine;
using System.Collections;

public class BadPickUp : MonoBehaviour
{

    //when this trigger happens from something else colliding with the pickup
    void OnTriggerEnter(Collider other)
    {
        //depletes health by 10 and destroys pick up
        HealthBar.health -= 10;
        Destroy(this.gameObject);
    }

}
