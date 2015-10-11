using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public bool isMode = true;     // 1:地球 0:宇宙
	public bool isVisual = true;   // 1:可視光,0:不可視光
	public GameObject visualSkyStar;
	public GameObject visualSkyPlanet;
	public GameObject infraredSky;
	public GameObject sky;
	// Use this for initialization
	void Start () {
		infraredSky.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		ChangeVisual ();
	}

	void ChangeVisual() {
		if (isMode == true) {
			if (Input.GetButtonUp ("Visual")) {
				isVisual = !isVisual;
				if (isVisual == true) {
					visualSkyStar.SetActive (true);
					visualSkyPlanet.SetActive (true);
					infraredSky.SetActive (false);
				} else if (isVisual == false) {
					infraredSky.transform.eulerAngles = sky.transform.eulerAngles;
					visualSkyStar.SetActive (false);
					visualSkyPlanet.SetActive (false);
					infraredSky.SetActive (true);
				}

			}
		}
	}
}
