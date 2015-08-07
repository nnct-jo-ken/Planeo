using UnityEngine;
using System.Collections;

public class Dialog : MonoBehaviour {
	public int starClass = 1;
	public int month = 1;
	public int date = 1;
	public int hour = 1;
	public bool displayHorizon = true;
	public string[] observationPoint = {"地球","月","火星"};
	public string[] wayToMoveSky = {"OculusRift","DualShock3"};

	private int openDialog = -1; 
	private int dialogSequence = 0;

	private GUIStyle gs = new GUIStyle();
	private GUIStyleState gss = new GUIStyleState();
	private float dWidth = 600;
	private float dHeight = 500;
	private Color defaultGUIColor;
	//private Color guiColor1 = new Color(35,116,239,50);
	//private Color guiColor1 = Color.gray;

	void Start () {
		gss.background = Texture2D.whiteTexture;
		gs.normal = gss;
	}

	void Update () {
		if(Input.GetKeyDown (KeyCode.Joystick8Button15)) {
			openDialog = -openDialog;
			if (openDialog == 1) {

			}
		}

		if(openDialog==1){

			if(Input.GetKeyDown(KeyCode.Joystick8Button5)||Input.GetKeyDown(KeyCode.Joystick8Button6)){
				if(dialogSequence<7){
					dialogSequence++;
				}else{
					dialogSequence = 0;
				}
			}else if(Input.GetKeyDown(KeyCode.Joystick8Button4)||Input.GetKeyDown(KeyCode.Joystick8Button7)){
				if(dialogSequence>0){
					dialogSequence--;
				}else{
					dialogSequence = 7;
				}
			}

			switch(dialogSequence){
			case 0:

			break;
			case 1:
				
			break;
			case 2:
				
			break;
			case 3:
				
			break;
			case 4:
				
			break;
			case 5:
				
			break;
			case 6:
				
			break;
			case 7:
				
			break;
			}

		}
	}

	void OnGUI(){
		if(openDialog==1){
			gs.fontSize = 50;
			GUI.Box(new Rect((Screen.width-dWidth)/2,(Screen.height-dHeight)/2,dWidth,dHeight),"               設定画面",gs);
			gs.fontSize = 30;
			defaultGUIColor = GUI.backgroundColor;
			GUI.backgroundColor = Color.gray;
			gss.textColor = Color.red;
			gs.normal = gss;
			GUI.Label(new Rect((Screen.width-dWidth)/2+dWidth/12,(Screen.height-dHeight)/2+dHeight/5,dWidth*5/6,dHeight/12),"         等星までを表示",gs);
			GUI.Label(new Rect((Screen.width-dWidth)/2+dWidth/12,(Screen.height-dHeight)/2+dHeight/5+60,dWidth*5/6,dHeight/12),"     月     日     時の空",gs);
			GUI.Label(new Rect((Screen.width-dWidth)/2+dWidth/12,(Screen.height-dHeight)/2+dHeight/5+120,dWidth*5/6,dHeight/12),"地平線の表示",gs);
			GUI.Label(new Rect((Screen.width-dWidth)/2+dWidth/12,(Screen.height-dHeight)/2+dHeight/5+180,dWidth*5/6,dHeight/12),"観測地点",gs);
			GUI.Label(new Rect((Screen.width-dWidth)/2+dWidth/12,(Screen.height-dHeight)/2+dHeight/5+240,dWidth*5/6,dHeight/12),"空の動かし方",gs);
			GUI.Label(new Rect((Screen.width-dWidth)/2+dWidth/12,(Screen.height-dHeight)/2+dHeight/5+300,dWidth*5/6,dHeight/12),"視点の初期化",gs);
			gss.textColor = Color.black;
			gs.normal = gss;
			GUI.backgroundColor = defaultGUIColor;


		}
	}
	

}
