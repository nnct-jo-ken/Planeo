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
	float axis;               // 自転軸
	public int rotationSpeed; // 自転速度

	// Use this for initialization
	void Start () {
		latitude = CommonConstants.LatLng.HOCTO_Lat;
		longitude = CommonConstants.LatLng.HOCTO_Lng;
		axis = CommonConstants.General.EARTH_AXIS;
		rotationSpeed = 15;

		transform.Rotate (0, 0, axis, Space.World);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (0,rotationSpeed * Time.deltaTime, 0, Space.Self);
	}
}