using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class playerController : MonoBehaviour {
	//public varriables
	public float speed = 5.0f;
	public float groundRadius; //radius of the groundcheck
	public float jumpForce = 700f;

	public Transform groundCheck;
	public LayerMask whatIsGround; //layers of that player can jump on (this case everything)

	//ground check
	bool grounded = false;

	Rigidbody2D rBody;


	// Use this for initialization
	void Start () {
		rBody = this.GetComponent<Rigidbody2D>();
	}

	private void FixedUpdate()
	{
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround); //check if groundcheck overlap with the ground
		float horizMove = Input.GetAxis("Horizontal");

		rBody.velocity = new Vector2(horizMove * speed, rBody.velocity.y); // basic movement
	
	}

	// Update is called once per frame
	void Update () {
		if ((grounded) && Input.GetButtonDown("Jump")) //checking for the input and if groundcheck is overlapping with the ground
		{

			rBody.AddForce(new Vector2(0, jumpForce));

		}
	}
}
