﻿using UnityEngine;
using System.Collections;

public class PlasticCupControl : MonoBehaviour {
    
    public int pointsToAdd = 100;

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
        if (other.tag == "PBot")
        {
            ScoreControl.AddPoints(pointsToAdd);
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
