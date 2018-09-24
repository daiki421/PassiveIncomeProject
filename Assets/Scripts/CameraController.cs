using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

//	float posY = 0f;
//	BlockController bcScript;
//	float beforePlayerPosY = 0;
//	float afterPlayerPosY = 0;
	public GameObject player;
	private Vector3 offset;

	// Use this for initialization
	void Start () {
//		bcScript = Camera.main.gameObject.GetComponent<BlockController> ();
//		beforePlayerPosY = GameObject.Find ("Player").transform.position.y;
//		print (beforePlayerPosY);
		offset.y = this.transform.position.y - player.transform.position.y;
	}

	void LateUpdate () 
	{
		if (this.transform.position.y >= GameObject.Find ("Floors").transform.position.y + 2.35f) {
//			print ("入っている");
			//カメラの transform 位置をプレイヤーのものと等しく設定します。ただし、計算されたオフセット距離によるずれも加えます。
			this.transform.position = new Vector3 (0, player.transform.position.y + offset.y, -5.0f);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
