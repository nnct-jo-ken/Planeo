using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public class DialogController : MonoBehaviour {

	public GameObject mainPanel;
	public GameObject infoPanel;
	public GameObject cursorParent;

	// Selectable(最初に選択されるもの)
	public Button firstSelect;
	public Button starSelect;
	public Button timeSelect;
	public Toggle VisualSelect;

	// drop&drop
	public GameObject firstDisplay;
	public GameObject starOptionDisplay;
	public GameObject timeOptionDisplay;
	public GameObject visualOptionDisplay;
	public GameObject objectWithStarsController;
	public GameObject horizonObject;
	public GameObject cameraObject;

	public float magnitude = 6;
	public int rotationSpeed = 1;
	public int year;
	public int month;
	public int date;
	public int hour;
	public int minute;
	public bool horizon = true;
	public bool mode = true;
	public int observationPoint = 0; //0:ホクト文化ホール,1:東京,2:大阪,3:アメリカ,4:イギリス,5:ブラジル,6:オーストラリア,7:火星

	private float temporaryMagnitude;
	private int temporaryRotationSpeed;
	private int temporaryYear;
	private int temporaryMonth;
	private int temporaryDate;
	private int temporaryHour;
	private int temporaryMinute;
	private bool temporaryHorizon;
	private int temporaryObservationPoint;
	public int beforeObservationPoint;
	public String selectedObservationPoint; //参照用
	private float temporaryLat = CommonConstants.LatLng.HOCTO_Lat;
	private float temporaryLng = CommonConstants.LatLng.HOCTO_Lng;

	//drop&drop
	public Text magnitudeText;
	public Text rotationSpeedText;
	public Text yearText;
	public Text monthText;
	public Text dateText;
	public Text hourText;
	public Text minuteText;
	public Toggle horizonToggle;
	public Toggle modeToggle;
	public Text observationPointText;

	public DateTime nowTime;
	private int dateLimit;

	private bool isInfoPanel = false;
	private bool isCursor = false;


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
		ObservationPointTextSet (observationPoint);
		objectWithStarsController.GetComponent<StarsController>().MagnitudeFilter (magnitude);

		mainPanel.SetActive (false);	// 最後に初期状態ではダイアログを出さない

		//最初の緯度・経度をホクト文化ホールに設定
		objectWithStarsController.GetComponent<SkyController> ().RotateByTime ();
		objectWithStarsController.GetComponent<SkyController> ().RotateAxis(temporaryLat,temporaryLng);
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
		}else if(rs == 16) {
			rotationSpeedText.text = "x16";
		}else if(rs == 256) {
			rotationSpeedText.text = "x256";
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
	private void ObservationPointTextSet(int op){  //0:ホクト文化ホール,1:東京,2:大阪,3:アメリカ,4:イギリス,5:ブラジル,6:オーストラリア,7:火星
		if (op == 0) {
			observationPointText.text = "ホクト文化ホール";
		} else if (op == 1) {
			observationPointText.text = "東京";
		} else if (op == 2) {
			observationPointText.text = "大阪";
		} else if (op == 3) {
			observationPointText.text = "アメリカ";
		} else if (op == 4) {
			observationPointText.text = "イギリス";
		} else if (op == 5) {
			observationPointText.text = "ブラジル";
		} else if (op == 6) {
			observationPointText.text = "オーストラリア";
		} else if (op == 7) {
			observationPointText.text = "火星";
		}
	}

	//画面遷移制御
	public void StarOptionDisplay () {
		firstDisplay.SetActive (false);
		starOptionDisplay.SetActive (true);
		starSelect.Select ();
		MagnitudeTextSet (magnitude);
		RotationSpeedTextSet (rotationSpeed);
		temporaryMagnitude = magnitude;
		temporaryRotationSpeed = rotationSpeed;
	}
	public void TimeOptionDisplay () {
		firstDisplay.SetActive (false);
		timeOptionDisplay.SetActive (true);
		timeSelect.Select ();
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
		VisualSelect.Select ();
		temporaryHorizon = horizon;
		horizonToggle.isOn = horizon;
		temporaryObservationPoint = observationPoint;
	}
	public void OkButton1(){
		starOptionDisplay.SetActive (false);
		firstDisplay.SetActive (true);
		firstSelect.Select ();
		magnitude = temporaryMagnitude;
		rotationSpeed = temporaryRotationSpeed;
		objectWithStarsController.GetComponent<StarsController>().MagnitudeFilter (magnitude);

		objectWithStarsController.GetComponent<SkyController>().rotationSpeed = rotationSpeed;

	}
	public void OkButton2(){
		timeOptionDisplay.SetActive (false);
		firstDisplay.SetActive (true);
		firstSelect.Select ();
		year = temporaryYear;
		month = temporaryMonth;
		date = temporaryDate;
		hour = temporaryHour;
		minute = temporaryMinute;
		objectWithStarsController.GetComponent<SkyController> ().year = year;
		objectWithStarsController.GetComponent<SkyController> ().month = month;
		objectWithStarsController.GetComponent<SkyController> ().day = date;
		objectWithStarsController.GetComponent<SkyController> ().hour = hour;
		objectWithStarsController.GetComponent<SkyController> ().minute = minute;

		objectWithStarsController.GetComponent<SkyController> ().RotateByTime ();
		objectWithStarsController.GetComponent<SkyController> ().RotateAxis(temporaryLat,temporaryLng);
	}
	public void OkButton3(){
		visualOptionDisplay.SetActive (false);
		firstDisplay.SetActive (true);
		firstSelect.Select ();
		horizon = temporaryHorizon;
		observationPoint = temporaryObservationPoint;
		selectedObservationPoint = observationPointText.text;
		horizonObject.SetActive (horizon);

		if (observationPoint == 0) {//ホクト文化ホール
			temporaryLat = CommonConstants.LatLng.HOCTO_Lat;
			temporaryLng = CommonConstants.LatLng.HOCTO_Lng;
		} else if (observationPoint == 1) {//"東京"
			temporaryLat = CommonConstants.LatLng.TOKYO_Lat;
			temporaryLng = CommonConstants.LatLng.TOKYO_Lng;
		} else if (observationPoint == 2) {//"大阪"
			temporaryLat = CommonConstants.LatLng.OSAKA_Lat;
			temporaryLng = CommonConstants.LatLng.OSAKA_Lng;
		} else if (observationPoint == 3) {//"アメリカ"
			temporaryLat = CommonConstants.LatLng.AMERICA_Lat;
			temporaryLng = CommonConstants.LatLng.AMERICA_Lng;
		} else if (observationPoint == 4) {//"イギリス"
			temporaryLat = CommonConstants.LatLng.UK_Lat;
			temporaryLng = CommonConstants.LatLng.UK_Lng;
		} else if (observationPoint == 5) {//"ブラジル"
			temporaryLat = CommonConstants.LatLng.BRAZIL_Lat;
			temporaryLng = CommonConstants.LatLng.BRAZIL_Lng;
		} else if (observationPoint == 6) {//"オーストラリア"
			temporaryLat = CommonConstants.LatLng.NZ_Lat;
			temporaryLng = CommonConstants.LatLng.NZ_Lng;
		}
		objectWithStarsController.GetComponent<SkyController> ().RotateByTime ();
		objectWithStarsController.GetComponent<SkyController> ().RotateAxis(temporaryLat,temporaryLng);

	}
	public void CancelButton1(){
		starOptionDisplay.SetActive (false);
		firstDisplay.SetActive (true);
		firstSelect.Select ();
	}
	public void CancelButton2(){
		timeOptionDisplay.SetActive (false);
		firstDisplay.SetActive (true);
		firstSelect.Select ();
	}
	public void CancelButton3(){
		visualOptionDisplay.SetActive (false);
		firstDisplay.SetActive (true);
		firstSelect.Select ();
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
			temporaryRotationSpeed = 16;
		} else if (temporaryRotationSpeed == 16) {
			temporaryRotationSpeed = 256;
		} else if (temporaryRotationSpeed == 256) {
			temporaryRotationSpeed = 1;
		} 
		RotationSpeedTextSet (temporaryRotationSpeed);
	}
	public void RotationSpeedDown(){
		if (temporaryRotationSpeed == 1) {
			temporaryRotationSpeed = 256;
		}else if(temporaryRotationSpeed == 16) {
			temporaryRotationSpeed = 1;
		}else if(temporaryRotationSpeed == 256) {
			temporaryRotationSpeed = 16;
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

		temporaryDate = 1;
		DateTextSet (temporaryDate);

		MonthTextSet (temporaryMonth);
	}
	public void MonthDown(){
		if (temporaryMonth == 1) {
			temporaryMonth = 12;
		} else {
			temporaryMonth--;
		}

		temporaryDate = 1;
		DateTextSet (temporaryDate);

		MonthTextSet (temporaryMonth);
	}

	private void MonthEvaluate(){
		if (temporaryMonth == 1 || temporaryMonth == 3 || temporaryMonth == 5 || temporaryMonth == 7 || temporaryMonth == 8 || temporaryMonth == 10 || temporaryMonth == 12) {
			dateLimit = 31;
		} else if (temporaryMonth == 4 || temporaryMonth == 6 || temporaryMonth == 9 || temporaryMonth == 11) {
			dateLimit = 30;
			//閏年:1904,1908,・・・(西暦年が4で割り切れる年は閏年。ただし、西暦年が100で割り切れる年は平年。ただし、西暦年が400で割り切れる年は閏年。1900年は閏年ではないが2000は閏年)
		} else {
			if (temporaryYear % 400 == 0 || (temporaryYear % 4 == 0 && temporaryYear % 100 != 0)) {
				dateLimit = 29;
			}else {
				dateLimit = 28;
			}
		}
	}
	public void DateUp(){
		MonthEvaluate ();
		if (temporaryDate >= dateLimit) {
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
		if (temporaryHour == 23) {
			temporaryHour = 0;
		} else {
			temporaryHour++;
		}
		HourTextSet (temporaryHour);
	}
	public void HourDown(){
		if (temporaryHour == 0) {
			temporaryHour = 23;
		} else {
			temporaryHour--;
		}
		HourTextSet (temporaryHour);
	}
	public void MinuteUp(){
		if (temporaryMinute == 59) {
			temporaryMinute = 0;
		} else {
			temporaryMinute++;
		}
		MinuteTextSet (temporaryMinute);
	}
	public void MinuteDown(){
		if (temporaryMinute == 0) {
			temporaryMinute = 59;
		} else {
			temporaryMinute--;
		}
		MinuteTextSet (temporaryMinute);
	}
	public void SetHorizon(){
		temporaryHorizon = horizonToggle.isOn;
	}
	public void SetMode(){
		mode = modeToggle.isOn;
		if (mode) {
			observationPoint = beforeObservationPoint;
			ObservationPointTextSet (observationPoint);
			selectedObservationPoint = observationPointText.text;
		} else {
			beforeObservationPoint = observationPoint;
			observationPoint = 5;
			ObservationPointTextSet (observationPoint);
			selectedObservationPoint = "火星";
		}
	}
	public void Reset(){
		Debug.Log ("視点がリセットされました。");
		cameraObject.GetComponent<CameraController> ().ResetEulerAngles ();
	}
	public void ObservationPointUp(){
		if (mode) {
			if (temporaryObservationPoint == 6) {
				temporaryObservationPoint = 0;
			} else {
				temporaryObservationPoint++;
			}
			ObservationPointTextSet (temporaryObservationPoint);
		}
	}
	public void ObservationPointDown(){
		if (mode) {
			if (temporaryObservationPoint == 0) {
				temporaryObservationPoint = 6;
			} else {
				temporaryObservationPoint--;
			}
			ObservationPointTextSet (temporaryObservationPoint);
		}
	}


	private void InitObject () {
		//mainPanel = transform.FindChild ("Panel");
		//infoPanel = GameObject.Find ("Infomation/Panel");
		//cursorParent = GameObject.Find ("Cursor/CursorControl");
	}

	private void ShowDialog () {
		if (Input.GetButtonDown ("ShowDialog")) {
			if (mainPanel.activeSelf == true) {
				mainPanel.SetActive (false);
				// インフォパネル、カーソルをオンに
				infoPanel.SetActive (isInfoPanel);
				cursorParent.SetActive (isCursor); 
			}
			else if (mainPanel.activeSelf == false) {
				mainPanel.SetActive (true);
				firstSelect.Select ();
				isInfoPanel = infoPanel.activeSelf;
				isCursor = cursorParent.activeSelf;
				// カーソル、インフォパネルを閉じる
				infoPanel.SetActive (false);
				cursorParent.SetActive (false);
			}
		}
	}


}
