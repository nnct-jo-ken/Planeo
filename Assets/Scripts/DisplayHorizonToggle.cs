using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DisplayHorizonToggle : MonoBehaviour {

	public GameObject objectWithDialog;
	private Dialog dialog;

	private Toggle toggle;

	public void Start(){
		toggle = GetComponent<Toggle> ();
	}

	public void ChangeToggle(){
		dialog = objectWithDialog.GetComponent<Dialog> ();
		dialog.displayHorizon = toggle.isOn;
	}
}
