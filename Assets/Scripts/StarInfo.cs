using UnityEngine;
using System.Collections;

public class StarInfo : MonoBehaviour {

	public int catalogNumber;
	public Vector3 starPosition;  // xyz座標上の位置
	public float ra;
	public float dec;

	// 特になければ空
	public string japaneseName;
	public string englishName;  // GameObjectの名前にも使用
	public string explainText;

	public float magnitude;

	private Vector3 starColor;



	// コンストラクタ
	public StarInfo() {
	}
	// 説明用のGUIメソッド
	// スケーリング用(等級によってサイズ変更？？)
	// 




	// Use this for initialization
	//void Start () {}
	// Update is called once per frame
	//void Update () {}
}
