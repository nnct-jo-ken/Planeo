using UnityEngine;
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

	// Use this for initialization
	void Start () {
		CreatePlanetEntity ();
		AddPlanetInfo ();
		AddPlanetTag ();

	}
	
	// Update is called once per frame
	void Update () {
	
	}


	// Create Objetct Entity
	void CreatePlanetEntity () {
		GameObject parentObject = GameObject.Find("Sky/Planet");
		for (int i = 0; i < planets.Length; i++) {
			planets [i] = GameObject.CreatePrimitive (PrimitiveType.Sphere);
			planets [i].transform.parent = parentObject.transform;
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

	private float EvalKepler (float time, float eccentricity, float revolutionCycle, float epochMeanAnomaly) {
		// Kepler's equation を Newton法 で解く
		// l = u - e*sin(u)
		float meanMotion = 2 * Mathf.PI / revolutionCycle;          // n = 2pi/T    平均運動
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
}
