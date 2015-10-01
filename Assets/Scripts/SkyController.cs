using UnityEngine;
using System.Collections;

public class SkyController : MonoBehaviour {

	private float rotationAxis;       // 自転軸
	public int rotationSpeed;         // 自転速度

	// Use this for initialization
	void Start () {
		rotationAxis = CommonConstants.General.EARTH_AXIS;
		rotationSpeed = 1;
	}
	
	// Update is called once per frame
	void Update () {
		Rotation ();
	}

	// 地平座標系の考慮
	public void RotateAxis(float lat, float lng) {
		transform.Rotate (90 - lat, 0, 0);        // 緯度の考慮
		transform.Rotate (0, 15 * (lng / 15), 0); // 経度を考慮
	}

	public void TimeRotate (int year, int month, int day, int hour, int minute){ 
			
	}

	// 自転
	public void Rotation () {
		// 1時間に15度(240秒に1度)
		transform.Rotate (0, -rotationSpeed / 240 * Time.deltaTime, 0, Space.Self);
	}
}