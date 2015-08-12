using UnityEngine;
using System.Collections;

public class PlanetInfo : MonoBehaviour {

	public int planetNumber;

	public Vector3 planetPosition;	// xyz座標上の位置
	public float ra;
	public float dec;
	public float distance;

	public string japaneseName;
	public string englishName;		// GameObjectの名前にも使用
	public string explainText;

	// 試験的
	public Texture texture;
	public int satelliteQty;
	public StarInfo satelliteInfo;


	// コンストラクタ
	public PlanetInfo() {
	}

	// 説明用GUIメソッド
	// スケーリング用メッソド


	// Use this for initialization
	//void Start () {}
	// Update is called once per frame
	//void Update () {}
}
