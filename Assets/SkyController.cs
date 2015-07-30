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

}