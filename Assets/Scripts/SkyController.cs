/* 天の制御スクリプト
 * - 自転運動
 * - 地平座標系の考慮
 * - 地軸制御
 */

using UnityEngine;
using System.Collections;

public class SkyController : MonoBehaviour {

	float latitude;           // 緯度
	float longitude;          // 経度
	float rotationAxis;       // 自転軸
	public int rotationSpeed; // 自転速度

	// Use this for initialization
	void Start () {
		latitude = CommonConstants.LatLng.HOCTO_Lat;
		longitude = CommonConstants.LatLng.HOCTO_Lng;
		rotationAxis = CommonConstants.General.EARTH_AXIS;
		rotationSpeed = 1;
	}
	
	// Update is called once per frame
	void Update () {
		Rotation ();
	}

	// 地平座標系の考慮
	public void RotateAxis(float lat, float lng) {
		transform.Rotate (90 - lat, 0, 0);
	}

	public void Rotation () {
		// 240秒に1度
		transform.Rotate (0, -rotationSpeed / 240 * Time.deltaTime, 0, Space.Self);
	}
}