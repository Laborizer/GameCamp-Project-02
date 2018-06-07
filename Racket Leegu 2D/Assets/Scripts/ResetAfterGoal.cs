using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetAfterGoal : MonoBehaviour {

    float resetTimer;

	// Use this for initialization
	void Start () {
        resetTimer = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if(GameObject.Find("Ball").GetComponent<Ball>().scored)
        {
            if(resetTimer >= 3)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);

                resetTimer = 0;
            }
            else
            {
                resetTimer += Time.deltaTime;
            }
        }
	}
}
