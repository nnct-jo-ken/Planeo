/* 
 * 惑星管理用スクリプト
 */

using UnityEngine;
using System.Collections;

public class PlanetController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}


// 各惑星の管理
public class Planet : MonoBehaviour {
	public Vector3 position;

	public string planetName;
	public string explainText;
}