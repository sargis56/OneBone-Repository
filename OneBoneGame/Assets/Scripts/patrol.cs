using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patrol : MonoBehaviour {

	private Rigidbody2D rb;
	public double moveLeft;
	public double moveRight;
	GameObject gameControllerObject;
	public int speed = 1;

	//public Transform groundCheck;
	//public LayerMask whatIsGround; //layers of that player can jump on (this case everything)
	//bool grounded = false;
	//float groundRadius = 0.1f; //radius of the groundcheck


	void Start()
    {

        rb = GetComponent<Rigidbody2D>();
    }

	private void OnTriggerEnter2D(Collider2D other)
	{
		Vector2 forceVec = this.transform.position - other.transform.position;
		forceVec *= 20;
		if (other.tag == "bonnie")
		{
			this.GetComponent<Rigidbody2D>().AddForce(forceVec);
		}
	}


		void Update()
    {
		//grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround); //check if groundcheck overlap with the ground


		if (this.gameObject.tag == "enemy")
        {
            if (rb.position.x > moveRight)
            {
                //rb.velocity = new Vector2(speed, 0);
                rb.velocity = new Vector2(speed * -1, 0);
            }
            if (rb.position.x < moveLeft)
            {
                rb.velocity = new Vector2(speed, 0);
                //rb.velocity = new Vector2(speed * -1, 0);
            }
        }
        else
        {
            Debug.Log("Cannot find Game Object");
        }


    }


}
