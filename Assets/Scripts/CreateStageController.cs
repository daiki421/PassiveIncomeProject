using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateStageController : MonoBehaviour {

	public GameObject floors; 
	BlockController bcScript;
	GameObject mainCam;
	int line = 0;
	float wallPosX = 0;
	float wallPosY = 0;
	float colliderPosX = 0;
	float colliderPosY = 0;
	private float scale = 0.38f; // Colliderスケール

	// Use this for initialization
	void Start () {
		mainCam = Camera.main.gameObject;
		bcScript = mainCam.GetComponent<BlockController> ();
		line = bcScript.getLine ();
		createPositionY ();
		createWall ();
		setCollider ();
	}

	// Update is called once per frame
	void Update () {

	}


	// 地面を最下層ブロックの下につける(最下層ブロック-0.15f)
	public void createPositionY() {
		floors.transform.position = new Vector2(0, 0.4f - line * 0.4f - 0.15f);
	}


	// サイドの柱をprefabで生成
	public void createWall() {
		for (int i = 0; i < 2; i++) {
			for (int j = 0; j < bcScript.getLine()*3; j++) {
				GameObject wallPrefab = GameObject.Find("Wall");
				if (i == 0) {
					wallPosX = 1.55f;
				} else {
					wallPosX = -1.55f;
				}
				wallPosY = 2.85f - j * 0.25f;
				Vector2 wallPosition = new Vector2(wallPosX, wallPosY);
				GameObject wall = Instantiate(wallPrefab, wallPosition, Quaternion.AngleAxis(Random.Range(0, 0), Vector3.up)) as GameObject;
			}
		}
	}

	public void setCollider() {
		for (int i = 0; i < bcScript.getRow(); i++) {
			for (int j = -1; j < bcScript.getLine(); j++) {
				// プレファブ取得
				GameObject colliderPrefab = GameObject.Find("CubeCollider");
				// オブジェクトのポジション設定
				colliderPosX = -1.2f + i * 0.4f;
				colliderPosY = 0.4f - j * 0.4f;
				Vector3 colliderPosition = new Vector3(colliderPosX, colliderPosY, 0.3f);
				// プレファブからインスタンス生成
				// x座標桁落ちのため分岐処理挟む
				if (i == 3) {
					GameObject collider = Instantiate(colliderPrefab, colliderPosition, Quaternion.AngleAxis(Random.Range(0, 0), Vector3.up)) as GameObject;
					// オブジェクトのスケール設定
					collider.transform.localScale = Vector3.one * scale;
				} else {
					GameObject block = Instantiate(colliderPrefab, colliderPosition, Quaternion.AngleAxis(Random.Range(0, 0), Vector3.up)) as GameObject;
					// オブジェクトのスケール設定
					block.transform.localScale = Vector3.one * scale;
				}
			}
		}
	}
}
