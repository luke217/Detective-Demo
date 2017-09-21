using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerafollow : MonoBehaviour {
    public Transform target;
    public float cam_speed = 0.1f;
    Camera mycam;
	// Use this for initialization
	void Start () {
        mycam = GetComponent<Camera>();

	}
	
	// Update is called once per frame
	void Update () {
        mycam.orthographicSize = (Screen.height / 100f) / 4f;///adjust the camera size according to the screen height
        if(target)///if target exist
        {
            transform.position = Vector3.Lerp(transform.position, target.position, cam_speed)+ new Vector3(0, 0, -1);///new Vector3 is for the zepta axis following's offset.
        }
	}
}
