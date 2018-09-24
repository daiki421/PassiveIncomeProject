using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerController : MonoBehaviour {

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
	CameraController ccScript;
	GameObject mainCam;

	void Start ()
	{
		mainCam = Camera.main.gameObject;
		player = GameObject.Find ("Player");
		bcScript = mainCam.GetComponent<BlockController> ();
		pScript = player.GetComponent<PlayerController> ();
		comparisonObj = null;
		ccScript = mainCam.GetComponent<CameraController> ();
	}

	// 時間差でブロック破壊
	public IEnumerator DeleteBlock (List<GameObject> list)
	{
		for (int i = 0; i < list.Count; i++) {
			Destroy(list[i]);
			yield return new WaitForSeconds(0.03f);
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
//					print ("Distance="+distance);
					if (distance < 0.5f) {
						firstCollider = hitObj;
						lastCollider = hitObj;
						currentName = hitObj.name;
						readCrumbsList.Add (hitObj);
						moveListX.Add(pScript.getMatrixX (hitObj.transform.position.x));
						moveListY.Add(pScript.getMatrixY (hitObj.transform.position.y));
						lineDrawing (player, lastCollider);
					}
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
				print ("readCrumbsList.Count" + readCrumbsList.Count);
				if (readCrumbsList.Count != 0) {
					float distance = Vector2.Distance (hitObj.transform.position, readCrumbsList[readCrumbsList.Count-1].transform.position);
					if (charName.StartsWith ("CubeCollider")) {
						if (distance < 0.5f) {
							if (comparisonObj == null || comparisonObj != hitObj) {
								lastCollider = hitObj;
								readCrumbsList.Add (hitObj);
								moveListX.Add (pScript.getMatrixX (hitObj.transform.position.x));
								moveListY.Add (pScript.getMatrixY (hitObj.transform.position.y));
								lineDrawing (readCrumbsList [readCrumbsList.Count - 2], lastCollider);
								comparisonObj = hitObj;
							}
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
		yield return new WaitForSeconds(wait);
		countDel = new int[bcScript.getRow()];

		// 列ごとに空白マスの個数を算出、ブロックを下に移動
		for (int i = 0; i < bcScript.getRow (); i++) {
			// 最も下の行(行数-1)からブロックが存在している最高位(インデックス2)までブロックが存在しているかを判定
			for (int j = bcScript.getLine () - 1; j >= 2; j--) {
				// 存在している場合：countDelが0の場合落下しない/countDelがそれ以外の場合はcountDelの値分落下
				// 存在してない場合：存在していないブロックの個数をcountDel[]に格納
				if (bcScript.getIsExistBlock (i, j)) {
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

						// 移動先の座標にブロックを入れ替える
						bcScript.setBlock (i, destinationY, dropBlock);
					}
				} else {
					countDel [i] = countDel [i] + 1;
				}
			}
		}
		// キャラの落下距離算出、+2はブロック生成場所のYがインデックス2以上だから
		float dropPlayerPosY = (countDel [pScript.getMatrixX (player.transform.position.x)] - pScript.getMatrixY (player.transform.position.y) + 2) * -0.4f;
		iTween.MoveBy (player, iTween.Hash ("y", dropPlayerPosY));
//		print ("dropPlayerPosY=" + dropPlayerPosY);
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
		for (int i = 1; i < readCrumbsList.Count; i++) {
			float positionX = moveListX[i] * 0.4f - 1.2f;
			float positionY = 1.2f - moveListY[i] * 0.4f - 0.6f;
//			print ("readCrumbsList.Count="+readCrumbsList.Count);
//			print ("positionX=" + positionX + ", positionY=" + positionY);
			print ("moveListX=" + moveListX[i] + ", moveListY=" + moveListY[i]);
			iTween.MoveTo(player, iTween.Hash("x", positionX, "y", positionY));
			yield return new WaitForSeconds(0.08f);
		}
		pScript.idleMotion ();
	}
}
