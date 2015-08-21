using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RayController : MonoBehaviour {
	RaycastHit hitInfo;
	GameObject camera;
	GameObject rayControl;
	StarInfo hitStarInfo;

	GameObject infoText;
	Text explainText;
	GameObject infoPanel;

	// Use this for initialization
	void Start () {
		camera = GameObject.Find("CameraControl/Main Camera");
		rayControl = GameObject.Find ("CameraControl/Main Camera/RayControl");
		infoPanel = GameObject.Find ("Canvas/Infomation");
		infoText = GameObject.Find ("Canvas/Infomation/Text");
		explainText = infoText.GetComponent <Text>();
		infoPanel.SetActive (false); // 最初は非表示
	}
	
	// Update is called once per frame
	void Update () {
		ShowInfomation ();
	}


	private void ShowInfomation() {
		// 何も当たらない場合は消す
		if (Input.GetButtonDown ("ShowInfomation")) {
			if (Physics.Raycast (camera.transform.position, rayControl.transform.position, out hitInfo)) {
				// パネルが非表示なら表示させる
				if (infoPanel.activeSelf == false) {
					infoPanel.SetActive (true);
				}
				// あたったオブジェクトのStarInfoコンポーネントを取得
				hitStarInfo = hitInfo.transform.gameObject.GetComponent<StarInfo> ();
				//explainText.text = hitStarInfo.explainText;
				// テスト用
				explainText.text = hitStarInfo.catalogNumber.ToString();
			} else {
				Debug.Log ("何もない");
				explainText.text = "";
				if (infoPanel.activeSelf == true) {
					infoPanel.SetActive (false);
				}
			}
		}
	}
}
