﻿using UnityEngine;
using System.Collections;
using System.IO;

public class CameraController : MonoBehaviour {

	public float rotateSpeed;
	public float rotateZoris = 0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		// Rotate Camera
		if (Input.GetButton ("CameraLeftRotate")) {
			//transform.Rotate(0, rotateSpeed, 0, Space.Self);
			transform.Rotate(0, -rotateSpeed, 0, Space.World);
		}
		if (Input.GetButton ("CameraRightRotate")) {
			//transform.Rotate(0, -rotateSpeed, 0, Space.Self);
			transform.Rotate(0, rotateSpeed, 0, Space.World);
		}
		if (Input.GetButton ("CameraUpRotate")) {
			transform.Rotate (rotateSpeed, 0, 0, Space.Self);
		}
		if (Input.GetButton ("CameraDownRotate")) {
			transform.Rotate (-rotateSpeed, 0, 0, Space.Self);
		}
		if (Input.GetKeyUp(KeyCode.Space)) {
			print (transform.rotation.x);
			print (transform.rotation.y);
			print (transform.rotation.z);
		}
	}
}
