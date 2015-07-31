using UnityEngine;
using System.Collections;

public class SkyController : MonoBehaviour {

	private GameObject sky;



	// Use this for initialization
	void Start () {
		sky = GameObject.Find ("Sky");
		GameObject star = GameObject.CreatePrimitive (PrimitiveType.Sphere);
		star.transform.position = new Vector3 (25, 20, 20);
		star.transform.parent = sky.transform;
	}



	// Update is called once per frame
	void Update () {
	
	}
}

public class Star : MonoBehaviour {

	public Vector3 starPosition;
	public string starName;		// 特に有名でなければ空
	public string explainText;	// 特になければ空
	public double  magnitude;	// [issue] float or double
	public bool starDisplayEnable;	// 1:表示 0:非表示


	private int catalogNumber;
	private GameObject starEntity;
	private Vector3 starColor;

}