using UnityEngine;
using System.Collections;
using System.IO;

public class CameraController : MonoBehaviour {

	public float rotateSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		RotateCamera ();

	}

	private void RotateCamera () {
		// Rotate Horizental
		if (Input.GetButton ("CameraLeftRotate")) {
			transform.Rotate(0, -rotateSpeed * Time.deltaTime, 0, Space.World);
		}
		if (Input.GetButton ("CameraRightRotate")) {
			transform.Rotate(0, rotateSpeed * Time.deltaTime, 0, Space.World);
		}
		// Rotate Vertical
		// 各回転制限値はオフセットを考えているためちょっとはみ出している
		if (Input.GetButton ("CameraUpRotate")) {
			if ( (transform.eulerAngles.x > -10f && transform.eulerAngles.x < 40f) || (transform.eulerAngles.x > 260f && transform.eulerAngles.x < 370) ) {
				transform.Rotate (-rotateSpeed * Time.deltaTime, 0, 0, Space.Self);	
			}
		}
		if (Input.GetButton ("CameraDownRotate")) {
			if ( (transform.eulerAngles.x > -10f && transform.eulerAngles.x < 30f) || (transform.eulerAngles.x > 250f && transform.eulerAngles.x < 370f)) {	
				transform.Rotate (rotateSpeed * Time.deltaTime, 0, 0, Space.Self);
			}
		}
	}
}
