using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RayController : MonoBehaviour {
	private RaycastHit hitInfo;
	private GameObject mainCamera;   // Main Camera
	private GameObject rayControl;   // Ray Control Object
	private StarInfo hitStarInfo;
	private PlanetInfo hitPlanetInfo;

	private GameObject mainPanel;    // Infomation Panel
	public Text name;
	public Text description;

	// Use this for initialization
	void Start () {
		mainCamera = GameObject.Find("CameraControl/Main Camera");
		rayControl = GameObject.Find ("CameraControl/Main Camera/RayControl");

		mainPanel = GameObject.Find ("Infomation/Panel");
		name = GameObject.Find ("Infomation/Panel/Name").GetComponent<Text> ();
		description = GameObject.Find ("Infomation/Panel/Description/Text").GetComponent<Text> ();

		mainPanel.SetActive (false); // 最初は非表示
	}
	
	// Update is called once per frame
	void Update () {
		ShowInfomation ();
	}


	private void ShowInfomation() {
		// 何も当たらない場合は消す
		if (Input.GetButtonDown ("ShowInfomation")) {
			if (Physics.Raycast (mainCamera.transform.position, rayControl.transform.position, out hitInfo)) {
				// 当たった場合パネルが非表示なら表示させる
				if (mainPanel.activeSelf == false) {
					mainPanel.SetActive (true);
				}
				// あたったオブジェクトのStarInfo,PlanetInfoのコンポーネントを取得し、名前、説明を代入
				if (hitInfo.transform.CompareTag ("Star")) {
					hitStarInfo = hitInfo.transform.gameObject.GetComponent<StarInfo> ();
					name.text = hitStarInfo.name;
					description = hitStarInfo.description;
				} else if (hitInfo.transform.CompareTag ("Planet")) {
					hitPlanetInfo = hitInfo.transform.gameObject.GetComponent<PlanetInfo> ();
					name.text = hitPlanetInfo.name;
					description = hitPlanetInfo.description;
				}
			} else {
				if (mainPanel.activeSelf == true) {
					mainPanel.SetActive (false);
				}
			}
		}
	}
}
