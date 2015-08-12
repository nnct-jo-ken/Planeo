/*
 * 恒星管理用スクリプト
 * 	- 星の情報を他のクラスに分けてComponentsで管理
 * 	- 各種要素をメソッド化
 */

using UnityEngine;
using System.Collections;

public class StarsManager : MonoBehaviour {

	public GameObject[] stars = new GameObject[9110];
	public StarInfo [] components = new StarInfo[9110];


	// Use this for initialization
	void Start () {
		CreateStarEntity ();
		AddStarInfo ();
		EvalPosition ();

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

	// Evaluate Position using data.csv
	private void EvalPosition() {
		string[,] csvData = ReadCsv("data");
		float raDegree, decDegree, raAngle, decAngle, x, y, z;
		float r = 100;

		for (int i = 0; i < stars.Length; i++) {
			components [i].catalogNumber = int.Parse (csvData [1 + i, 0]);
			components [i].magnitude = float.Parse (csvData [1 + i, 10]);
			raDegree  = float.Parse (csvData [1 + i, 4]);
			decDegree = float.Parse (csvData [1 + i, 9]);

			// Degree to Radian
			raAngle = raDegree * Mathf.PI / 180f;
			decAngle = (90 - decDegree) * Mathf.PI / 180f;

			// Polar to XYZ coordinates
			x = r * Mathf.Sin (decAngle) * Mathf.Cos (raAngle);
			y = r * Mathf.Sin (decAngle) * Mathf.Sin (raAngle);
			z = r * Mathf.Cos (decAngle);

			components [i].starPosition = new Vector3 (x, y, z);
		}
	}
}
