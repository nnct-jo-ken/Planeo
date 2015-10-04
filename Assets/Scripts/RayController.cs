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
	public Text nameText;
	public Text descriptionText;
	public GameObject dialog;

	// Use this for initialization
	void Start () {
		mainCamera = GameObject.Find("CameraControl/Main Camera");
		rayControl = GameObject.Find ("CameraControl/Main Camera/RayControl");

		mainPanel = GameObject.Find ("Infomation/Panel");
		nameText = GameObject.Find ("Infomation/Panel/Name").GetComponent<Text> ();
		descriptionText = GameObject.Find ("Infomation/Panel/Description/Text").GetComponent<Text> ();

		mainPanel.SetActive (false); // 最初は非表示
	}
	
	// Update is called once per frame
	void Update () {
		ShowInfomation ();
	}


	private void ShowInfomation() {
		// 何も当たらない場合は消す
		if (Input.GetButtonDown ("ShowInfomation") && dialog.activeSelf == false) {

			if (Physics.Raycast (mainCamera.transform.position, rayControl.transform.position, out hitInfo)) {
				Debug.Log ("打ててあa");
				// 当たった場合パネルが非表示なら表示させる
				if (mainPanel.activeSelf == false) {
					mainPanel.SetActive (true);
				}
				// あたったオブジェクトのStarInfo,PlanetInfoのコンポーネントを取得し、名前、説明を代入
				if (hitInfo.collider.tag == "Star") {
					//	if (hitInfo.transform.CompareTag ("Star")) {
					hitStarInfo = hitInfo.transform.gameObject.GetComponent<StarInfo> ();
					nameText.text = hitStarInfo.name.ToString ();
					descriptionText.text = hitStarInfo.description.ToString ();
					Debug.Log ("恒星当たってる");
				} else if (hitInfo.transform.CompareTag ("Planet")) {
					hitPlanetInfo = hitInfo.transform.gameObject.GetComponent<PlanetInfo> ();
					nameText.text = hitPlanetInfo.name.ToString ();
					descriptionText.text = hitPlanetInfo.description.ToString ();
					Debug.Log ("惑星当たってる");
				}
			} else {
				if (mainPanel.activeSelf == true) {
					mainPanel.SetActive (false);
					Debug.Log ("当たってない");
				}
			}
		}
	}
}
