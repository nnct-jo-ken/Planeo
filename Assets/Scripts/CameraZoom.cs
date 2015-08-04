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
			transform.Translate (0, 0, zoomSpeed * Time.deltaTime, Space.Self);
		}
		if (Input.GetButton ("CameraZoomOut")) {
			transform.Translate (0, 0, -zoomSpeed * Time.deltaTime, Space.Self);
		}
		if (Input.GetKeyUp (KeyCode.Space)) {
			print (transform.position.x);
			print (transform.position.y);
			print (transform.position.z);
		}
	}
}
