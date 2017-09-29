using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class playerController : MonoBehaviour {

	public float speed = 5.0f;
	public float groundRadius;
	public float jumpForce = 700f;
	bool grounded = false;

	Rigidbody2D rBody;

	public Transform groundCheck;
	public LayerMask whatIsGround;
	// Use this for initialization
	void Start () {
		rBody = this.GetComponent<Rigidbody2D>();
	}

	private void FixedUpdate()
	{
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
		float horizMove = Input.GetAxis("Horizontal");

		rBody.velocity = new Vector2(horizMove * speed, rBody.velocity.y);

		Debug.Log(grounded);

	}

	// Update is called once per frame
	void Update () {
		if ((grounded) && Input.GetButtonDown("Jump"))
		{

			rBody.AddForce(new Vector2(0, jumpForce));

		}
	}
}
