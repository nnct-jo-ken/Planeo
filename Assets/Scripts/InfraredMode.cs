using UnityEngine;
using System.Collections;

public class InfraredMode : MonoBehaviour {

	public GameObject [] imgObj = new GameObject[CommonConstants.Infrared.QTY];
	public GameObject parent;

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
		float X, Y, Z;
		string fileName = "";
		float r = CommonConstants.Infrared.RADIUS;
		for (int i = 0; i < imgObj.Length; i++) {
			l = float.Parse (csvData [i, 0]);
			b = float.Parse (csvData [i, 1]);
			phi = l * Mathf.PI / 180f;
			theta = (90f - b) * Mathf.PI / 180f;
			x = r * Mathf.Sin (theta) * Mathf.Cos (phi);
			y = r * Mathf.Sin (theta) * Mathf.Sin (phi);
			z = r * Mathf.Cos (theta);

//			X = x;
//			Y = y * Mathf.Cos (CommonConstants.General.ECLIPTIC_INCLINATION_DEG * Mathf.Deg2Rad)
//				- z * Mathf.Sin (CommonConstants.General.ECLIPTIC_INCLINATION_DEG * Mathf.Deg2Rad);
//			Z = y * Mathf.Sin (CommonConstants.General.ECLIPTIC_INCLINATION_DEG * Mathf.Deg2Rad)
//			+ y * Mathf.Cos (CommonConstants.General.ECLIPTIC_INCLINATION_DEG * Mathf.Deg2Rad);

			// imgObj [i].transform.localPosition = new Vector3 (X, Z, Y);
			imgObj [i].transform.localPosition = new Vector3 (x, z, y);

			imgObj [i].transform.LookAt (parent.transform);
			imgObj [i].transform.Rotate (0, 0, 90);
			if (b < 0)
				fileName = "AKARI/m_l" + csvData [i, 0] + "_b" + csvData [i, 1] + "_ecl_6deg";
			else if (b >= 0)
				fileName = "AKARI/m_l" + csvData [i, 0] + "_b+" + csvData [i, 1] + "_ecl_6deg";

			imgObj [i].GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> (fileName);
			imgObj [i].transform.localScale = new Vector3 (16, 16, 16);
		}
		Resources.UnloadUnusedAssets ();
	}
}
