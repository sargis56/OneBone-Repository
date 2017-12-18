using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flyingEnemy1 : enemy {

	public Transform point;
	public float speed;
	public Rigidbody2D rb;
	Vector3 x;
	float time;
	// Use this for initialization
	void Start()
	{
		InvokeRepeating("rng", 0f, 1f);
	}

	// Update is called once per frame
	void Update()
	{

		Vector3 forceVec = (point.position + x) - this.transform.position;
		float dist = Vector3.Distance(point.position, this.transform.position);
		forceVec *= Mathf.Clamp(dist, 0, 1);
		//rb.velocity = forceVec;
		rb.velocity = Vector2.ClampMagnitude(rb.velocity, 10);
		this.GetComponent<Rigidbody2D>().AddForce(forceVec); //orbit??

	}
	private void OnCollisionEnter2D(Collision2D collision)
	{


		if (collision.gameObject.tag == "bonnie" || collision.gameObject.tag == "bobbie" || collision.gameObject.tag == "bullet")
		{
			this.GetComponent<Rigidbody2D>().velocity = new Vector2(-this.GetComponent<Rigidbody2D>().velocity.x * 1.5f, 7f);

			if (collision.gameObject.tag == "sword")
			{
				collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-(collision.gameObject.GetComponent<Rigidbody2D>().velocity.x * 2), 7f);

			}
			hp -= 1;

		}



	}


	void rng()
	{
		x = (Random.insideUnitCircle * 0.5f);
	}
}
