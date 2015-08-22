using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Kender.uGUI;

public class DialogController : MonoBehaviour {

	private GameObject mainPanel;
	private ComboBox magnitudeComboBox;
	private ComboBox yearComboBox;
	private ComboBox monthComboBox;
	private ComboBox dateComboBox;
	private ComboBox dayComboBox;
	private ComboBox hourComboBox;
	private ComboBox minuteComboBox;


	// Use this for initialization
	void Start () {
		InitObject ();
		SetItems ();

		mainPanel.SetActive (false);	// 最後に初期状態ではダイアログを出さない
	}
	
	// Update is called once per frame
	void Update () {
		ShowDialog ();

	}

	private void InitObject () {
		mainPanel = GameObject.Find ("Dialog/BasePanel");
		magnitudeComboBox = mainPanel.transform.FindChild
			("Magnitude/ComboBox").gameObject.GetComponent<ComboBox> ();
		yearComboBox = mainPanel.transform.FindChild
			("Date/Year/ComboBox").gameObject.GetComponent<ComboBox> ();
		monthComboBox = mainPanel.transform.FindChild
			("Date/Month/ComboBox").gameObject.GetComponent<ComboBox> ();
		dayComboBox = mainPanel.transform.FindChild
			("Date/Day/ComboBox").gameObject.GetComponent<ComboBox> ();
		hourComboBox = mainPanel.transform.FindChild
			("Time/Hour/ComboBox").gameObject.GetComponent<ComboBox> ();
		minuteComboBox = mainPanel.transform.FindChild
			("Time/Minute/ComboBox").gameObject.GetComponent<ComboBox> ();
	}

	private void ShowDialog () {
		if (Input.GetButtonDown ("ShowDialog")) {
			if (mainPanel.activeSelf == true) {
				mainPanel.SetActive (false);
				// [もともとインフォパネル、カーソルを開いていた場合は開いてあげる]
			}
			else if (mainPanel.activeSelf == false) {
				mainPanel.SetActive (true);
				// [他のカーソル、インフォパネルを閉じる]
			}
		}
	}

	private void SetItems () {
		List<string> items = new List<string> ();

		// magnitude
		for (int i = 0; i < 6; i++) {
			items.Add((i + 1).ToString ());
		}
		magnitudeComboBox.AddItemGeneric (items);
		items.Clear ();

		// year[あとで上二桁と下二桁を分離した方がいい(重いため)]
		for (int i = 2000; i < 2100; i++) {
			items.Add( i.ToString () );
			//yearComboBox.AddItems ( (i).ToString ());
		}
		yearComboBox.AddItemGeneric (items);
		items.Clear ();

		// month
		for (int i = 1; i <= 12; i++) {
			items.Add( i.ToString () );
			//monthComboBox.AddItems ( (i).ToString ());
		}
		monthComboBox.AddItemGeneric (items);
		items.Clear ();

		// day [月によって日が違うことを要修正]
		for (int i = 1; i <= 31; i++) {
			items.Add( i.ToString () );
			//dayComboBox.AddItems ( (i).ToString ());
		}
		dayComboBox.AddItemGeneric (items);
		items.Clear ();

		// hour
		for (int i = 0; i <= 23; i++) {
			items.Add( i.ToString () );
			//hourComboBox.AddItems ( (i).ToString ());
		}
		hourComboBox.AddItemGeneric (items);
		items.Clear ();

		// minute
		for (int i = 0; i <= 59; i++) {
			items.Add( i.ToString () );
			//minuteComboBox.AddItems ( (i).ToString ());
		}
		minuteComboBox.AddItemGeneric (items);
		items.Clear ();
	}
}
