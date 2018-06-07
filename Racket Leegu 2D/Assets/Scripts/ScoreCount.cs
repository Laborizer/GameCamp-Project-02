using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCount : MonoBehaviour {
    bool scoreCounted;

    int p1Score;
    int p2Score;

    public TextMesh p1ScoreText;
    public TextMesh p2ScoreText;

    // Use this for initialization
    void Start () {
        scoreCounted = false;

        p1Score = 0;
        p2Score = 0;

		p1ScoreText.text = p1Score.ToString();
        p2ScoreText.text = p2Score.ToString();
    }
	
	// Update is called once per frame
	void Update () {
        p1ScoreText.text = p1Score.ToString();
        p2ScoreText.text = p2Score.ToString();

        if (GameObject.Find("Ball").GetComponent<Ball>().p1Goal && !scoreCounted)
        {
            p1Score++;
            scoreCounted = true;
        }
        else if (GameObject.Find("Ball").GetComponent<Ball>().p2Goal && !scoreCounted)
        {
            p2Score++;
            scoreCounted = true;
        }
    }
}
