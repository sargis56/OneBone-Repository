using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patrol : MonoBehaviour {

    private Rigidbody2D rb;
    public double moveLeft;
    public double moveRight;
    GameObject gameControllerObject;
    public int speed = 1;

    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {

    }

    void Update()
    {
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
