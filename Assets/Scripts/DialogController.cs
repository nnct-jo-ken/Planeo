using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public class DialogController : MonoBehaviour {

	private GameObject mainPanel;
	private GameObject infoPanel;
	private GameObject cursorParent;

	//drop&drop
	public GameObject firstDisplay;
	public GameObject starOptionDisplay;
	public GameObject timeOptionDisplay;
	public GameObject visualOptionDisplay;
	public GameObject objectWithStarsController;

	public float magnitude = 1;
	public int rotationSpeed = 1;
	public int year;
	public int month;
	public int date;
	public int hour;
	public int minute;
	public bool horizon = true;

	private float temporaryMagnitude;
	private int temporaryRotationSpeed;
	private int temporaryYear;
	private int temporaryMonth;
	private int temporaryDate;
	private int temporaryHour;
	private int temporaryMinute;
	private bool temporaryHorizon;

	//drop&drop
	public Text magnitudeText;
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
		MagnitudeTextSet (magnitude);
		RotationSpeedTextSet (rotationSpeed);
		YearTextSet (year);
		MonthTextSet (month);
		DateTextSet (date);
		HourTextSet (hour);
		MinuteTextSet (minute);

		//mainPanel.SetActive (false);	// 最後に初期状態ではダイアログを出さない
	}
	
	// Update is called once per frame
	void Update () {
		ShowDialog ();

	}

	//年・月・日・時・分に現在時刻を設定 
	private void SetNowTime(){
		nowTime = DateTime.Now;
		year = nowTime.Year;
		month = nowTime.Month;
		date = nowTime.Day;
		hour = nowTime.Hour;
		minute= nowTime.Minute;
	}
	//各変数を各テキストにセット
	private void MagnitudeTextSet(float mag){
		 if(mag == 8){
			magnitudeText.text = "all";
		}else{
			magnitudeText.text = mag.ToString();
		}
	}
	private void RotationSpeedTextSet(int rs){
		if (rs == 1) {
			rotationSpeedText.text = "x1";
		}else if(rs == 2) {
			rotationSpeedText.text = "x2";
		}else if(rs == 4) {
			rotationSpeedText.text = "x4";
		}else if(rs == 8) {
			rotationSpeedText.text = "x8";
		}
	}
	private void YearTextSet(int y){
		yearText.text = y.ToString();
	}
	private void MonthTextSet(int mon){
		monthText.text = mon.ToString();
	}
	private void DateTextSet(int d){
		dateText.text = d.ToString();
	}
	private void HourTextSet(int h){
		hourText.text = h.ToString();
	}
	private void MinuteTextSet(int min){
		minuteText.text = min.ToString();
	}

	//画面遷移制御
	public void StarOptionDisplay () {
		firstDisplay.SetActive (false);
		starOptionDisplay.SetActive (true);
		MagnitudeTextSet (magnitude);
		RotationSpeedTextSet (rotationSpeed);
		temporaryMagnitude = magnitude;
		temporaryRotationSpeed = rotationSpeed;
	}
	public void TimeOptionDisplay () {
		firstDisplay.SetActive (false);
		timeOptionDisplay.SetActive (true);
		YearTextSet (year);
		MonthTextSet (month);
		DateTextSet (date);
		HourTextSet (hour);
		MinuteTextSet (minute);
		temporaryYear = year;
		temporaryMonth = month;
		temporaryDate = date;
		temporaryHour = hour;
		temporaryMinute = minute;
	}
	public void VisualOptionDisplay () {
		firstDisplay.SetActive (false);
		visualOptionDisplay.SetActive (true);
		temporaryHorizon = horizon;
		horizonToggle.isOn = horizon;
	}
	public void OkButton1(){
		starOptionDisplay.SetActive (false);
		firstDisplay.SetActive (true);
		magnitude = temporaryMagnitude;
		rotationSpeed = temporaryRotationSpeed;
		objectWithStarsController.GetComponent<StarsController>().MagnitudeFilter (magnitude);

	}
	public void OkButton2(){
		timeOptionDisplay.SetActive (false);
		firstDisplay.SetActive (true);
		year = temporaryYear;
		month = temporaryMonth;
		date = temporaryDate;
		hour = temporaryHour;
		minute = temporaryMinute;

	}
	public void OkButton3(){
		visualOptionDisplay.SetActive (false);
		firstDisplay.SetActive (true);
		horizon = temporaryHorizon;
	}
	public void CancelButton1(){
		starOptionDisplay.SetActive (false);
		firstDisplay.SetActive (true);
	}
	public void CancelButton2(){
		timeOptionDisplay.SetActive (false);
		firstDisplay.SetActive (true);
	}
	public void CancelButton3(){
		visualOptionDisplay.SetActive (false);
		firstDisplay.SetActive (true);
	}

	public void MagnitudeUp(){
		if (temporaryMagnitude == 6) {
			temporaryMagnitude = 7.5f;
		} else if (temporaryMagnitude == 7.5f) {
			temporaryMagnitude = 8;
		} else if (temporaryMagnitude == 8) {
			temporaryMagnitude = 1;
		}else {
			temporaryMagnitude++;
		}
		MagnitudeTextSet (temporaryMagnitude);
	}
	public void MagnitudeDown(){
		if (temporaryMagnitude == 1) {
			temporaryMagnitude = 8;
		} else if (temporaryMagnitude == 7.5f) {
			temporaryMagnitude = 6;
		} else if (temporaryMagnitude == 8) {
			temporaryMagnitude = 7.5f;
		} else {
			temporaryMagnitude--;
		}
		MagnitudeTextSet (temporaryMagnitude);
	}
	public void RotationSpeedUp(){
		if (temporaryRotationSpeed == 1) {
			temporaryRotationSpeed = 2;
		} else if (temporaryRotationSpeed == 2) {
			temporaryRotationSpeed = 4;
		} else if (temporaryRotationSpeed == 4) {
			temporaryRotationSpeed = 8;
		} else if (temporaryRotationSpeed == 8) {
			temporaryRotationSpeed = 1;
		}
		RotationSpeedTextSet (temporaryRotationSpeed);
	}
	public void RotationSpeedDown(){
		if (temporaryRotationSpeed == 1) {
			temporaryRotationSpeed = 8;
		}else if(temporaryRotationSpeed == 2) {
			temporaryRotationSpeed = 1;
		}else if(temporaryRotationSpeed == 4) {
			temporaryRotationSpeed = 2;
		}else if(temporaryRotationSpeed == 8) {
			temporaryRotationSpeed = 4;
		}
		RotationSpeedTextSet (temporaryRotationSpeed);
	}
	public void YearUp(){
		if (temporaryYear == 2199) {
			temporaryYear = 1900;
		} else {
			temporaryYear++;
		}
		YearTextSet (temporaryYear);
	}
	public void YearDown(){
		if (temporaryYear == 1900) {
			temporaryYear = 2199;
		} else {
			temporaryYear--;
		}
		YearTextSet (temporaryYear);
	}
	public void MonthUp(){
		if (temporaryMonth == 12) {
			temporaryMonth = 1;
		} else {
			temporaryMonth++;
		}
		MonthTextSet (temporaryMonth);
	}
	public void MonthDown(){
		if (temporaryMonth == 1) {
			temporaryMonth = 12;
		} else {
			temporaryMonth--;
		}
		MonthTextSet (temporaryMonth);
	}

	private void MonthEvaluate(){
		if (temporaryMonth == 1 || temporaryMonth == 3 || temporaryMonth == 5 || temporaryMonth == 7 || temporaryMonth == 8 || temporaryMonth == 10 || temporaryMonth == 12) {
			dateLimit = 31;
		} else if (temporaryMonth == 4 || temporaryMonth == 6 || temporaryMonth == 9 || temporaryMonth == 11) {
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
		if (temporaryDate == dateLimit) {
			temporaryDate = 1;
		} else {
			temporaryDate++;
		}
		DateTextSet (temporaryDate);
	}
	public void DateDown(){
		MonthEvaluate ();
		if (temporaryDate == 1) {
			temporaryDate = dateLimit;
		} else {
			temporaryDate--;
		}
		DateTextSet (temporaryDate);
	}
	public void HourUp(){
		if (temporaryHour == 24) {
			temporaryHour = 1;
		} else {
			temporaryHour++;
		}
		HourTextSet (temporaryHour);
	}
	public void HourDown(){
		if (temporaryHour == 1) {
			temporaryHour = 24;
		} else {
			temporaryHour--;
		}
		HourTextSet (temporaryHour);
	}
	public void MinuteUp(){
		if (temporaryMinute == 60) {
			temporaryMinute = 1;
		} else {
			temporaryMinute++;
		}
		MinuteTextSet (temporaryMinute);
	}
	public void MinuteDown(){
		if (temporaryMinute == 1) {
			temporaryMinute = 60;
		} else {
			temporaryMinute--;
		}
		MinuteTextSet (temporaryMinute);
	}
	public void SetHorizon(){
		temporaryHorizon = horizonToggle.isOn;
	}
	public void Reset(){
		Debug.Log ("視点がリセットされました。");
	}


	private void InitObject () {
		mainPanel = GameObject.Find ("Dialog/BasePanel");

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


}
