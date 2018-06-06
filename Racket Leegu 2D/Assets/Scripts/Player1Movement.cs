using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Movement : MonoBehaviour {
	AudioSource audiosource;
    public AudioClip JumpSound;

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

		audiosource = GetComponent<AudioSource> ();
		audiosource.pitch = 1f;
	}

    private void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "Floor" || col.gameObject.name == "Player2")
        {
            isGrounded = true;
        }
    }

	// Update is called once per frame
	void Update () {

        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(moveHorizontal, 0);

        Move(movement, speed);
        Jump();
        Rotate();
        Boost();
    }

    public void Move(Vector2 movement, float speed) {
		if ((Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.D)) && audiosource.pitch <= 2f) {
			audiosource.pitch += Time.deltaTime * 1.1f;
		} else if (audiosource.pitch >= 1f) {
			audiosource.pitch -= Time.deltaTime * 1.1f;
		}

		rb.AddForce(movement * speed);
    }

    public void Jump(){
		if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            audiosource.PlayOneShot(JumpSound,0.5f);
			rb.AddForce(jump * jumpForce, ForceMode2D.Impulse);
			isGrounded = false;
        }
    }

    public void Rotate(){

		if (Input.GetKey (KeyCode.W)) {
			transform.Rotate (Vector3.forward, rotateSpeed * Time.deltaTime);
		}
		else if (Input.GetKey (KeyCode.S)) {
			transform.Rotate (Vector3.back, rotateSpeed * Time.deltaTime);
		}
    }

    public void Boost() {

        if(Input.GetKey(KeyCode.LeftShift)) {
            rb.AddForce(transform.right * rocketSpeed);
        }
    }
}
