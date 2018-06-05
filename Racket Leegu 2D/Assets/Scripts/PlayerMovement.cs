using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed;
    public float jumpHeight;
    private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();

        speed = 10f;
        jumpHeight = 20f;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        Move(movement, speed);
        Jump();
        Rotate();
    }

    public void Move(Vector2 movement, float speed) {
        rb.AddForce(movement * speed);
    }

    public void Jump(){
        if (Input.GetKeyDown(KeyCode.Space) && GameObject.Find("Player").transform.position.y <= -4.1)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * 3, ForceMode2D.Impulse);
        }
    }

    public void Rotate(){
        if(Input.GetKey(KeyCode.W)) {
            transform.Rotate(Vector3.forward * Time.deltaTime * 100);
        }
        if (Input.GetKey(KeyCode.S)) {
            transform.Rotate(Vector3.back * Time.deltaTime * 100);
        }
    }
}
