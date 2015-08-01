using UnityEngine;
using System.Collections;

public class SkyController : MonoBehaviour {

	private GameObject starParentObject;
	private Star[] stars = new Star[10];

	// Use this for initialization
	void Start () {

		InitStars (ref stars);
		starParentObject = GameObject.Find ("Sky");
		/*
		 * 1.GameObject(Sphere)を生成
		 * 2.GameObjectを移動(transform)
		 * 3.親オブジェクトをSkyにする
		 */
		stars [1].starPosition = new Vector3(25.41f,35,20);
		stars [1].StarCreateAndPlot (ref starParentObject);
		stars [2].starPosition = new Vector3(30,35,10);
		stars [2].StarCreateAndPlot (ref starParentObject);
		stars [3].starPosition = new Vector3(45,25,25);
		stars [3].StarCreateAndPlot (ref starParentObject);
	}
	// Update is called once per frame
	void Update () {
	
	}


	void InitStars(ref Star[] stars) {
		for (int i = 0; i < stars.Length; i++) {
			stars [i] = new Star();	// 明示的にインスタンスの生成
		}
	}

	// 輝度によるフィルター(非表示)
	void FilterMagnitude(ref Star[] stars, double filterMagnitude) {
		for (int i = 0; i < stars.Length; i++) {
			if (stars [i].magnitude > filterMagnitude) {
				stars [i].starDisplayEnable = false;
			}
		}
	}

}


// 恒星の管理
public class Star : MonoBehaviour {

	public Vector3 starPosition;
	public string starName;		// 特に有名でなければ空
	public string explainText;	// 特になければ空
	public double  magnitude;	// [issue] float or double
	public bool starDisplayEnable;	// 1:表示 0:非表示

	private int catalogNumber;
	private GameObject starEntity;
	private Vector3 starColor;


	// コンストラクタ
	public Star() {
		starDisplayEnable = true;
	}


	// 絶対にPositionが決まってから呼ぶこと
	public void StarCreateAndPlot(ref GameObject starsParent){
		starEntity = GameObject.CreatePrimitive (PrimitiveType.Sphere);
		starEntity.transform.position = starPosition;
		starEntity.transform.parent = starsParent.transform;
	}
}

// 惑星の管理
public class Planet : MonoBehaviour {
	public Vector3 position;

	public string planetName;
	public string explainText;
	public bool planetDisplayEnable;
}