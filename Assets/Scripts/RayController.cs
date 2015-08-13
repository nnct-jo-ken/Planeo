using UnityEngine;
using System.Collections;

public class RayController : MonoBehaviour {
	RaycastHit hitInfo;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	private void ShowInfomation() {
		GameObject camera = GameObject.Find("CameraControl/Main Camera");
		// 表示されていたらオブジェクトを破壊してから表示
		// 何も当たらない場合は破壊のみ
		if (Input.GetButtonDown ("ShowInfomation")) {
			Physics.Raycast (Vector3.zero, camera.transform.position, out hitInfo);
		}
	}
}
