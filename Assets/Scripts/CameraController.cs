﻿using UnityEngine;
using System.Collections;
using System.IO;

public class CameraController : MonoBehaviour {

	public float rotateSpeed;
	public float zoomSpeed;

	private bool zoomStatus = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		RotateCamera ();
	}

	private void RotateCamera () {
		if (zoomStatus == false) {
			// Rotate Horizental
			if (Input.GetButton ("CameraLeftRotate")) {
				transform.Rotate (0, -rotateSpeed * Time.deltaTime, 0, Space.World);
			}
			else if (Input.GetButton ("CameraRightRotate")) {
				transform.Rotate (0, rotateSpeed * Time.deltaTime, 0, Space.World);
			}
			// Rotate Vertical
			// 各回転制限値はオフセットを考えているためちょっとはみ出している
			else if (Input.GetButton ("CameraUpRotate")) {
				if ((transform.localEulerAngles.x > -15f && transform.localEulerAngles.x < 35f) || (transform.localEulerAngles.x > 290f && transform.localEulerAngles.x < 370f)) {
					transform.Rotate (-rotateSpeed * Time.deltaTime, 0, 0, Space.Self);	
				}
			}
			else if (Input.GetButton ("CameraDownRotate")) {
				if ((transform.localEulerAngles.x > -15f && transform.localEulerAngles.x < 10f) || (transform.localEulerAngles.x > 280f && transform.localEulerAngles.x < 370f)) {	
					transform.Rotate (rotateSpeed * Time.deltaTime, 0, 0, Space.Self);
				}
			}
		}

	}


	private void ZoomCamera () {
		float distanceFromOrigin = Mathf.Sqrt(transform.localPosition.x*transform.localPosition.x + transform.localPosition.y*transform.localPosition.y + transform.localPosition.z*transform.localPosition.z);
		if (Input.GetButton ("CameraZoomIn")) {
			if (distanceFromOrigin < 60) {
				transform.Translate (0, 0, zoomSpeed, Space.Self);
				zoomStatus = true;
			}
		}

		if (Input.GetButton ("CameraZoomOut")) {
			if (distanceFromOrigin > 5) {
				transform.Translate (0, 0, -zoomSpeed, Space.Self);
			} else {
				zoomStatus = false;
			}
		}

	}

	public void ResetEulerAngles() {
		transform.eulerAngles = Vector3.zero;
	}
}
