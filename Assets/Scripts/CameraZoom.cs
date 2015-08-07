using UnityEngine;
using System.Collections;

public class CameraZoom : MonoBehaviour {

	public float zoomSpeed;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		ZoomCamera ();

	}

	private void ZoomCamera () {
		if (Input.GetButton ("CameraZoomIn")) {
			if (transform.position.z < 60) {
				transform.Translate (0, 0, zoomSpeed, Space.Self);
			}
		}
		if (Input.GetButton ("CameraZoomOut")) {
			if (transform.position.z > 0) {
				transform.Translate (0, 0, -zoomSpeed, Space.Self);
			}
		}
		if (Input.GetKeyUp (KeyCode.Space)) {
			print (transform.position.x);
			print (transform.position.y);
			print (transform.position.z);
		}
	}
}
