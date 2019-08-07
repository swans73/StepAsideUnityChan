//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//
//public class ItemGenerator : MonoBehaviour {
//	public GameObject carPrefab;
//	public GameObject coinPrefab;
//	public GameObject conePrefab;
//	private int startPos = -160;
//	private int goalPos = 120;
//	private float posRange = 3.4f;
//
//	private float distance;
//	private GameObject unitychan;
//
//	// Use this for initialization
//	void Start () {
//		
//		this.unitychan = GameObject.Find ("unitychan");
//		this.distance = unitychan.transform.position.z + this.transform.position.z;
//
//		
//	}
//	
//	// Update is called once per frame
//	void Update () {
//	// unityちゃんが進んだらアイテムを生成する
//		// 前にunitychanがいた位置
//		this.transform.position = new Vector3(0, this.transform.position.y, this.unitychan.transform.position.z + this.transform.position.z);
//		if(this.unitychan.transform.position.z < this.transform.position.z){
//			for (int i = startPos; i < goalPos; i += 15) {
//				int num = Random.Range (1, 11);
//				if (num <= 2) {
//					for (float j = -1; j <= 1; j += 0.4f) {
//						GameObject cone = Instantiate (conePrefab) as GameObject;
//						cone.transform.position = new Vector3 (4 * j, cone.transform.position.y, i);
//					}
//				} else {
//					for (int j = -1; j <= 1; j++) {
//						int item = Random.Range (1, 11);
//						int offsetZ = Random.Range (-5, 6);
//						if (1 <= item && item <= 6) {
//							GameObject coin = Instantiate (coinPrefab) as GameObject;
//							coin.transform.position = new Vector3 (posRange * j, coin.transform.position.y, i + offsetZ);
//						} else if (7 <= item && item <= 9) {
//							GameObject car = Instantiate (carPrefab) as GameObject;
//							car.transform.position = new Vector3 (posRange * j, car.transform.position.y, i + offsetZ);
//						}
//					}
//				}
//			}
//		}
//
//			
//	}
//}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ItemGenerator : MonoBehaviour
{
	//carPrefabを入れる
	public GameObject carPrefab;
	//coinPrefabを入れる
	public GameObject coinPrefab;
	//cornPrefabを入れる
	public GameObject conePrefab;
	//スタート地点
	private int startPos = -160;
	//ゴール地点
	private int goalPos = 120;
	//アイテムを出すx方向の範囲
	private float posRange = 3.4f;
	//Unityちゃんのオブジェクト
	private GameObject unitychan;
	private float offset = 0;
	private float distance = 0;
	private float unityPos;
	private float RangePos;
	// Use this for initialization
	void Start()
	{
		//Unityちゃんのオブジェクトを取得
		this.unitychan = GameObject.Find("unitychan");
		offset = unitychan.transform.position.z;
	}
	// Update is called once per frame
	void Update()
	{
		// 15m毎にアイテム生成
		if (distance < 40)
		{
			distance = unitychan.transform.position.z - offset;
			return;
			//ここで終了
		}
		offset = unitychan.transform.position.z;
		distance = 0;
		unityPos = unitychan.transform.position.z + 40;
		RangePos = unitychan.transform.position.z + 80;
		Debug.Log("Unityちゃんが40M進んだ。");
		for (float i = unityPos; i < RangePos; i += 15) {
		int num = Random.Range (1, 11);
		if (num <= 2) {
			for (float j = -1; j <= 1; j += 0.4f) {
				GameObject cone = Instantiate (conePrefab) as GameObject;
				cone.transform.position = new Vector3 (4 * j, cone.transform.position.y, i);
			}
		} else {
			for (int j = -1; j <= 1; j++) {
				int item = Random.Range (1, 11);
				int offsetZ = Random.Range (-5, 6);
					if (1 <= item && item <= 6) {
						GameObject coin = Instantiate (coinPrefab) as GameObject;
						coin.transform.position = new Vector3 (posRange * j, coin.transform.position.y, i + offsetZ);
					} else if (7 <= item && item <= 9) {
						GameObject car = Instantiate (carPrefab) as GameObject;
						car.transform.position = new Vector3 (posRange * j, car.transform.position.y, i + offsetZ);
					}
				}
			}
		}
		if (distance > 20) {
			distance = offset - unitychan.transform.position.z;
			Destroy (this.gameObject);
		}
	}
}
