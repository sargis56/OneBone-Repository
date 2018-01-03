using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform playerBon;
	public Transform playerBob;
	private Transform camTrans;
	int x;

    public bool bounds;
    public Vector3 minCameraPos;
    public Vector3 maxCameraPos;
    // Use this for initialization
    void Start()
    {
        camTrans = this.GetComponent<Transform>();
		x = 1;
    }

    // Update is called once per frame
    void Update()
    {
		
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
			x *=-1;
		if (x > 0)
			camTrans.position = new Vector3(playerBon.position.x, playerBon.position.y, camTrans.position.z);
		else if (x < 0)
			camTrans.position = new Vector3(playerBob.position.x, playerBob.position.y, camTrans.position.z);
        if (bounds)
        {
            camTrans.position
                = new Vector3(
                    Mathf.Clamp(camTrans.position.x, minCameraPos.x, maxCameraPos.x),
                    Mathf.Clamp(camTrans.position.y, minCameraPos.y, maxCameraPos.y),
                    Mathf.Clamp(camTrans.position.z, minCameraPos.z, maxCameraPos.z));
        }
    }
}
