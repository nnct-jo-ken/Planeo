using UnityEngine;
using System.Collections;
using System.IO;

public class CameraController : MonoBehaviour {

	public float rotateSpeed;
	private float cameraRotateUpLimit = -0.6f;
	private float cameraRotateDownLimit = 0.2f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		RotateCamera ();





	}

	private void RotateCamera () {
		if (Input.GetButton ("CameraLeftRotate")) {
			transform.Rotate(0, -rotateSpeed * Time.deltaTime, 0, Space.World);
		}
		if (Input.GetButton ("CameraRightRotate")) {
			transform.Rotate(0, rotateSpeed * Time.deltaTime, 0, Space.World);
		}
		if (Input.GetButton ("CameraUpRotate")) {
			if (transform.rotation.x > cameraRotateUpLimit) {
				transform.Rotate (-rotateSpeed * Time.deltaTime, 0, 0, Space.Self);	
			}
		}
		if (Input.GetButton ("CameraDownRotate")) {
			if (transform.rotation.x < cameraRotateDownLimit) {	
				transform.Rotate (rotateSpeed * Time.deltaTime, 0, 0, Space.Self);
			}
		}
	}


}
