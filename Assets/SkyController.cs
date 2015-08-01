using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class SkyController : MonoBehaviour {

	private GameObject starParentObject;
	private Star[] stars = new Star[9110];


	/* テスト用
	 * あとでテーブルに描き直そう
	 * 計算するのがもったいないので
	 */
	private string[,] csvData;
	private float[] RA = new float[9110];
	private float[] DEC = new float[9110];
	private float x, y, z;
	private int limitedNumber = 100;

	public float r = 1;


	// Use this for initialization
	void Start () {

		InitStars (ref stars);
		starParentObject = GameObject.Find ("Sky");

		csvData = ReadCsv ("data");
		for (int i = 0; i < limitedNumber; i++) {
			stars [i].catalogNumber = int.Parse (csvData [i + 1, 0]);
			RA [i] = float.Parse (csvData [i + 1, 4]);
			DEC [i] = float.Parse (csvData [i + 1, 9]);

			x = r * UnityEngine.Mathf.Sin (90 - DEC [i])
							* UnityEngine.Mathf.Cos (RA [i]);
			y = r * UnityEngine.Mathf.Sin (90 - DEC [i])
							* UnityEngine.Mathf.Sin (RA [i]);
			z = r * UnityEngine.Mathf.Sin (90 - DEC [i]);
			stars[i].starPosition = new Vector3(x, y, z);
		}
		/*
		 * 1.GameObject(Sphere)を生成
		 * 2.GameObjectを移動(transform)
		 * 3.親オブジェクトをSkyにする
		 */

		for (int i = 0; i < limitedNumber; i++) {
			stars [i].StarCreateAndPlot (ref starParentObject);
		}
	}
	// Update is called once per frame
	void Update () {
	
	}


	void InitStars(ref Star[] stars) {
		for (int i = 0; i < stars.Length; i++) {
			stars [i] = Star();	// 明示的にインスタンスの生成
		}
	}

	// 輝度によるフィルター(非表示)
	void FilterMagnitude(ref Star[] stars, float filterMagnitude) {
		for (int i = 0; i < stars.Length; i++) {
			if (stars [i].magnitude > filterMagnitude) {
				stars [i].starDisplayEnable = false;
			}
		}
	}

	//
	private string[,] ReadCsv(string fileName) {
		TextAsset ta = Resources.Load (fileName, typeof(TextAsset)) as TextAsset;
		string[] lineArray = ta.text.Replace("\r\n", "\n").Split('\n');
		ArrayList dataList = new ArrayList (lineArray);

		int lineCount = dataList.Count;
		string tmp = dataList[0].ToString();
		string[] tmp2 = tmp.Split(","[0]);
		int colCount = tmp2.Length;
		string[,] tmpCsvData = new string[lineCount	, colCount];
		int i = 0;

		foreach(string str1 in dataList){
			int j = 0;
			string[] tmpLine = str1.Split(',');
			foreach(string str2 in tmpLine){
				tmpCsvData[i,j] = str2;
				j++;
			}
			i++;
		}
		return tmpCsvData;
	}

}


// 恒星の管理
public class Star : MonoBehaviour {

	public Vector3 starPosition;
	public string starName;		// 特に有名でなければ空
	public string explainText;	// 特になければ空
	public float  magnitude;	// [issue] float or double
	public bool starDisplayEnable;	// 1:表示 0:非表示

	public int catalogNumber;
	private GameObject starEntity;
	private Vector3 starColor;


	// コンストラクタ
	public Star() {
		starDisplayEnable = true;
	}


	// 絶対にPositionが決まってから呼ぶこと
	public void StarCreateAndPlot(ref GameObject starsParent){
		starEntity = GameObject.CreatePrimitive (PrimitiveType.Sphere);
		starEntity.transform.position = starPosition;
		starEntity.transform.parent = starsParent.transform;
	}
}

// 惑星の管理
public class Planet : MonoBehaviour {
	public Vector3 position;

	public string planetName;
	public string explainText;
	public bool planetDisplayEnable;
}