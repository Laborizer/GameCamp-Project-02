using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    int random;
    public int player1Goal;
    public int player2Goal;

    AudioSource audiosource;
    public AudioClip BallBounce1;
    public AudioClip BallBounce2;
    public AudioClip BallBounce3;
    public AudioClip Goal;
    public AudioClip RimShot;
    public AudioClip Crowd;

    private void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Hoop")
        {
            audiosource.PlayOneShot(RimShot, 2f);
        }
        else
        {
            random = UnityEngine.Random.Range(1, 3);

            if (random == 1)
            {
                audiosource.PlayOneShot(BallBounce1, 0.5f);
            }
            else if (random == 2)
            {
                audiosource.PlayOneShot(BallBounce2, 0.5f);
            }
            else if (random == 3)
            {
                audiosource.PlayOneShot(BallBounce3, 0.5f);
            }
        }

        if (collision.gameObject.name == "LeftGoal")
        {
            playWin();
            player2Goal++;
        }

        if (collision.gameObject.name == "RightGoal")
        {
            playWin();
            player1Goal++;
        }
    }
    private void playWin()
    {
        audiosource.PlayOneShot(Goal, 0.8f);
        audiosource.PlayOneShot(Crowd, 0.5f);
    }
}
