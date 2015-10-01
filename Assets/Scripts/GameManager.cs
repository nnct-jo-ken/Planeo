using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	private static bool isMode = true;     // 1:地球 0:宇宙
	private static bool isVisual = true;   // 1:可視光,0:不可視光

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		ChangeVisual ();
	}

	void ChangeVisual() {
		if (isMode == true) {
			if (Input.GetButtonUp ("Visual")) {
				isVisual = !isVisual;
			}
		}
	}
}
