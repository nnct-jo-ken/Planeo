using UnityEngine;
using System;
using System.Collections;

public class SkyController : MonoBehaviour {

	// 自転などで下の年月日時分を買えることで惑星の座標を求めることができる
	public int year, month, day, hour, minute;

	private float rotationAxis;       // 自転軸
	public int rotationSpeed;         // 自転速度

	public GameObject dialogObject;
	private int dateLimit;
	private double temporaryTime;
	private double comparision;

	// Use this for initialization
	void Start () {
		SetTime ();
		rotationAxis = CommonConstants.General.EARTH_AXIS;
		rotationSpeed = 1;

		temporaryTime = Time.realtimeSinceStartup;
		comparision = 60;
		// RotateByTime(
	}
	void Awake () {
	}


	// Update is called once per frame
	void Update () {
		Rotation ();
	}

	void AddDay() {
		day++;
	}

	// 考慮されている軸などをリセット
	private void ResetRotate() {
		transform.eulerAngles = Vector3.zero;
	}

	// 地平座標系の考慮
	public void RotateAxis(float lat, float lng) {
		ResetRotate ();
		transform.Rotate (90 - lat, 0, 0);        // 緯度の考慮
		transform.Rotate (0, -15 * (lng / 15), 0); // 経度を考慮
	}

	// 一日の自転速度は23.686 164.098 903 691秒（23時間56分4.098 903 691秒）
	public void RotateByTime (){ 
		ResetRotate ();
		float totalRotate = 0f;
		// [要修正] 一月あたりに回転する量が日によって違うことを考慮してない
		// 時間があれば修正しよう
		totalRotate += month * 30f;       // 1ヶ月に30約度早くなる
		totalRotate += day/6f * 15f;
		totalRotate += hour * 15f;
		totalRotate += minute / 4f;       // minute / 60 * 15
	}

	// 自転
	public void Rotation () {
		// 1時間に15度(240秒に1度)
		//transform.Rotate (0, -rotationSpeed * Time.deltaTime, 0, Space.Self);
		transform.Rotate (0, -rotationSpeed * Time.deltaTime / 240, 0, Space.Self);

		if (Time.realtimeSinceStartup - temporaryTime >= comparision) {
			minute++;
			temporaryTime = Time.realtimeSinceStartup;
		}

		if (minute == 60) {
			minute = 0;
			hour++;
		}
		if (hour == 24) {
			hour = 0;
			day++;
		}
		dateLimit = dialogObject.GetComponent<DialogController> ().MonthEvaluate (month, year);
		if (day == dateLimit+1) {
			day = 1;
			month++;
		}
		if (month == 13) {
			month = 1;
			year++;
		}



	}
	public void RotationSpeedWasChanged(){
		if (rotationSpeed == 1) {
			comparision = 60;
		} else if (rotationSpeed == 16) {
			comparision = 3.75;
		} else if (rotationSpeed == 256) {
			comparision = 0.234375;
		}
	}


	// 時刻を現在の時間に設定
	public void SetTime() {
		year = DateTime.Now.Year;
		month = DateTime.Now.Month;
		day = DateTime.Now.Day;
		hour = DateTime.Now.Hour;
		minute = DateTime.Now.Minute;
	}
}