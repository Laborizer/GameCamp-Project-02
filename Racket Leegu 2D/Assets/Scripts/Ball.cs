using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    AudioSource audiosource;
    public AudioClip BallBounce;

    private void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        audiosource.PlayOneShot(BallBounce, 0.5f);
    }
}
