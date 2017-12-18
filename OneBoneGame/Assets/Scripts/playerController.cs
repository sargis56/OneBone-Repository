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
	public GameObject sword;

	public bool attacking;
	public int isBonnie;
	//ground check
	bool grounded = false;
	float timer;

	Rigidbody2D rBody;
    Animator anim;

	public int hp;

	public Transform currentSpawn;
	public GameObject otherPlayer;


	// Use this for initialization
	void Start () {
		rBody = this.GetComponent<Rigidbody2D>();
        anim = this.GetComponent<Animator>();
		if (this.tag == "bonnie")
		{
			isBonnie = 1;
		}
		else
		{
			isBonnie = -1;
		}

	}

	private void FixedUpdate()
	{
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround); //check if groundcheck overlap with the ground
		float horizMove = Input.GetAxis("Horizontal");
        if (!grounded && !Input.GetButton("Jump"))
            rBody.velocity = new Vector2(rBody.velocity.x, rBody.velocity.y - 0.5f);

        rBody.velocity = new Vector2(horizMove * speed, rBody.velocity.y); // basic movement
        anim.SetFloat("Speed", Mathf.Abs(horizMove));
        anim.SetFloat("VerticalSpeed", rBody.velocity.y);
        anim.SetBool("Grounded", grounded);


	}

	// Update is called once per frame
	void Update()
	{


		//this is a temp
		if (Input.GetKey(KeyCode.Tab))
		{
			isBonnie *= -1;
		}



		if ((grounded) && Input.GetButtonDown("Jump")) //checking for the input and if groundcheck is overlapping with the ground
		{

            //rBody.AddForce(new Vector2(0, jumpForce));
            rBody.velocity = new Vector2(rBody.velocity.x, jumpForce);

		}


		if (Input.GetKeyDown(KeyCode.Mouse0))   //sword spawn
		{
			timer = Time.time + 1f;
		}


		if (Time.time < timer)
		{
			if (this.tag == "bonnie")
			{
				sword.SetActive(true);
				attacking = true;

			}
			
		}
		else
		{
			sword.SetActive(false);
			attacking = false;
		}


		if (hp <= 0)
		{

			this.transform.position = currentSpawn.position;
			this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
			hp = 10;
		}

		


		if (Input.GetKey(KeyCode.D))  //flipping sprite
		{
			transform.eulerAngles = new Vector3(0, -180, 0);
		}
		else if (Input.GetKey(KeyCode.A))  //flipping sprite
		{
			transform.eulerAngles = new Vector3(0, 0, 0);
		}


	}


	private void OnCollisionEnter2D(Collision2D collision)
	{
		if ((collision.gameObject.tag == "enemy" )&& attacking == false)
		{
			hp -= collision.gameObject.GetComponent<enemy>().damage;

			Debug.Log(hp);

		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "spawn")
		{
			currentSpawn = other.transform;
			otherPlayer.GetComponent<playerController>().currentSpawn = other.transform;
		}


	}
}
