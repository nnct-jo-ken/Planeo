using UnityEngine;
using System.Collections;

public class ResetButton : MonoBehaviour {

	public GameObject objectWithDialog;
	private Dialog dialog;
	
	public void OnClick(){
		dialog = objectWithDialog.GetComponent<Dialog> ();
		dialog.pushReset = true;
	}
}
