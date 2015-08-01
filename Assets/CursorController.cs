/*
 * Cursor control script
 * 1.show Cursor Texture
 * 2.move center
 * 
 * select enable or disable
 */

using UnityEngine;
using System.Collections;

public class CursorController : MonoBehaviour {

	public Texture2D cursorTexture;
	public CursorMode cursorMode = CursorMode.Auto;
	public Vector2 hotSpot = Vector2.zero;


	// Use this for initialization
	void Start () {
		OnMouseEnter ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseEnter(){
		Cursor.SetCursor (cursorTexture, hotSpot, cursorMode);
	}

	void OnMouseExit(){
		Cursor.SetCursor (null, Vector2.zero, cursorMode);
	}
}
