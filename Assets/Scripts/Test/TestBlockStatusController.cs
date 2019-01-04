using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TestBlockStatusController : MonoBehaviour {

	private GameObject firstBlock;
	private GameObject lastBlock;
	private string currentName;
	List<GameObject> removableBallList = new List<GameObject>();
	List<GameObject> moveBlockList = new List<GameObject>();
	List<float> moveBlockPosYList = new List<float>();
	GameObject mainCam;
	TestBlockController bcScript;
	// 落下予定のオブジェクトを入れる配列
	public GameObject[,] moveObjects;
	int[] countDel;
	TestGameManagerController gameManagerController;
	TestPlayerController pScript;
	GameObject player;
	GameObject light;
	Material originalMaterial1;
	Material originalMaterial2;
	Material originalMaterial3;
	Material originalMaterial4;
	private Renderer renderer;
	private int PLAYER_POSITION_Y_MAX = 1150;
	private int BLOCK_POSITION_Y_MAX = 1100;
	int dropBlockNum = 0;

	// Use this for initialization
	void Start () {
		mainCam = Camera.main.gameObject;
		bcScript = mainCam.GetComponent<TestBlockController> ();
		moveObjects = new GameObject[bcScript.getRow(),bcScript.getLine()+2];
		countDel = new int[bcScript.getRow()];
		gameManagerController = GameObject.Find("GameManager").GetComponent<TestGameManagerController> ();
		pScript = GameObject.Find ("Player").GetComponent<TestPlayerController> ();
		light = GameObject.Find ("BlockLight");
		player = GameObject.Find ("Player");
		renderer = GetComponent<Renderer>();
		originalMaterial1 = new Material(renderer.material);
//		GameObject.Find("RayCutMain").GetComponent<BoxCollider> ().enabled = false;
	}

	void Update () {
		
	}

	// マウスボタンが押された時にコールされる
	void OnMouseDown() {
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit = new RaycastHit ();
		if (Physics.Raycast (ray, out hit)) {
			if (hit.collider != null) {
				// ヒットしたオブジェクト取得
				GameObject hitObj = hit.collider.gameObject;
				// オブジェクトの名前取得
				string ballName = hitObj.name;
				print ("ballName="+ballName);
				if (ballName.StartsWith ("Block")) {
					float distance = Vector2.Distance (pScript.getPosition (), hitObj.transform.position);
					if (distance < 142) {
						firstBlock = hitObj;
						lastBlock = hitObj;
						prominentColor (hitObj);
						currentName = hitObj.name;
						// 消すブロックをリストに格納
						pushToList (hitObj);
						// ヒットしたブロックの座標を取得
						int matrixX = bcScript.getMatrixX ((int)hitObj.transform.position.x);
						int matrixY = bcScript.getMatrixY ((int)hitObj.transform.position.y);
//					print (matrixX + "," + matrixY);
						// ヒットしたブロックの存在判定をfalse
						bcScript.setIsExistBlock (matrixX, matrixY, false);
					}
				} 
			}
		}
	}
//
//	// ドラッグしている間コールされ続ける
	void OnMouseDrag() {
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit = new RaycastHit ();
		if (Physics.Raycast (ray, out hit)) {
			if (hit.collider != null) {
				GameObject hitObj = hit.collider.gameObject;
				if (hitObj.name == currentName && lastBlock != hitObj) {
					float distance = Vector2.Distance (hitObj.transform.position, lastBlock.transform.position);
//					print (distance);
					if (distance < 142) {
						lastBlock = hitObj;
						// 消すブロックをリストに格納
						pushToList (hitObj);
						// 連結のライン用事
						gameManagerController.lineDrawing (removableBallList[removableBallList.Count - 2], lastBlock);
						// ドラッグしたブロックの座標を算出
						int matrixX = bcScript.getMatrixX ((int)hitObj.transform.position.x);
						int matrixY = bcScript.getMatrixY ((int)hitObj.transform.position.y);
						// ブロックの存在有無を格納
						bcScript.setIsExistBlock (matrixX, matrixY, false);
					}
				} 
			}
		}
	}
//
//	// マウスボタンを離した時にコールされる
	void OnMouseUp() {
		light.SetActive (true);
		// オブジェクト発光消す
		GameObject[] blueBlocks = GameObject.FindGameObjectsWithTag("CubeBlue");
		foreach (GameObject block in blueBlocks) {
			Renderer r = block.GetComponent<Renderer> (); 
			r.material.EnableKeyword("_EMISSION");
			r.material.SetColor("_EmissionColor", new Color(0,0,0));
		}
		GameObject[] greenBlocks = GameObject.FindGameObjectsWithTag("CubeGreen");
		foreach (GameObject block in greenBlocks) {
			Renderer r = block.GetComponent<Renderer> (); 
			r.material.EnableKeyword("_EMISSION");
			r.material.SetColor("_EmissionColor", new Color(0,0,0));
		}
		GameObject[] redBlocks = GameObject.FindGameObjectsWithTag("CubeRed");
		foreach (GameObject block in redBlocks) {
			Renderer r = block.GetComponent<Renderer> (); 
			r.material.EnableKeyword("_EMISSION");
			r.material.SetColor("_EmissionColor", new Color(0,0,0));
		}
		GameObject[] yellowBlocks = GameObject.FindGameObjectsWithTag("CubeYellow");
		foreach (GameObject block in yellowBlocks) {
			Renderer r = block.GetComponent<Renderer> (); 
			r.material.EnableKeyword("_EMISSION");
			r.material.SetColor("_EmissionColor", new Color(0,0,0));
		}

		int remove_cnt = removableBallList.Count;
		firstBlock = null;
		lastBlock = null;

		// Rayを遮断
//		print(GameObject.Find("RayCutMain"));

		// ブロック削除
		gameManagerController.StartCoroutine ("DeleteBlock", removableBallList);
		// ブロック落下
		gameManagerController.StartCoroutine("MoveBlock", (removableBallList.Count-1)*0.03f);
		GameObject[] lines = GameObject.FindGameObjectsWithTag("Line");
		foreach (GameObject line in lines) {
			Destroy(line);
		}
	}

	public void pushToList (GameObject obj) {
//		print ("pushToList");
		removableBallList.Add (obj);
	}

	// 選んだ色のブロックのみ際立たせる
	// 消すブロックを光らせる
	// DirectionLightのBlockをoffにする
	public void prominentColor(GameObject obj) {
		if (obj.tag == "CubeBlue") {// Blueをタップした場合
			light.SetActive(false);
			GameObject[] blueBlocks = GameObject.FindGameObjectsWithTag(obj.tag);
			foreach (GameObject block in blueBlocks) {
				Renderer r = block.GetComponent<Renderer> (); 
				r.material.EnableKeyword("_EMISSION");
				r.material.SetColor("_EmissionColor", new Color(0,0,1));
			}
		} else if (obj.tag == "CubeGreen") {// Greenをタップした場合
			light.SetActive(false);
			GameObject[] greenBlocks = GameObject.FindGameObjectsWithTag(obj.tag);
			foreach (GameObject block in greenBlocks) {
				Renderer r = block.GetComponent<Renderer> (); 
				r.material.EnableKeyword("_EMISSION");
				r.material.SetColor("_EmissionColor", new Color(0,1,0));
			}
		} else if (obj.tag == "CubeRed") {// Redをタップした場合
			light.SetActive(false);
			GameObject[] redBlocks = GameObject.FindGameObjectsWithTag(obj.tag);
			foreach (GameObject block in redBlocks) {
				Renderer r = block.GetComponent<Renderer> (); 
				r.material.EnableKeyword("_EMISSION");
				r.material.SetColor("_EmissionColor", new Color(1,0,0));
			}
		} else if (obj.tag == "CubeYellow") {// Yellowをタップした場合
			light.SetActive(false);
			GameObject[] yellowBlocks = GameObject.FindGameObjectsWithTag(obj.tag);
			foreach (GameObject block in yellowBlocks) {
				Renderer r = block.GetComponent<Renderer> (); 
				r.material.EnableKeyword("_EMISSION");
				r.material.SetColor("_EmissionColor", new Color(1,1,0));
			}
		} else {
			// 何もしない
		}
	}

	// 時間差でブロックを動かす
	public IEnumerator MoveBlock(float wait)
	{
		yield return new WaitForSeconds(wait);
		countDel = new int[bcScript.getRow()];
		float playerPosX = player.transform.position.x;
		int matrixPlayerPosX = pScript.getMatrixX ((int)playerPosX);
		float playerPosY = player.transform.position.y;
		int matrixPlayerPosY = pScript.getMatrixY ((int)playerPosY);
		// 列ごとに空白マスの個数を算出、ブロックを下に移動
		for (int i = 0; i < bcScript.getRow (); i++) {
			// 最も下の行(行数-1)から最高位(インデックス2)までブロックが存在しているかを判定
			for (int j = bcScript.getLine () + 1; j > 1; j--) {
				// 存在している場合：countDelが0の場合落下しない/countDelがそれ以外の場合はcountDelの値分落下
				// 存在してない場合：存在していないブロックの個数をcountDel[]に格納
				if (bcScript.getIsExistBlock (i, j)) {
					if (countDel [i] > 0) {
						// ブロック移動先のindexYを取得
						int destinationY = j + countDel [i];
						// 移動するブロックを取得
						GameObject dropBlock = bcScript.getBlock (i, j);
						// ブロック移動先を算出
						int dropBlockPosY = destinationY * 100;
						// 落下
						iTween.MoveTo (dropBlock, iTween.Hash ("x", dropBlock.transform.position.x, "y", BLOCK_POSITION_Y_MAX - dropBlockPosY));
						yield return new WaitForSeconds (0.05f);

						// 移動元のsetExistをfalseにする
						bcScript.setIsExistBlock (i, j, false);
						// 移動先のsetExistをtrueにする
						bcScript.setIsExistBlock (i, destinationY, true);
						// 移動先の座標にブロックを入れ替える
						bcScript.setBlock (i, destinationY, dropBlock);
						print("countDel="+countDel[i]);
					}
				} else {
					countDel [i] = countDel [i] + 1;
				}

				// キャラの落下処理
				if (j == 2 && i == matrixPlayerPosX) {
					iTween.MoveTo (player, iTween.Hash ("x", player.transform.position.x, "y", PLAYER_POSITION_Y_MAX - (j + countDel [i])*100));
					yield return new WaitForSeconds (0.05f);
				}
			}
		}
		// 落下するブロックの数だけ遅延させる
		for (int i = 0; i < bcScript.getRow (); i++) {
			dropBlockNum += countDel [i];
		}
		yield return new WaitForSeconds(dropBlockNum * 0.05f);
	}
}
