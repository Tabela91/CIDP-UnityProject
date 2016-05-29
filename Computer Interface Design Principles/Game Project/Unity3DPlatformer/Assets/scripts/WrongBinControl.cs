using UnityEngine;
using System.Collections;

public class WrongBinControl : MonoBehaviour {

	void OnCollisionEnter(Collision col)
    {
        AudioSource bad = GetComponent<AudioSource>();
        HealthBar.health -= 25;
        bad.Play();
    }
}
