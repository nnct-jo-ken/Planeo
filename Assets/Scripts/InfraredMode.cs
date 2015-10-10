using UnityEngine;
using System.Collections;

public class InfraredMode : MonoBehaviour {

	public Sprite [] images = new Sprite[CommonConstants.Infrared.QTY];
	public GameObject [] imgObj = new GameObject[CommonConstants.Infrared.QTY];
	public GameObject parent;
	public Sprite img;

	// Use this for initialization
	void Start () {
		CreateObject ();
		ReadData ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	private void CreateObject() {
		for (int i = 0; i < imgObj.Length; i++) {
			imgObj [i] = new GameObject ("Sprite");
			imgObj [i].AddComponent<SpriteRenderer> ();
			imgObj [i].transform.parent = parent.transform;
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

	private void ReadData() {
		string[,] csvData = ReadCsv ("pos_data");
		float l, b, x, y, z, theta, phi;
		string fileName = "";
		float r = CommonConstants.Infrared.RADIUS;
		for (int i = 0; i < imgObj.Length; i++) {
			l = float.Parse (csvData [i, 0]);
			b = float.Parse (csvData [i, 1]);
			theta = l * Mathf.PI / 180f;
			phi = (90f - b) * Mathf.PI / 180f;
			x = r * Mathf.Sin (phi) * Mathf.Cos (theta);
			y = r * Mathf.Sin (phi) * Mathf.Sin (theta);
			z = r * Mathf.Cos (phi);

			imgObj [i].transform.localPosition = new Vector3 (x, z, y);
			imgObj [i].transform.LookAt (parent.transform);
			if (b < 0)
				fileName = "AKARI/s_l" + csvData [i, 0] + "_b" + csvData [i, 1] + "_ecl_6deg";
			else if (b >= 0)
				fileName = "AKARI/s_l" + csvData [i, 0] + "_b+" + csvData [i, 1] + "_ecl_6deg";

			imgObj [i].GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> (fileName);
			imgObj [i].transform.localScale = new Vector3 (10, 10, 10);
		}
		Resources.UnloadUnusedAssets ();
	}
}
