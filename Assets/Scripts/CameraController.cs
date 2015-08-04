using UnityEngine;
using System.Collections;
using System.IO;

public class CameraController : MonoBehaviour {

	public float rotateSpeed;
	public float zoomSpeed;
	private float cameraRotateUpLimit = -0.6f;
	private float cameraRotateDownLimit = 0.2f;
	private bool zoomStatus = false;
	//private float cameraZoomInLimit = 10;
	//private float cameraZoomOutLimit = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		RotateCamera ();
		ZoomCamera ();

	}

	private void RotateCamera () {
		if (Input.GetButton ("CameraLeftRotate")) {
			if (zoomStatus == false) {
				transform.Rotate(0, -rotateSpeed * Time.deltaTime, 0, Space.World);
			}
			//transform.Rotate(0, -rotateSpeed * Time.deltaTime, 0, Space.Self);
		}
		if (Input.GetButton ("CameraRightRotate")) {
			if (zoomStatus == false) {
				transform.Rotate(0, rotateSpeed * Time.deltaTime, 0, Space.World);
			}
			//transform.Rotate(0, rotateSpeed * Time.deltaTime, 0, Space.Self);
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

	private bool ZoomCamera () {
		bool zoomStatus;
		if (Input.GetButton ("CameraZoomIn")) {
			transform.Translate (0, 0, zoomSpeed * Time.deltaTime, Space.Self);
			zoomStatus = true;		
		}
		if (Input.GetButton ("CameraZoomOut")) {
			transform.Translate (0, 0, -zoomSpeed * Time.deltaTime, Space.Self);
			zoomStatus = true;
		}
		return zoomStatus;
	}
}
