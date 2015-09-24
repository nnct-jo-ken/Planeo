using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Kender.uGUI;
using UnityEngine.UI;
using System;

public class DialogController : MonoBehaviour {

	private GameObject mainPanel;
	/*
	private ComboBox magnitudeComboBox;
	private ComboBox yearComboBox;
	private ComboBox monthComboBox;
	private ComboBox dateComboBox;
	private ComboBox dayComboBox;
	private ComboBox hourComboBox;
	private ComboBox minuteComboBox;
*/
	private GameObject infoPanel;
	private GameObject cursorParent;

	//drop&drop
	public GameObject firstDisplay;
	public GameObject starOptionDisplay;
	public GameObject timeOptionDisplay;
	public GameObject visualOptionDisplay;

	public int starClass = 1;
	public int rotationSpeed = 1;
	public int year;
	public int month;
	public int date;
	public int hour;
	public int minute;
	public bool horizon = true;

	//drop&drop
	public Text starClassText;
	public Text rotationSpeedText;
	public Text yearText;
	public Text monthText;
	public Text dateText;
	public Text hourText;
	public Text minuteText;
	public Toggle horizonToggle;

	public DateTime nowTime;
	private int dateLimit;


	// Use this for initialization
	void Start () {
		InitObject ();
		//初期値をテキストに
		SetNowTime ();
		StarClassTextSet ();
		RotationSpeedTextSet ();
		YearTextSet ();
		MonthTextSet ();
		DateTextSet ();
		HourTextSet ();
		MinuteTextSet ();

		//SetItems ();

		//mainPanel.SetActive (false);	// 最後に初期状態ではダイアログを出さない
	}
	
	// Update is called once per frame
	void Update () {
		ShowDialog ();

	}

	private void SetNowTime(){
		nowTime = DateTime.Now;
		year = nowTime.Year;
		month = nowTime.Month;
		date = nowTime.Day;
		hour = nowTime.Hour;
		minute= nowTime.Minute;
	}
	private void StarClassTextSet(){
		 if(starClass == 8){
			starClassText.text = "all";
		}else{
			starClassText.text = starClass.ToString();
		}
	}
	private void RotationSpeedTextSet(){
		if (rotationSpeed == 1) {
			rotationSpeedText.text = "x1";
		}else if(rotationSpeed == 2) {
			rotationSpeedText.text = "x2";
		}else if(rotationSpeed == 4) {
			rotationSpeedText.text = "x4";
		}else if(rotationSpeed == 8) {
			rotationSpeedText.text = "x8";
		}
	}
	private void YearTextSet(){
		yearText.text = year.ToString();
	}
	private void MonthTextSet(){
		monthText.text = month.ToString();
	}
	private void DateTextSet(){
		dateText.text = date.ToString();
	}
	private void HourTextSet(){
		hourText.text = hour.ToString();
	}
	private void MinuteTextSet(){
		minuteText.text = minute.ToString();
	}

