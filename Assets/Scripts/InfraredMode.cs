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
		string[,] csvData = ReadCsv ("akari_pos");
		float ra, dec, x, y, z, theta, phi;
		float X, Y, Z;
		string fileName = "";
		float r = CommonConstants.Infrared.RADIUS;
		for (int i = 0; i < imgObj.Length; i++) {
			ra = float.Parse (csvData [i, 2]);
			dec = float.Parse (csvData [i, 3]);
			phi = ra * Mathf.PI / 180f;
			theta = (90f - dec) * Mathf.PI / 180f;
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
			imgObj [i].name = "ra" + csvData [i, 2] + " dec" + csvData [i, 3];
			imgObj [i].transform.LookAt (parent.transform);
			if (i == (CommonConstants.Infrared.QTY - 2))
				fileName = "AKARI/m_ra090.00_dec-66.56_SEP_6deg";
			else if (i == (CommonConstants.Infrared.QTY - 1))
				fileName = "AKARI/m_ra270.00_dec+66.56_NEP_6deg";
			else
				fileName = "AKARI/m_l" + csvData [i, 0] + "_b" + csvData [i, 1] + "_ecl_6deg";
			imgObj [i].transform.Rotate (0, 0, 90);
			if (imgObj [i].transform.position.z < -350)
				imgObj [i].transform.Rotate (0, 180, 90);
			if (imgObj [i].transform.position.y < -420)
				imgObj [i].transform.Rotate (0, 180, 135);
			if (imgObj [i].transform.position.z > 130)
				imgObj [i].transform.Rotate (0, 180, 90);
			if (imgObj [i].transform.position.z > 130 && imgObj [i].transform.position.z < 320)
				imgObj [i].transform.Rotate (0, 0, 45);
			if (imgObj [i].transform.position.y >360)
				imgObj [i].transform.Rotate (0, 180, 45);
			if (imgObj [i].transform.position.y >360 && imgObj [i].transform.position.y >450)
				imgObj [i].transform.Rotate (0, 0, 90);
			imgObj [i].GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> (fileName);
			imgObj [i].transform.localScale = new Vector3 (16, 16, 16);
		}

		Resources.UnloadUnusedAssets ();
	}
}
