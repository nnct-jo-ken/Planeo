using UnityEngine;
using System.Collections;

public class SkyController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject star = GameObject.CreatePrimitive (PrimitiveType.Sphere);
		star.transform.position = new Vector3 (0, 1, 0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
