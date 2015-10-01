﻿using UnityEngine;
using System.Collections;

public class StarInfo : MonoBehaviour {

	// 基本的な情報
	public int catalogNumber;
	public float ra;
	public float dec;
	public Vector3 starPosition;  // xyz座標上の位置
	public float magnitude;
	private Vector3 starColor;

	// 特になければ空
	public string name;         // Infomationに表示する名前
	public string englishName;
	public string description;
	public bool isDescription;  // 1:説明あり 0:説明なし 説明がある場合はコリダーを設定

	// スケーリング用(等級によってサイズ変更)
	public void Scaling() {
		if (magnitude <= 1.0f) {
			transform.localScale = new Vector3 (2.5f, 2.5f, 2.5f);
		} else if (magnitude <= 2.0f) {
			transform.localScale = new Vector3 (2.0f, 2.0f, 2.0f);
		} else if (magnitude <= 4.0f) {
			transform.localScale = new Vector3 (1.5f, 1.5f, 1.5f);
		}
	}

}
