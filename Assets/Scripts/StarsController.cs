using UnityEngine;
using System.Collections;

public class StarsController : MonoBehaviour {

	public GameObject[] stars = new GameObject[CommonConstants.Star.QTY];
	public StarInfo [] components = new StarInfo[CommonConstants.Star.QTY];
	private SkyController sky;

	public Material redMaterial;
	public Material orangeMaterial;
	public Material blueMaterial;
	public Material basicMaterial;

	// Use this for initialization
	void Start () {
		CreateStarEntity ();
		AddStarInfo ();
		AddStarTag ();
		//EvalPositionFromCsvData ();
		EvalPositionFromCsvStar ();

		SetPosition ();
		SetObjectSize ();
		SetMaterial ();
		//sky = GetComponent<SkyController> ();
		//sky.RotateAxis (CommonConstants.LatLng.HOCTO_Lat, CommonConstants.LatLng.HOCTO_Lng);


	}
	
	// Update is called once per frame
	void Update () {
	}


	// Create Object Entity
	public void CreateStarEntity() {
		GameObject starsParentObject = GameObject.Find("Sky/Star");

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

	// Set Object Size
	private void SetObjectSize() {
		for (int i = 0; i < stars.Length; i++) {
			components [i].Scaling ();
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
		float r = CommonConstants.Star.RADIUS;

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

	// Evaluate Position from star.csv
	private void EvalPositionFromCsvStar() {
		string[,] csvData = ReadCsv("star");
		float raDegree, decDegree, raAngle, decAngle, x, y, z;
		float r = 300;
		
		for (int i = 0; i < stars.Length; i++) {
			components [i].catalogNumber = int.Parse (csvData [3 + i, 0].Substring(4));
			
			components [i].magnitude = float.Parse(csvData [3 + i, 4]);

			// RA/DEC to Degree
			raDegree  = float.Parse (csvData [3 + i, 5]);
			decDegree = float.Parse (csvData [3 + i, 6]);
			
			// Degree to Radian
			raAngle = raDegree * Mathf.PI / 180f;
			decAngle = (90 - decDegree) * Mathf.PI / 180f;
			
			// Polar to XYZ coordinates
			x = r * Mathf.Sin (decAngle) * Mathf.Cos (raAngle);
			y = r * Mathf.Sin (decAngle) * Mathf.Sin (raAngle);
			z = r * Mathf.Cos (decAngle);
			
			components[i].englishName = csvData [3 + i, 0];

			if(int.Parse (csvData [3 + i, 10]) == 1){
				components[i].isDescription = true;
				components[i].name = csvData [3 + i, 12];
				components[i].description = csvData [3 + i, 11];
				stars [i].GetComponent<SphereCollider> ().radius = 5.0f;
			}else{
				components[i].isDescription = false;
				stars [i].GetComponent<SphereCollider> ().enabled = false;
			}
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

	public void SetMaterial() {
		for (int i = 0; i < stars.Length; i++) {
			stars [i].GetComponent<MeshRenderer> ().material = basicMaterial;
		}
	}

}
