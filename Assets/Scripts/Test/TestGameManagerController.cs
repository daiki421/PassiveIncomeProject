using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TestGameManagerController : MonoBehaviour {

	TestBlockStatusController bsScript;
	TestBlockController bcScript;
	TestPlayerController pScript;
	int[] countDel;
	int dropBlockNum = 0;
	public GameObject player;
	private GameObject firstObject;
	private GameObject lastObject;
	private string currentName;
	List<GameObject> readCrumbsList = new List<GameObject>();
	List<int> moveListX = new List<int>();
	List<int> moveListY = new List<int>();
	bool isExistAllow = false;
	int colliderNum = 0;
	GameObject comparisonObj;
	TestCameraController ccScript;
	GameObject mainCam;
	private int PLAYER_POSITION_Y_MAX = 1150;
	private int BLOCK_POSITION_Y_MAX = 1100;
	List<bool> isPushRemoveList = new List<bool>();
	GameObject light;
	List<GameObject> removableBallList = new List<GameObject>();

	void Start ()
	{
		mainCam = Camera.main.gameObject;
		player = GameObject.Find ("Player");
		bcScript = mainCam.GetComponent<TestBlockController> ();
		pScript = player.GetComponent<TestPlayerController> ();
		comparisonObj = null;
		ccScript = mainCam.GetComponent<TestCameraController> ();
		bsScript = GameObject.Find ("BlockStatus").GetComponent<TestBlockStatusController> ();
		light = GameObject.Find ("BlockLight");
	}

	void Update () {

		if (getMatrixX ((int)GameObject.Find ("Goal").transform.position.x) == getMatrixX ((int)player.transform.position.x) && (bcScript.getLine() - (int)player.transform.position.y / 100) == bcScript.getLine() + 1) {
			print ("GOAL");
		}
	}

	// 時間差でブロック破壊
	public IEnumerator DeleteBlock (List<GameObject> list)
	{
		print (list.Count);
		for (int i = 0; i < list.Count; i++) {
			print (list[i]);
			Destroy(list[i]);
			yield return new WaitForSeconds(0.03f);
		}
	}


	// マウスボタンが押された時にコールされる
//	void OnMouseDown() {
//		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
//		RaycastHit hit = new RaycastHit ();
//		if (Physics.Raycast (ray, out hit)) {
//			if (hit.collider != null) {
//				// ヒットしたオブジェクト取得
//				GameObject hitObj = hit.collider.gameObject;
//				// オブジェクトの名前取得
//				string ballName = hitObj.name;
//				print ("ballName="+ballName);
//				if (ballName.StartsWith ("Block")) {
//					float distance = Vector2.Distance (pScript.getPosition (), hitObj.transform.position);
//					if (distance < 142) {
//						firstObject = hitObj;
//						lastObject = hitObj;
//						prominentColor (hitObj);
//						currentName = hitObj.name;
//						// 消すブロックをリストに格納
//						pushToList (hitObj);
//						// ヒットしたブロックの座標を取得
//						int matrixX = bcScript.getMatrixX ((int)hitObj.transform.position.x);
//						int matrixY = bcScript.getMatrixY ((int)hitObj.transform.position.y);
//						//					print (matrixX + "," + matrixY);
//						// ヒットしたブロックの存在判定をfalse
//						bcScript.setIsExistBlock (matrixX, matrixY, false);
//					}
//				} 
//			}
//		}
//	}
//	//
//	//	// ドラッグしている間コールされ続ける
//	void OnMouseDrag() {
//		print ("Drag");
//		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
//		RaycastHit hit = new RaycastHit ();
//		if (Physics.Raycast (ray, out hit)) {
//			if (hit.collider != null) {
//				GameObject hitObj = hit.collider.gameObject;
//				if (hitObj.name == currentName && lastObject != hitObj) {
//					float distance = Vector2.Distance (hitObj.transform.position, lastObject.transform.position);
//										print (distance);
////					if (distance < 142) {
//						lastObject = hitObj;
//						// 消すブロックをリストに格納
//						print("hitObj="+hitObj);
//						pushToList (hitObj);
//
//						// 連結のライン用事
//						lineDrawing (removableBallList[removableBallList.Count - 2], lastObject);
//						// ドラッグしたブロックの座標を算出
//						int matrixX = bcScript.getMatrixX ((int)hitObj.transform.position.x);
//						int matrixY = bcScript.getMatrixY ((int)hitObj.transform.position.y);
//						// ブロックの存在有無を格納
//						bcScript.setIsExistBlock (matrixX, matrixY, false);
////					}
//				} 
//			}
//		}
//	}
//	//
//	//	// マウスボタンを離した時にコールされる
//	void OnMouseUp() {
//		light.SetActive (true);
//		// オブジェクト発光消す
//		GameObject[] blueBlocks = GameObject.FindGameObjectsWithTag("CubeBlue");
//		foreach (GameObject block in blueBlocks) {
//			Renderer r = block.GetComponent<Renderer> (); 
//			r.material.EnableKeyword("_EMISSION");
//			r.material.SetColor("_EmissionColor", new Color(0,0,0));
//		}
//		GameObject[] greenBlocks = GameObject.FindGameObjectsWithTag("CubeGreen");
//		foreach (GameObject block in greenBlocks) {
//			Renderer r = block.GetComponent<Renderer> (); 
//			r.material.EnableKeyword("_EMISSION");
//			r.material.SetColor("_EmissionColor", new Color(0,0,0));
//		}
//		GameObject[] redBlocks = GameObject.FindGameObjectsWithTag("CubeRed");
//		foreach (GameObject block in redBlocks) {
//			Renderer r = block.GetComponent<Renderer> (); 
//			r.material.EnableKeyword("_EMISSION");
//			r.material.SetColor("_EmissionColor", new Color(0,0,0));
//		}
//		GameObject[] yellowBlocks = GameObject.FindGameObjectsWithTag("CubeYellow");
//		foreach (GameObject block in yellowBlocks) {
//			Renderer r = block.GetComponent<Renderer> (); 
//			r.material.EnableKeyword("_EMISSION");
//			r.material.SetColor("_EmissionColor", new Color(0,0,0));
//		}
//
//		int remove_cnt = removableBallList.Count;
//		firstObject = null;
//		lastObject = null;
//
//		// Rayを遮断
//		//		print(GameObject.Find("RayCutMain"));
//
//		// ブロック削除
//		StartCoroutine ("DeleteBlock", removableBallList);
//		// ブロック落下
////		StartCoroutine("MoveBlock", (removableBallList.Count-1)*0.03f);
//		GameObject[] lines = GameObject.FindGameObjectsWithTag("Line");
//		foreach (GameObject line in lines) {
//			Destroy(line);
//		}
//	}

//	public void pushToList (GameObject obj) {
//		//		print ("pushToList");
//		removableBallList.Add (obj);
//	}



	// タップされた時にコールされる
//	public void OnMouseDown() {
////		print("mouseDown");
//		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
//		RaycastHit hit = new RaycastHit ();
//		if (Physics.Raycast (ray, out hit)) {
//			if (hit.collider != null) {
//				GameObject hitObj = hit.collider.gameObject;
//				string charName = hitObj.name;
////				print ("Name=" + charName);
//				if (charName.StartsWith ("CubeCollider")) {
//					float distance = Vector2.Distance (player.transform.position, hitObj.transform.position);
////					print ("distance=" + distance);
//					if (distance < 181) {
//						firstObject = hitObj;
//						lastObject = hitObj;
//						currentName = hitObj.name;
//						readCrumbsList.Add (hitObj);
//						moveListX.Add (pScript.getMatrixX ((int)hitObj.transform.position.x));
//						moveListY.Add (pScript.getMatrixY ((int)hitObj.transform.position.y));
//						lineDrawing (player, lastObject);
//					}
//				} else if (charName.StartsWith ("Block")) {
//					float distance = Vector2.Distance (pScript.getPosition (), hitObj.transform.position);
//					if (distance < 142) {
//						firstObject = hitObj;
//						lastObject = hitObj;
//						bsScript.prominentColor (hitObj);
//						currentName = hitObj.name;
//						// 消すブロックをリストに格納
//						pushToList (hitObj);
//						// ヒットしたブロックの座標を取得
//						int matrixX = bcScript.getMatrixX ((int)hitObj.transform.position.x);
//						int matrixY = bcScript.getMatrixY ((int)hitObj.transform.position.y);
//						// print (matrixX + "," + matrixY);
//						// ヒットしたブロックの存在判定をfalse
//						bcScript.setIsExistBlock (matrixX, matrixY, false);
//						lineDrawing (player, lastObject);
//					}
//				}
//			}
//		}
//	}
//
//	// ドラッグされている間コールされる
//	public void OnMouseDrag() {
//		print ("mouseDrag");
//		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
//		RaycastHit hit = new RaycastHit ();
////		print (Physics.Raycast (ray, out hit));
//		if (Physics.Raycast (ray, out hit)) {
////			print (hit.collider);
//			if (hit.collider != null) {
//				GameObject hitObj = hit.collider.gameObject;
//				print ("hitObj=" + hitObj);
//				string charName = hitObj.name + colliderNum;
//
//				if (charName.StartsWith ("CubeCollider")) {
////					if (distance < 181) {
//						lastObject = hitObj;
//						readCrumbsList.Add (hitObj);
//						moveListX.Add (pScript.getMatrixX ((int)hitObj.transform.position.x));
//						moveListY.Add (pScript.getMatrixY ((int)hitObj.transform.position.y));
//						lineDrawing (readCrumbsList [readCrumbsList.Count - 2], lastObject);
////					}
//				} else if (charName.StartsWith ("Block")) {
//					
////					print ("removableBallList.Count="+removableBallList.Count);
////					if (distance < 181) {
//						lastObject = hitObj;
//						// 消すブロックをリストに格納
//						pushToList (hitObj);
//						// 連結のライン
//						lineDrawing (removableBallList[removableBallList.Count - 2], lastObject);
//						// ドラッグしたブロックの座標を算出
//						int matrixX = bcScript.getMatrixX ((int)hitObj.transform.position.x);
//						int matrixY = bcScript.getMatrixY ((int)hitObj.transform.position.y);
//						// ブロックの存在有無を格納
//						bcScript.setIsExistBlock (matrixX, matrixY, false);
////					}
//				}
//
////				if (readCrumbsList.Count != 0) {
////					int readCrumbsCount = readCrumbsList.Count;
////					float distance = Vector2.Distance (hitObj.transform.position, readCrumbsList [readCrumbsList.Count - 1].transform.position);
//////					print (distance);
//////					print ("Name=" + charName);
////					if (charName.StartsWith ("CubeCollider")) {
////						if (distance < 181) {
////							lastObject = hitObj;
////							readCrumbsList.Add (hitObj);
////							moveListX.Add (pScript.getMatrixX ((int)hitObj.transform.position.x));
////							moveListY.Add (pScript.getMatrixY ((int)hitObj.transform.position.y));
////							lineDrawing (readCrumbsList [readCrumbsList.Count - 2], lastObject);
////						}
////					} else if (charName.StartsWith ("Block")) {
////						print (distance);
////						if (distance < 181) {
////							lastObject = hitObj;
////							// 消すブロックをリストに格納
////							pushToList (hitObj);
////							// 連結のライン
////							lineDrawing (removableBallList[removableBallList.Count - 2], lastObject);
////							// ドラッグしたブロックの座標を算出
////							int matrixX = bcScript.getMatrixX ((int)hitObj.transform.position.x);
////							int matrixY = bcScript.getMatrixY ((int)hitObj.transform.position.y);
////							// ブロックの存在有無を格納
////							bcScript.setIsExistBlock (matrixX, matrixY, false);
////						}
////					}
////				}
//			}
//		}
//	}
//
//	// マウスボタンを離した時にコールされる
//	public void OnMouseUp() {
////		print("mouseUp");
////		print (removableBallList.Count);
//		if (lastObject.name.StartsWith("Block")) {
//			light.SetActive (true);
//			// オブジェクト発光消す
//			GameObject[] blueBlocks = GameObject.FindGameObjectsWithTag("CubeBlue");
//			foreach (GameObject block in blueBlocks) {
//				Renderer r = block.GetComponent<Renderer> (); 
//				r.material.EnableKeyword("_EMISSION");
//				r.material.SetColor("_EmissionColor", new Color(0,0,0));
//			}
//			GameObject[] greenBlocks = GameObject.FindGameObjectsWithTag("CubeGreen");
//			foreach (GameObject block in greenBlocks) {
//				Renderer r = block.GetComponent<Renderer> (); 
//				r.material.EnableKeyword("_EMISSION");
//				r.material.SetColor("_EmissionColor", new Color(0,0,0));
//			}
//			GameObject[] redBlocks = GameObject.FindGameObjectsWithTag("CubeRed");
//			foreach (GameObject block in redBlocks) {
//				Renderer r = block.GetComponent<Renderer> (); 
//				r.material.EnableKeyword("_EMISSION");
//				r.material.SetColor("_EmissionColor", new Color(0,0,0));
//			}
//			GameObject[] yellowBlocks = GameObject.FindGameObjectsWithTag("CubeYellow");
//			foreach (GameObject block in yellowBlocks) {
//				Renderer r = block.GetComponent<Renderer> (); 
//				r.material.EnableKeyword("_EMISSION");
//				r.material.SetColor("_EmissionColor", new Color(0,0,0));
//			}
//			int remove_cnt = removableBallList.Count;
//			firstObject = null;
//			lastObject = null;
//
//			// Rayを遮断
//			//		print(GameObject.Find("RayCutMain"));
//
//			// ブロック削除
//			StartCoroutine ("DeleteBlock", removableBallList);
//			// ブロック落下
//			StartCoroutine("MoveBlock", (removableBallList.Count-1)*0.03f);
//			GameObject[] lines = GameObject.FindGameObjectsWithTag("Line");
//			foreach (GameObject line in lines) {
//				Destroy(line);
//			}
//		} else if (lastObject.name.StartsWith("CubeCollider")) {
//			StartCoroutine ("movePlayer");
//			GameObject[] lines = GameObject.FindGameObjectsWithTag("Line");
//			foreach (GameObject line in lines) {
//				Destroy(line);
//			}
//		}
//	}
//
//	// 時間差でブロックを動かす
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

	// 消すブロックを繋げる線を表示する
	public void lineDrawing(GameObject obj1, GameObject obj2) {
//		print ("line引いてる");
		GameObject newLine = new GameObject ("Line");
		LineRenderer lRend = newLine.AddComponent<LineRenderer> ();
		lRend.tag = "Line";
		lRend.material.color = new Color (255, 255, 255, 0);
		lRend.SetVertexCount(2);
		lRend.SetWidth (10f, 10f);
		Vector3 startVec = new Vector3 (obj1.transform.position.x, obj1.transform.position.y, -50);
		if (obj1.name == "Player") {
			startVec = new Vector3 (obj1.transform.position.x, obj1.transform.position.y + 50, -50);
		}
		Vector3 endVec = new Vector3 (obj2.transform.position.x, obj2.transform.position.y, -50);
		lRend.SetPosition (0, startVec);
		lRend.SetPosition (1, endVec);
	}

	public List<int> getMoveListX() {
		return moveListX;
	}

	public List<int> getMoveListY() {
		return moveListY;
	}

//	public void pushToList (GameObject obj) {
//		print ("pushToList:"+obj);
//		removableBallList.Add (obj);
//	}

	public IEnumerator movePlayer() {
//		pScript.idleMotion ();
//		print(readCrumbsList.Count);
		for (int i = 1; i < readCrumbsList.Count; i++) {
			float positionX = moveListX[i] * 100;
			float positionY = 1100 - moveListY[i] * 100;
//			print ("moveListX=" + moveListX[i] + ", moveListY=" + moveListY[i]);
//			print ("positionX=" + positionX + ", positionY=" + positionX);
			iTween.MoveTo(player, iTween.Hash("x", positionX, "y", positionY));
			yield return new WaitForSeconds(0.05f);
		}
	}

	int getMatrixX (int x) {
		return x / 100;
	}

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
}

