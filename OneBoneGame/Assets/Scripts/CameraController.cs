using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform playerBon;
	public Transform playerBob;
	private Transform camTrans;
	int x;

    // Use this for initialization
    void Start()
    {
        camTrans = this.GetComponent<Transform>();
		x = 1;
    }

    // Update is called once per frame
    void Update()
    {
        

		if (Input.GetKeyDown(KeyCode.I))
		{
			x *=-1;
		}
		if (x > 0)
		{
			camTrans.position = new Vector3(playerBon.position.x, playerBon.position.y, camTrans.position.z);
		}
		else if (x < 0)
		{
			camTrans.position = new Vector3(playerBob.position.x, playerBob.position.y, camTrans.position.z);
		}

    }
}
