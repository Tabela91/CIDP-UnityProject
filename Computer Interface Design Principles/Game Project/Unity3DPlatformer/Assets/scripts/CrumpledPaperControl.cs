using UnityEngine;
using System.Collections;

public class CrumpledPaperControl : MonoBehaviour {

    public AudioClip goodpickup;
    public AudioClip badpickup;

    private AudioSource goodaudio;
    private AudioSource badaudio;

    void Start()
    {
        goodaudio = gameObject.AddComponent<AudioSource>();
        badaudio = gameObject.AddComponent<AudioSource>();
    }


    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "PPBot")
        {

            //adds 10 value to health and destroys pick up
            goodaudio.clip = goodpickup;
            HealthBar.health += 20;
            AudioSource.PlayClipAtPoint(goodpickup, transform.position);
            Destroy(this.gameObject);
        }
        else
        {
            badaudio.clip = badpickup;
            AudioSource.PlayClipAtPoint(badpickup, transform.position);
            HealthBar.health -= 30;
            Destroy(this.gameObject);
        }



    }
}
