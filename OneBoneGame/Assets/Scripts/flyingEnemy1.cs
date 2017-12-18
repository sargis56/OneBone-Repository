using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flyingEnemy1 : MonoBehaviour {

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
		forceVec *= Mathf.Clamp(dist, 1, 3);
		//rb.velocity = forceVec;
		rb.velocity = Vector2.ClampMagnitude(rb.velocity, 20);
		this.GetComponent<Rigidbody2D>().AddForce(forceVec); //orbit??


	}

	void rng()
	{
		x = (Random.insideUnitCircle * 1);
	}
}
