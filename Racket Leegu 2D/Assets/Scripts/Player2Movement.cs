﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Movement : MonoBehaviour {
	AudioSource audiosource;
    public AudioClip JumpSound;
    public AudioClip rocketBoost;

    public bool facingRight;

    public float speed;
    public float rocketSpeed;
    private Rigidbody2D rb;
	bool isGrounded;
	public float jumpForce;
	public float rotateSpeed;

	public float zRotation;

	public Vector3 jump;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		jump = new Vector3 (0.0f, 2.0f, 0.0f);
		jumpForce = 3f;
        facingRight = false;

		audiosource = GetComponent<AudioSource> ();
		audiosource.pitch = 1f;
	}

    private void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "Floor" || col.gameObject.name == "Player1")
        {
            isGrounded = true;
        }
    }

    // Update is called once per frame
    void Update () {

		float moveHorizontal = Input.GetAxis("Horizontal2");
		Vector2 movement = new Vector2(moveHorizontal, 0);

		Move(movement, speed);
		Jump();
		Rotate();
        Boost();
	}

    public void Move(Vector2 movement, float speed) {
        if (Input.GetKey(KeyCode.RightArrow) && audiosource.pitch <= 2f) {
            audiosource.pitch += Time.deltaTime * 1.1f;

            if (!facingRight) {
                transform.Rotate(new Vector3(0, 180, 0));
                facingRight = true;
            }
        }

        else if (Input.GetKey(KeyCode.LeftArrow) && audiosource.pitch <= 2f) {
            audiosource.pitch += Time.deltaTime * 1.1f;

            if (facingRight) {
                transform.Rotate(new Vector3(0, -180, 0));
                facingRight = false;
            }
        }

        else if (audiosource.pitch >= 1f) {
            audiosource.pitch -= Time.deltaTime * 1.1f;
        }

        rb.AddForce(movement * speed);
    }

    public void Jump(){
		if (Input.GetKeyDown(KeyCode.RightControl) && isGrounded)
		{
            audiosource.PlayOneShot(JumpSound, 0.5f);
            rb.AddForce(jump * jumpForce, ForceMode2D.Impulse);
			isGrounded = false;
		}
	}

	public void Rotate(){

		if (Input.GetKey (KeyCode.UpArrow)) {
			transform.Rotate (Vector3.forward, rotateSpeed * Time.deltaTime);
		}
		else if (Input.GetKey (KeyCode.DownArrow)) {
			transform.Rotate (Vector3.back, rotateSpeed * Time.deltaTime);
		}
	}

    public void Boost() {

        if (Input.GetKey(KeyCode.RightShift)) {
            rb.AddForce(-transform.right * rocketSpeed);

            if (Input.GetKeyDown(KeyCode.RightShift))
            {
                audiosource.PlayOneShot(rocketBoost, 1f);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
