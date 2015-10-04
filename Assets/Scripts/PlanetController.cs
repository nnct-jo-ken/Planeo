﻿using UnityEngine;
using System;
using System.Collections;

public enum Planet {
	Mercury,   // 水星
	Venus,     // 金星
	Earth,     // 地球
	Mars,      // 火星
	Jupiter,   // 木星
	Saturn,    // 土星
	Uranus,    // 天王星
	Neptune,   // 海王星
}

public class PlanetController : MonoBehaviour {

	public GameObject [] planets = new GameObject[CommonConstants.Planet.QTY];
	public PlanetInfo [] components = new PlanetInfo[CommonConstants.Planet.QTY];

	public SkyController sky;

	// Use this for initialization
	void Start () {
		sky = GetComponent<SkyController> ();
		CreatePlanetEntity ();
		AddPlanetInfo ();
		AddPlanetTag ();
		ReadData ();
		Rename ();
	}
	
	// Update is called once per frame
	void Update () {
		InvokeRepeating ("SetPosition", 0, 60);
	}


	// Create Objetct Entity
	void CreatePlanetEntity () {
		GameObject parentObject = GameObject.Find("Sky/Planet");
		for (int i = 0; i < planets.Length; i++) {
			planets [i] = GameObject.CreatePrimitive (PrimitiveType.Sphere);
			planets [i].transform.parent = parentObject.transform;
		}
	}
	void SetPosition () {
		float time;
		time = DiffTime (sky.year, sky.month, sky.day, sky.hour, 0);     // 現時点では分を計算しない
		EvalXy (time);
		EvalPosition ();

		for (int i = 0; i < planets.Length; i++) {
			planets [i].transform.position = components [i].planetPosition;
		}
	}

	// Add Planet Infomation to each object
	private void AddPlanetInfo () {
		for (int i = 0; i < planets.Length; i++) {
			components [i] = planets [i].AddComponent <PlanetInfo> ();
		}
	}

	// Add Tag "Planet"
	private void AddPlanetTag () {
		for (int i = 0; i < planets.Length; i++) {
			planets [i].tag = "Planet";
		}
	}
	// Reading CSV File from Assets/Resources
	private string[,] ReadCsv(string fileName){
		TextAsset ta = Resources.Load(fileName,typeof(TextAsset)) as TextAsset;
		string[] lineArray = ta.text.Replace("\r\n", "\n").Split('\n');
		ArrayList dataList = new ArrayList (lineArray);

		int lineCount = dataList.Count;
		string tmp = dataList [0].ToString();
		string[] tmp2 = tmp.Split(","[0]);
		int colCount = tmp2.Length;
		string[,] tmpCsvData = new string[lineCount,colCount];
		int i = 0;

		foreach(string str1 in dataList){
			int j = 0;
			string[] tempLine = str1.Split(',');
			foreach(string str2 in tempLine){
				tmpCsvData[i,j] = str2;
				j++;
			}
			i++;
		}
		return tmpCsvData;
	}

	// データの取得
	private void ReadData() {
		string[,] csvData = ReadCsv ("planet");

		for (int i = 0; i < CommonConstants.Planet.QTY; i++) {
			components [i].englishName = csvData [1 + i, 0].ToString ();
			components [i].semiMejorAxisAu = float.Parse (csvData [1 + i, 1]);
			components [i].eccentricity = float.Parse (csvData [1 + i, 2]);
			components [i].inclination = float.Parse (csvData [1 + i, 3]);
			components [i].lngPerihelion = float.Parse (csvData [1 + i, 4]);
			components [i].planeEcliptic = float.Parse (csvData [1 + i, 5]);
			components [i].epochMeanAnomaly = float.Parse (csvData [1 + i, 6]);
			components [i].orbitalPeriod = float.Parse (csvData [1 + i, 7]);
			components [i].name = csvData [1 + i, 8].ToString ();
			components [i].description = csvData [1 + i, 9].ToString ();
		}
	}

	// ゲームオブジェクトの名前をそれぞれの惑星の名前に変更
	private void Rename() {
		for (int i = 0; i < planets.Length; i++) {
			planets [i].name = components [i].englishName;
		}
	}

