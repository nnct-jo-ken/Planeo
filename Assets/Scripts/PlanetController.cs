/* 惑星管理用スクリプト
 * 
 */
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
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	// Create Objetct Entity
	void CreatePlanetEntity () {
		GameObject parentObject = GameObject.Find("Sky");
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


}
