using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSwitch : MonoBehaviour {

    public GameObject player1;
    public GameObject player2;
    public Vector3 moveAwayPos;

    bool player1Active = true;

    // Use this for initialization
    void Start () {
        player2.transform.position = moveAwayPos;
        foreach (Behaviour childCompnent in player2.GetComponentsInChildren<Behaviour>())
        {
            childCompnent.enabled = false;
        }
        player2.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
    }

    private void FixedUpdate()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (player1Active == true)
            {
                player2.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;

                foreach (Behaviour childCompnent in player2.GetComponentsInChildren<Behaviour>())
                {
                    childCompnent.enabled = true;
                }

                player2.transform.position = new Vector3(player1.GetComponent<Rigidbody2D>().position.x,
                player1.GetComponent<Rigidbody2D>().position.y);

                foreach (Behaviour childCompnent in player1.GetComponentsInChildren<Behaviour>())
                {
                    childCompnent.enabled = false;
                }
                player1.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
                player1.transform.position = moveAwayPos;
                player1Active = false;

            }
            else
            {
                player1.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;

                foreach (Behaviour childCompnent in player1.GetComponentsInChildren<Behaviour>())
                {
                    childCompnent.enabled = true;
                }

                player1.transform.position = new Vector3(player2.GetComponent<Rigidbody2D>().position.x,
                player2.GetComponent<Rigidbody2D>().position.y);

                foreach (Behaviour childCompnent in player2.GetComponentsInChildren<Behaviour>())
                {
                    childCompnent.enabled = false;
                }
                player2.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
                player2.transform.position = moveAwayPos;
                player1Active = true;
            }
        }
    }
}
