using UnityEngine;
using System.Collections;

public class PlanetInfo : MonoBehaviour {

	// 基本的な情報
	public float ra;
	public float dec;
	public Vector3 planetPosition;	// xyz座標上の位置

	public string name;
	public string englishName;
	public string description;

	// 軌道要素
	public float semiMejorAxisAu;           // 軌道長半径 (Au)
	public float eccentricity;              // 離心率
	public float inclination;               // 軌道傾斜
	public float lngPerihelion;             // 近日点黄経
	public float planeEcliptic;             // 昇交点黄経
	public float epochMeanAnomaly;          // 元期平均近点離角
	public float orbitalPeriod;             // 公転周期(ユリウス年)
	public float eccentricAnomaly;          // 離心近点角

	public Texture texture;
}
