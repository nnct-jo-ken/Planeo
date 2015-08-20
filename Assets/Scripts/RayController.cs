using UnityEngine;
using System.Collections;

public class RayController : MonoBehaviour {
	RaycastHit hitInfo;
	GameObject camera;
	GameObject rayControl;
	StarInfo hitStarInfo;

	// Use this for initialization
	void Start () {
		camera = GameObject.Find("CameraControl/Main Camera");
		rayControl = GameObject.Find ("CameraControl/Main Camera/RayControl");
	}
	
	// Update is called once per frame
	void Update () {
		ShowInfomation ();
	}


	private void ShowInfomation() {
		// 表示されていたらオブジェクトを破壊してから表示
		// 何も当たらない場合は破壊のみ
		if (Input.GetButtonDown ("ShowInfomation")) {
			if (Physics.Raycast (camera.transform.position, rayControl.transform.position, out hitInfo)) {
				hitStarInfo = hitInfo.transform.gameObject.GetComponent<StarInfo> ();
				Debug.Log (hitStarInfo.catalogNumber);
				Debug.DrawLine (camera.transform.position, hitInfo.point);
			} else {
				Debug.Log ("non");
				Debug.Log (camera.transform.position);
			}
		}
	}
}
