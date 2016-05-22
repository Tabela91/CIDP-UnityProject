using UnityEngine;
using System.Collections;

public class PickUp : MonoBehaviour {

    //when this trigger happens from something else colliding with the pickup
    void OnTriggerEnter(Collider other)
    {
        HealthBar.health += 10;
        Destroy(this.gameObject);
    }
	
}
