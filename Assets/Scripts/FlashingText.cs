using UnityEngine;
using System.Collections;

public class FlashingText : MonoBehaviour {

	public GameObject flashingText;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("Flashing", 0, 0.5F);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Flashing() {
		flashingText.SetActive (!flashingText.activeSelf);
	}
}
