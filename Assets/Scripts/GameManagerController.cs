using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerController : MonoBehaviour {

//	public GameObject obj;
	BlockStatusController bsScript;
	BlockController bcScript;
	int[] countDel;
	PlayerController pScript;
	int dropBlockNum = 0;
	public GameObject player;
	private GameObject firstCollider;
	private GameObject lastCollider;
	private string currentName;
	List<GameObject> readCrumbsList = new List<GameObject>();
	List<int> moveListX = new List<int>();
	List<int> moveListY = new List<int>();
	bool isExistAllow = false;
	int colliderNum = 0;
	GameObject comparisonObj;

	void Start ()
	{
		GameObject mainCam = Camera.main.gameObject;
//		player = GameObject.Find ("Player");
		bcScript = mainCam.GetComponent<BlockController> ();
		bsScript = mainCam.GetComponent<BlockStatusController> ();
		pScript = player.GetComponent<PlayerController> ();
		comparisonObj = null;
	}

	// 時間差でブロック破壊
	public IEnumerator DeleteBlock (List<GameObject> list)
	{
		for (int i = 0; i < list.Count; i++) {
			if (i <= list.Count-1) {
				Destroy(list[i]);
				yield return new WaitForSeconds(0.03f);
			}
		}
	}

	// マウスボタンが押された時にコールされる
	void OnMouseDown() {
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit = new RaycastHit ();
		if (Physics.Raycast (ray, out hit)) {
			if (hit.collider != null) {
				GameObject hitObj = hit.collider.gameObject;
				string charName = hitObj.name;
				if (charName.StartsWith ("CubeCollider")) {
					float distance = Vector2.Distance (player.transform.position, hitObj.transform.position);
					if (distance < 6f) {
						firstCollider = hitObj;
						lastCollider = hitObj;
						currentName = hitObj.name;
						readCrumbsList.Add (hitObj);
						moveListX.Add(pScript.getMatrixX (hitObj.transform.position.x));
						moveListY.Add(pScript.getMatrixY (hitObj.transform.position.y));
						lineDrawing (player, lastCollider);
					}
					print("CubeDown");
				}
			}
		}
	}

	// マウスボタンが押された時にコールされる
	void OnMouseDrag() {
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit = new RaycastHit ();
		if (Physics.Raycast (ray, out hit)) {
			if (hit.collider != null) {
				GameObject hitObj = hit.collider.gameObject;
				string charName = hitObj.name+colliderNum;
				float distance = Vector2.Distance (hitObj.transform.position, lastCollider.transform.position);
				if (charName.StartsWith ("CubeCollider")) {
					if (distance < 8f) {
						if (comparisonObj == null || comparisonObj != hitObj) {
							lastCollider = hitObj;
							readCrumbsList.Add (hitObj);
							moveListX.Add (pScript.getMatrixX (hitObj.transform.position.x));
							moveListY.Add (pScript.getMatrixY (hitObj.transform.position.y));
							lineDrawing (readCrumbsList[readCrumbsList.Count - 2], lastCollider);
							comparisonObj = hitObj;
						}
					}
				}
			}
		}
	}

	// マウスボタンを離した時にコールされる
	void OnMouseUp() {
		pScript.runMotion ();
		comparisonObj = null;
		// Rayを遮断
		GameObject.Find("RayCutMain").GetComponent<BoxCollider> ().enabled = true;
		StartCoroutine ("movePlayer");
		GameObject[] lines = GameObject.FindGameObjectsWithTag("Line");
		foreach (GameObject line in lines) {
			Destroy(line);
		}
	}

	// 時間差でブロックを動かす
	public IEnumerator MoveBlock(float wait)
	{
		int minJ = 100;
		yield return new WaitForSeconds(wait);
		countDel = new int[bcScript.getRow()];
//		print ("CountDel=" + countDel);
		// 列ごとに空白マスの個数を算出、ブロックを下に移動
		for (int i = 0; i < bcScript.getRow (); i++) {
			for (int j = bcScript.getLine () - 1; j >= 0; j--) {
				if (bcScript.getIsExistBlock (i, j) == true) {
					if (countDel [i] > 0) {
						// 移動する前に移動元のsetExistをfalseにする
						bcScript.setIsExistBlock (i, j, false);

						// ブロック移動先のY座標を取得
						int destinationY = j + countDel [i];

						// 移動先のsetExistをtrueにする
						bcScript.setIsExistBlock (i, destinationY, true);

						// 移動するブロックを取得
						GameObject dropBlock = bcScript.getBlock (i, j);

						// ブロック移動距離を算出
						float dropBlockPosY = countDel [i] * -0.4f;

						// 落下
						iTween.MoveBy (dropBlock, iTween.Hash ("y", dropBlockPosY));
						yield return new WaitForSeconds (0.05f);
//						if (i == pScript.getMatrixX (player.transform.position.x)) {
//							print ("i=" + i);
//							print ("MatrixX=" + pScript.getMatrixX (player.transform.position.x));
//							print ("j=" + j);
//							print ("MatrixY=" + pScript.getMatrixY (player.transform.position.y));
//							print ("playerY=" + player.transform.position.y);
//							print ("countDel="+countDel [i]);
//							print ("--------------------------------------------------------");
//							yield return new WaitForSeconds (0.15f);
//							float dropPlayerPosY = (countDel [i]) * -0.4f;
//							iTween.MoveBy (player, iTween.Hash ("y", dropBlockPosY));
//
//						} else {
//							yield return new WaitForSeconds (0.05f);
//						}
						// 移動先の座標にブロックを入れ替える
						bcScript.setBlock (i, destinationY, dropBlock);
					}
				} else {
					countDel [i] = countDel [i] + 1;
				}
			}

		}
		//ここでキャラ落下
		print ("countDel="+countDel [pScript.getMatrixX (player.transform.position.x)]);
		float dropPlayerPosY = countDel [pScript.getMatrixX (player.transform.position.x)] * -0.4f;
		iTween.MoveBy (player, iTween.Hash ("y", dropPlayerPosY));
		// 落下するブロックの数だけ遅延させる
		for (int i = 0; i < bcScript.getRow (); i++) {
			dropBlockNum += countDel [i];
		}
		yield return new WaitForSeconds(dropBlockNum * 0.05f);
		GameObject.Find("RayCutMain").GetComponent<BoxCollider> ().enabled = false;
	}

	// 消すブロックを繋げる線を表示する
	public void lineDrawing(GameObject obj1, GameObject obj2) {
		GameObject newLine = new GameObject ("Line");
		LineRenderer lRend = newLine.AddComponent<LineRenderer> ();
		lRend.tag = "Line";
		lRend.material.color = new Color (255, 255, 255, 0);
		lRend.SetVertexCount(2);
		lRend.SetWidth (0.05f, 0.05f);
		Vector3 startVec = new Vector3 (obj1.transform.position.x, obj1.transform.position.y, -0.37f);
		Vector3 endVec = new Vector3 (obj2.transform.position.x, obj2.transform.position.y, -0.37f);
		lRend.SetPosition (0, startVec);
		lRend.SetPosition (1, endVec);
	}

	public List<int> getMoveListX() {
		return moveListX;
	}

	public List<int> getMoveListY() {
		return moveListY;
	}

	public List<GameObject> getReadCrumbsList() {
		return readCrumbsList;
	}
		
	public IEnumerator movePlayer() {
		for (int i = 0; i < readCrumbsList.Count; i++) {
			float positionX = moveListX[i] * 0.4f - 1.2f;
			float positionY = 0.8f - moveListY[i] * 0.4f - 0.6f;
			iTween.MoveTo(player, iTween.Hash("x", positionX, "y", positionY));
			yield return new WaitForSeconds(0.08f);
		}
		pScript.idleMotion ();
	}
}
