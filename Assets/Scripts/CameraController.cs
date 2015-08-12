/*
 * カメラコントロール用スクリプト
 * カメラのズーム、回転
 * 	[要修正]ズーム時に回転をするように
 * 		- ズームしたらなんかしら別オブジェクトにするとか？
 */

using UnityEngine;
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

		ZoomCamera ();
		RotateCamera ();
	}

	private void RotateCamera () {
		if (zoomStatus == false) {
			// Rotate Horizental
			if (Input.GetButton ("CameraLeftRotate")) {
				transform.Rotate (0, -rotateSpeed * Time.deltaTime, 0, Space.World);
			}
			if (Input.GetButton ("CameraRightRotate")) {
				transform.Rotate (0, rotateSpeed * Time.deltaTime, 0, Space.World);
			}
			// Rotate Vertical
			// 各回転制限値はオフセットを考えているためちょっとはみ出している
			if (Input.GetButton ("CameraUpRotate")) {
				if ((transform.eulerAngles.x > -5f && transform.eulerAngles.x < 35f) || (transform.eulerAngles.x > 290f && transform.eulerAngles.x < 370f)) {
					transform.Rotate (-rotateSpeed * Time.deltaTime, 0, 0, Space.Self);	
				}
			}
			if (Input.GetButton ("CameraDownRotate")) {
				if ((transform.eulerAngles.x > -5f && transform.eulerAngles.x < 30f) || (transform.eulerAngles.x > 280f && transform.eulerAngles.x < 370f)) {	
					transform.Rotate (rotateSpeed * Time.deltaTime, 0, 0, Space.Self);
				}
			}
		}
	}


	private void ZoomCamera () {
		float distanceFromOrigin = Mathf.Sqrt(transform.position.x*transform.position.x + transform.position.y*transform.position.y + transform.position.z*transform.position.z);
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
}
