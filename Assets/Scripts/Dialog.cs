using UnityEngine;
using System.Collections;
using Kender.uGUI;

public class Dialog : MonoBehaviour {
	public GameObject dialog;
	
	public int starClass = 1;
	public int month = 1;
	public int date = 1;
	public int hour = 1;
	public bool displayHorizon = true;
	public string observationPoint;
	private string[] observationPointList = {"地球","月","火星"};
	public bool pushReset = false;
	
	public GameObject starClassBox;
	public GameObject monthBox;
	public GameObject dateBox;
	public GameObject hourBox;
	public GameObject observationPointBox;
	private ComboBox comboBox;
	
	private bool testGUI = false; //test
	
	
	void Start () {
		
	}
	
	void Update () {
		if(Input.GetButtonDown("ShowDialog")){
			if (dialog.activeSelf) {
				dialog.SetActive(false);
			}else {
				dialog.SetActive(true);
			}
		}
		
		if (pushReset) {
			//視点をリセット
			Debug.Log ("視点がリセットされました。");
			
			pushReset = false;
		}
		
		comboBox = starClassBox.GetComponent<ComboBox> ();
		starClass = comboBox.SelectedIndex + 1;
		comboBox = monthBox.GetComponent<ComboBox> ();
		month = comboBox.SelectedIndex + 1;
		comboBox = dateBox.GetComponent<ComboBox> ();
		date = comboBox.SelectedIndex + 1;
		
		comboBox = hourBox.GetComponent<ComboBox> ();
		hour = comboBox.SelectedIndex + 1;
		comboBox = observationPointBox.GetComponent<ComboBox> ();
		observationPoint = observationPointList[comboBox.SelectedIndex];
		
		//test
		if (testGUI) {
			Debug.Log ("現在の設定:"+starClass+"等星まで表示,"+month+"月"+date+"日"+hour+"時の空,観測地点 "+observationPoint);
			if (displayHorizon) {
				Debug.Log ("地平線の表示ON");
			} else {
				Debug.Log ("地平線の表示OFF");
			}
			
			testGUI = false;
		}
	}
	//test
	void OnGUI(){
		if (GUI.Button (new Rect (0, 0, 100, 20), "現在の設定")) {
			testGUI = true;
		}
	}
	
	
}