/*
 * Cursor control script
 *    select enable or disable
 */

using UnityEngine;
using System.Collections;

public class CursorController : MonoBehaviour {

	private GameObject cursor;

	// Use this for initialization
	void Start () {
		cursor = transform.FindChild("Image").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("ShowCursor")) {
			if (cursor.activeSelf == false) {
				cursor.SetActive (true);
			} else if (cursor.activeSelf == true) {
				cursor.SetActive (false);
			}
		}
	}
}
