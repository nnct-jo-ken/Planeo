/*
 * 恒星管理用スクリプト
 * 	- 星の情報を他のクラスに分けてComponentsで管理
 * 	- 各種要素をメソッド化
 */

using UnityEngine;
using System.Collections;

public class StarsController : MonoBehaviour {

	public GameObject[] stars = new GameObject[9110];
	public StarInfo [] components = new StarInfo[9110];


	// Use this for initialization
	void Start () {
		CreateStarEntity ();
		AddStarInfo ();
		//AddStarTag ();
		EvalPositionFromCsvData ();
		SetPosition ();

		Debug.Log (components [423].catalogNumber);
		Debug.Log (components [423].magnitude);
		stars [423].transform.localScale = new Vector3 (10,10,10);

		MagnitudeFilter (3.4f);
		GetComponent<SkyController> ().RotateAxis (CommonConstants.LatLng.HOCTO_Lat, CommonConstants.LatLng.HOCTO_Lng); // test
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	// Create Object Entity
	public void CreateStarEntity() {
		GameObject starsParentObject = GameObject.Find("Sky");

		for (int i = 0; i < stars.Length; i++) {
			stars [i] = GameObject.CreatePrimitive (PrimitiveType.Sphere);
			stars [i].transform.parent = starsParentObject.transform;
		}
	}

	// Add Star Infomation to each object
	public void AddStarInfo() {
		for (int i = 0; i < stars.Length; i++) {
			components [i] = stars[i].AddComponent <StarInfo>();
		}
	}

	// Add Tag "Star"
	private void AddStarTag() {
		for (int i = 0; i < stars.Length; i++) {
			stars [i].tag = "Star";
		}
	}

	// Set Position Object
	private void SetPosition() {
		for (int i = 0; i < stars.Length; i++) {
			stars [i].transform.position = components [i].starPosition;
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

	// Evaluate Position from data.csv
	private void EvalPositionFromCsvData() {
		string[,] csvData = ReadCsv("data");
		float raDegree, decDegree, raAngle, decAngle, x, y, z;
		float r = 500;

		for (int i = 0; i < stars.Length; i++) {
			components [i].catalogNumber = int.Parse (csvData [1 + i, 0]);
			components [i].magnitude = float.Parse (csvData [1 + i, 10]);

			// RA/DEC to Degree
			raDegree  = float.Parse (csvData [1 + i, 4]) * 15;
			decDegree = float.Parse (csvData [1 + i, 9]);

			// Degree to Radian
			raAngle = raDegree * Mathf.PI / 180f;
			decAngle = (90 - decDegree) * Mathf.PI / 180f;

			// Polar to XYZ coordinates
			x = r * Mathf.Sin (decAngle) * Mathf.Cos (raAngle);
			y = r * Mathf.Sin (decAngle) * Mathf.Sin (raAngle);
			z = r * Mathf.Cos (decAngle);

			components [i].starPosition = new Vector3 (x, z, y); // Unityだと縦方向がY軸、奥行きがY軸なので
		}
	}

	// 等級フィルター
	public void MagnitudeFilter(float filteredMagnitude) {
		for (int i = 0; i < stars.Length; i++) {
			if (components [i].magnitude > filteredMagnitude) {
				stars [i].SetActive (false);
			} else {
				if (stars [i].activeSelf == false) {
					stars [i].SetActive (true);
				}
			}
		}
	}


}