	private float EvalKepler (float time, float eccentricity, float revolutionCycle, float epochMeanAnomaly) {
		// Kepler's equation を Newton法 で解く
		// l = u - e*sin(u)
		float meanMotion = 2 * Mathf.PI / (revolutionCycle * CommonConstants.General.JULIAN_YEAR_TO_DAY);          // n = 2pi/T    平均運動
		float meanAnomaly = meanMotion * time + epochMeanAnomaly;   // l = nt + l0  平均近点離角
		float eccentricAnomaly;                                     // 離心近点角
		/* ベッセル関数によるケプラーの方程式の解法を用いて解く(ただしeが小さい時)
		 * e^4の項までの計算する
		 */ 
		eccentricAnomaly = meanAnomaly + (eccentricity - 1 / 8 * Mathf.Pow (eccentricity, 3.0f)) * Mathf.Sin (meanAnomaly)
		+ (1 / 2 * Mathf.Pow (eccentricity, 2.0f) - 1 / 6 * Mathf.Pow (eccentricity, 4.0f)) * Mathf.Sin (2 * meanAnomaly)
		+ (3 / 8 * Mathf.Pow (eccentricity, 3.0f)) * Mathf.Sin (3 * meanAnomaly)
		+ (1 / 3 * Mathf.Pow (eccentricity, 4.0f)) * Mathf.Sin (4 * meanAnomaly);

		return eccentricAnomaly;
	}

	// ケプラーの方程式から求められた解をxy座標に変換
	private void EvalXy (float time) {
		float x, y, u;

		for (int i = 0; i < planets.Length; i++) {
			u =EvalKepler (time, components [i].eccentricity, components [i].orbitalPeriod, components [i].epochMeanAnomaly);
			x = components [i].semiMejorAxisAu * 100 * (Mathf.Cos (u) - components [i].eccentricity);
			y = components [i].semiMejorAxisAu * 100 * (Mathf.Sqrt (1 - Mathf.Pow (components [i].eccentricity, 2.0f))) * Mathf.Sin (u);
			components [i].planetPosition = new Vector3 (x, 0, y);
		}
	}

	// Unityで使える座標系式に
	private void EvalPosition () {
		/* (Xc)                           (x)
		 * (Yc) = Rz(-OMG)*Rx(-i)*Rz(-omg)(y)
		 * (Zc)                           (0)
		 * OMG=Ω omg=ω 日心黄道直交座標をもとめる
		 * 
		 *   (cosOMG -sinOMG 0)(1   0     0 )(cosomg -sinomg 0)(x)
		 * = (sinOMG  cosOMG 0)(0 cosi -sini)(sinomg  cosomg 0)(y)
		 *   (  0       0    1)(0 sini  cosi)(  0       0    1)(0)
		 * 
		 * Unityだとyとzが逆になっていることに注意する
		 */
		float xEq, yEq, zEq;
		float x0, y0, z0;
		float sOmg, lOmg, iEq;

		for (int i = 0; i < planets.Length; i++) {
			x0 = components [i].planetPosition.x;
			y0 = components [i].planetPosition.y;
			z0 = components [i].planetPosition.z;
			lOmg = (components [i].planeEcliptic) * Mathf.PI / 180f;
			sOmg = (components [i].lngPerihelion - components [i].planeEcliptic) * Mathf.PI / 180f;
			iEq = (components [i].inclination) * Mathf.PI / 180f;
			xEq = x0 * (Mathf.Cos (lOmg) * Mathf.Cos (sOmg) - Mathf.Sin (lOmg) * Mathf.Cos (iEq) * Mathf.Sin (sOmg))
			- z0 * (Mathf.Cos (lOmg) * Mathf.Sin (sOmg) + Mathf.Sin (lOmg) * Mathf.Cos (iEq) * Mathf.Cos (sOmg));
			zEq = x0 * (Mathf.Sin (lOmg) * Mathf.Cos (sOmg) + Mathf.Cos (lOmg) * Mathf.Cos (iEq) * Mathf.Sin (sOmg))
			- z0 * (Mathf.Sin (lOmg) * Mathf.Sin (sOmg) - Mathf.Cos (lOmg) * Mathf.Cos (iEq) * Mathf.Cos (sOmg));
			yEq = x0 * Mathf.Sin (iEq) * Mathf.Sin (sOmg) + z0 * Mathf.Sin (iEq) * Mathf.Cos (sOmg);

			components [i].planetPosition = new Vector3 (xEq, yEq, zEq);
		}
	}

	// 返すのはユリウス年
	// 元期が2015年6月27.0日(理科年表より)
	private float DiffTime (int year, int month, int day, int hour, int minute) {
		int diffYear, diffMonth, diffDay, diffHour, diffMinute;
		float diffTime;

		diffYear = year - 2015;
		diffMonth = month - 6;
		diffDay = day - 27;
		diffHour = hour;
		diffMinute = minute;

		diffTime = diffYear * CommonConstants.General.JULIAN_YEAR_TO_DAY + diffMonth / 12 * CommonConstants.General.JULIAN_YEAR_TO_DAY
			+ diffDay + hour / 24;

		return diffTime;
	}
}