	public void StarOptionDisplay () {
		firstDisplay.SetActive (false);
		starOptionDisplay.SetActive (true);
		StarClassTextSet ();
		RotationSpeedTextSet ();
	}
	public void TimeOptionDisplay () {
		firstDisplay.SetActive (false);
		timeOptionDisplay.SetActive (true);
	}
	public void VisualOptionDisplay () {
		firstDisplay.SetActive (false);
		visualOptionDisplay.SetActive (true);	
	}
	public void BackToFirst1(){
		starOptionDisplay.SetActive (false);
		firstDisplay.SetActive (true);
	}
	public void BackToFirst2(){
		timeOptionDisplay.SetActive (false);
		firstDisplay.SetActive (true);
	}
	public void BackToFirst3(){
		visualOptionDisplay.SetActive (false);
		firstDisplay.SetActive (true);
	}
	public void StarClassUp(){
		if (starClass == 6) {
//			starClass = 7.5;
		} else if (starClass == 7.5) {
			starClass = 8;
		} else if (starClass == 8) {
			starClass = 1;
		}else {
			starClass++;
		}
		StarClassTextSet ();
	}
	public void StarClassDown(){
		if (starClass == 1) {
			starClass = 8;
		} else if (starClass == 7.5) {
			starClass = 6;
		} else if (starClass == 8) {
//			starClass = 7.5;
		} else {
			starClass--;
		}
		StarClassTextSet ();
	}
	public void RotationSpeedUp(){
		if (rotationSpeed == 1) {
			rotationSpeed = 2;
		} else if (rotationSpeed == 2) {
			rotationSpeed = 4;
		} else if (rotationSpeed == 4) {
			rotationSpeed = 8;
		} else if (rotationSpeed == 8) {
			rotationSpeed = 1;
		}
		RotationSpeedTextSet ();
	}
	public void RotationSpeedDown(){
		if (rotationSpeed == 1) {
			rotationSpeed = 8;
		}else if(rotationSpeed == 2) {
			rotationSpeed = 1;
		}else if(rotationSpeed == 4) {
			rotationSpeed = 2;
		}else if(rotationSpeed == 8) {
			rotationSpeed = 4;
		}
		RotationSpeedTextSet ();
	}
	public void YearUp(){
		if (year == 2199) {
			year = 1900;
		} else {
			year++;
		}
		YearTextSet ();
	}
	public void YearDown(){
		if (year == 1900) {
			year = 2199;
		} else {
			year--;
		}
		YearTextSet ();
	}
	public void MonthUp(){
		if (month == 12) {
			month = 1;
		} else {
			month++;
		}
		MonthTextSet ();
	}
	public void MonthDown(){
		if (month == 1) {
			month = 12;
		} else {
			month--;
		}
		MonthTextSet ();
	}

	private void MonthEvaluate(){
		if (month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12) {
			dateLimit = 31;
		} else if (month == 4 || month == 6 || month == 9 || month == 11) {
			dateLimit = 30;
			//閏年:1904,1908,・・・(西暦年が4で割り切れる年は閏年。ただし、西暦年が100で割り切れる年は平年。ただし、西暦年が400で割り切れる年は閏年。1900年は閏年ではないが2000は閏年)
		} else {
			if (year % 400 == 0 || (year % 4 == 0 && year % 100 != 0)) {
				dateLimit = 29;
			}else {
				dateLimit = 28;
			}
		}
	}
	public void DateUp(){
		MonthEvaluate ();
		if (date == dateLimit) {
			date = 1;
		} else {
			date++;
		}
		DateTextSet ();
	}
	public void DateDown(){
		MonthEvaluate ();
		if (date == 1) {
			date = dateLimit;
		} else {
			date--;
		}
		DateTextSet ();
	}
	public void HourUp(){
		if (hour == 24) {
			hour = 1;
		} else {
			hour++;
		}
		HourTextSet ();
	}
	public void HourDown(){
		if (hour == 1) {
			hour = 24;
		} else {
			hour--;
		}
		HourTextSet ();
	}
	public void MinuteUp(){
		if (minute == 60) {
			minute = 1;
		} else {
			minute++;
		}
		MinuteTextSet ();
	}
	public void MinuteDown(){
		if (minute == 1) {
			minute = 60;
		} else {
			minute--;
		}
		MinuteTextSet ();
	}
	public void SetHorizon(){
		horizon = horizonToggle.isOn;
	}
	public void Reset(){
		Debug.Log ("視点がリセットされました。");
	}


	private void InitObject () {
		mainPanel = GameObject.Find ("Dialog/BasePanel");
		/*
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
		*/
		infoPanel = GameObject.Find ("InfoCanvas");
		cursorParent = GameObject.Find ("Canvas/CursorControl");
	}

	private void ShowDialog () {
		if (Input.GetButtonDown ("ShowDialog")) {
			if (mainPanel.activeSelf == true) {
				mainPanel.SetActive (false);
				// インフォパネル、カーソルをオンに
				infoPanel.SetActive (true);
				cursorParent.SetActive (true); 
			}
			else if (mainPanel.activeSelf == false) {
				mainPanel.SetActive (true);
				// カーソル、インフォパネルを閉じる
				infoPanel.SetActive (false);
				cursorParent.SetActive (false);
			}
		}
	}

	/*
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
	}*/
}
