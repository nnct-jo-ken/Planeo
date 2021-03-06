﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RayController : MonoBehaviour {
	private RaycastHit hitInfo;
	private GameObject mainCamera;   // Main Camera
	private StarInfo hitStarInfo;
	private PlanetInfo hitPlanetInfo;

	private GameObject mainPanel;    // Infomation Panel
	private Text nameText;
	private Text descriptionText;

	public Vector3 rayDirection;

	public GameObject dialog;
	public GameObject parent;

	// Use this for initialization
	void Start () {
		mainCamera = GameObject.Find("CameraControl/Main Camera");

		mainPanel = GameObject.Find ("Infomation/Panel");
		nameText = GameObject.Find ("Infomation/Panel/Name").GetComponent<Text> ();
		descriptionText = GameObject.Find ("Infomation/Panel/Description").GetComponent<Text> ();

		mainPanel.SetActive (false); // 最初は非表示
	}
	
	// Update is called once per frame
	void Update () {
		ShowInfomation ();
	}


	private void ShowInfomation() {
		// 何も当たらない場合は消す
		if (Input.GetButtonDown ("ShowInfomation") && dialog.activeSelf == false) {
			rayDirection = new Vector3 (transform.position.x, transform.position.y - parent.transform.position.y, transform.position.z);
			if (Physics.Raycast (mainCamera.transform.position, rayDirection, out hitInfo, 1000f)) {
				Debug.DrawLine (mainCamera.transform.position, hitInfo.point, Color.blue, 5);
				// 当たった場合パネルが非表示なら表示させる
				if (mainPanel.activeSelf == false) {
					mainPanel.SetActive (true);
				}
				// あたったオブジェクトのStarInfo,PlanetInfoのコンポーネントを取得し、名前、説明を代入
				if (hitInfo.collider.tag == "Star") {
					hitStarInfo = hitInfo.transform.gameObject.GetComponent<StarInfo> ();
					nameText.text = hitStarInfo.name.ToString ();
					descriptionText.text = hitStarInfo.description.ToString ();
				} else if (hitInfo.collider.tag == "Planet") {
					hitPlanetInfo = hitInfo.transform.gameObject.GetComponent<PlanetInfo> ();
					nameText.text = hitPlanetInfo.name.ToString ();
					descriptionText.text = hitPlanetInfo.description.ToString ();
				}
			} else {
				if (mainPanel.activeSelf == true) {
					mainPanel.SetActive (false);
				}
				rayDirection = new Vector3(transform.position.x*100, (transform.position.y - parent.transform.position.y)*100, transform.position.z*100);
				Debug.DrawRay (mainCamera.transform.position, rayDirection, Color.red, 5);
			}
		}
	}
}
