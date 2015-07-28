using UnityEngine;
using System.Collections;
using System.IO;

public class CameraController : MonoBehaviour {

	public float rotateSpeed = 0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		// Rotate
		if (Input.GetButton ("CameraLeftRotate")) {
			transform.Rotate(0, rotateSpeed, 0, Space.Self);
		}
		if (Input.GetButton ("CameraRightRotate")) {
			transform.Rotate(0, -rotateSpeed, 0, Space.Self);
		}


	}
}
