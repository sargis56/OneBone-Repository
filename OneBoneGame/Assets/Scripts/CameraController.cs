using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform player;
    private Transform camTrans;

    // Use this for initialization
    void Start()
    {
        camTrans = this.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        camTrans.GetComponent<Camera>().fieldOfView = 70;
        camTrans.position = new Vector3(player.position.x, player.position.y, camTrans.position.z);
    }
}
