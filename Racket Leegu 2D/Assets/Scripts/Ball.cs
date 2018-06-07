using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    int random;
    public bool scored;
    public bool p1Goal;
    public bool p2Goal;

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
        scored = false;
        p1Goal = false;
        p2Goal = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "LeftGoal" || collision.gameObject.name == "RightGoal")
        {
            Vector3 contactPoint = collision.contacts[0].point;
            Vector3 center = collision.collider.bounds.center;
            bool top = contactPoint.y > center.y;

            if(top)
            {

                if(collision.gameObject.name == "LeftGoal")
                {
                    p2Goal = true;
                }
                else if(collision.gameObject.name == "RightGoal")
                {
                    p1Goal = true;
                }

                audiosource.PlayOneShot(Goal, 0.8f);
                audiosource.PlayOneShot(Crowd, 0.5f);

                scored = true;
            }
            else
            {
                audiosource.PlayOneShot(RimShot, 2f);
            }
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
    }
}
