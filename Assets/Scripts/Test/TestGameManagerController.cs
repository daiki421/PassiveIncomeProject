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

	// ボタン押下許可フラグ
	private bool isPushReloadButton = false;

	// ボタンが押されてから次にまた押せるまでの時間(秒)
	private TimeSpan allowTime = new TimeSpan(0, 0, 1);

	// 前回ボタンが押された時点と現在時間との差分を格納
	private TimeSpan pastTime;

	private DateTime reloadTime;

	void Start ()
	{
		mainCam = Camera.main.gameObject;
		player = GameObject.Find ("Player");
		bcScript = mainCam.GetComponent<TestBlockController> ();
		pScript = player.GetComponent<TestPlayerController> ();
		comparisonObj = null;
		ccScript = mainCam.GetComponent<CameraController> ();
	}

	void Update () {
		if (isPushReloadButton) {
			pastTime = DateTime.Now - reloadTime;
			if(pastTime > allowTime){
				isPushReloadButton = false;
			}
		}
	}

	// 時間差でブロック破壊
	public IEnumerator DeleteBlock (List<GameObject> list)
	{
		for (int i = 0; i < list.Count; i++) {
			Destroy(list[i]);
			yield return new WaitForSeconds(0.03f);
		}
	}

	// タップされた時にコールされる
	void OnMouseDown() {
		if (isPushReloadButton) {
			return;
		}
		isPushReloadButton = true;
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit = new RaycastHit ();
		if (Physics.Raycast (ray, out hit)) {
			if (hit.collider != null) {
				GameObject hitObj = hit.collider.gameObject;
				string charName = hitObj.name;
				if (charName.StartsWith ("CubeCollider")) {
					float distance = Vector2.Distance (player.transform.position, hitObj.transform.position);
					if (distance < 0.5f) {
						firstCollider = hitObj;
						lastCollider = hitObj;
						currentName = hitObj.name;
						readCrumbsList.Add (hitObj);
//						moveListX.Add(pScript.getMatrixX (hitObj.transform.position.x));
//						moveListY.Add(pScript.getMatrixY (hitObj.transform.position.y));
						lineDrawing (player, lastCollider);
					}
				}
			}
		}
		reloadTime = DateTime.Now;
	}

	// ドラッグされている間コールされる
	void OnMouseDrag() {
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit = new RaycastHit ();
		if (Physics.Raycast (ray, out hit)) {
			if (hit.collider != null) {
				GameObject hitObj = hit.collider.gameObject;
				string charName = hitObj.name + colliderNum;
				//				print ("readCrumbsList.Count" + readCrumbsList.Count);
				if (readCrumbsList.Count != 0) {
					float distance = Vector2.Distance (hitObj.transform.position, readCrumbsList [readCrumbsList.Count - 1].transform.position);
					if (charName.StartsWith ("CubeCollider")) {
						if (distance < 0.5f) {
							lastCollider = hitObj;
							readCrumbsList.Add (hitObj);
//							moveListX.Add (pScript.getMatrixX (hitObj.transform.position.x));
//							moveListY.Add (pScript.getMatrixY (hitObj.transform.position.y));
							lineDrawing (readCrumbsList [readCrumbsList.Count - 2], lastCollider);
						}
					}
				}
			} else {

			}
		}
	}

	// マウスボタンを離した時にコールされる
	void OnMouseUp() {

//		pScript.runMotion ();
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
//				print("("+i+","+j+")="+bcScript.getIsExistBlock (i, j));
				if (bcScript.getIsExistBlock (i, j)) {
					if (countDel [i] > 0) {
						// ブロック移動先のindexYを取得
						int destinationY = j + countDel [i];

//						print("destinationY="+destinationY);
//						print("j="+j+" / countDel["+i+"]="+countDel[i]);
						// 移動するブロックを取得
						GameObject dropBlock = bcScript.getBlock (i, j);
						// ブロック移動先を算出
						int dropBlockPosY = destinationY * 100;
						// 落下
						iTween.MoveTo (dropBlock, iTween.Hash ("x", dropBlock.transform.position.x, "y", 1100 - dropBlockPosY));
						yield return new WaitForSeconds (0.05f);
						if (j == 2 && i == matrixPlayerPosX) {
							print("i="+i+"=にいる");
							iTween.MoveTo (player, iTween.Hash ("x", player.transform.position.x, "y", 1150 - dropBlockPosY));
							yield return new WaitForSeconds (0.05f);
						} else {
							print("いない");
						}
						// 移動元のsetExistをfalseにする
						bcScript.setIsExistBlock (i, j, false);
//						print ("------------");
						// 移動先のsetExistをtrueにする
						bcScript.setIsExistBlock (i, destinationY, true);
						// 移動先の座標にブロックを入れ替える
						bcScript.setBlock (i, destinationY, dropBlock);
					}
				} else {
					countDel [i] = countDel [i] + 1;
				}

			}

//			print ("countDel [" + i + "]=" + countDel [i]);
//			print("----------------------");
		}
//		 キャラの落下距離算出、+2はブロック生成場所のYがインデックス2以上だから
//		 キャラのいるY軸上で破壊されたブロックの個数 - 落下前のキャラのYインデックス + 1
//		int dropPlayerPosY = (countDel[matrixPlayerPosX] - matrixPlayerPosY) * 100;
//		print ("dropPlayerPosY="+dropPlayerPosY);
//		iTween.MoveTo (player, iTween.Hash ("x", playerPosX, "y", 1150 - dropPlayerPosY));
//		 落下するブロックの数だけ遅延させる
		for (int i = 0; i < bcScript.getRow (); i++) {
			dropBlockNum += countDel [i];
		}
		yield return new WaitForSeconds(dropBlockNum * 0.05f);
//		GameObject.Find("RayCutMain").GetComponent<BoxCollider> ().enabled = false;
	}

	// 消すブロックを繋げる線を表示する
	public void lineDrawing(GameObject obj1, GameObject obj2) {
		GameObject newLine = new GameObject ("Line");
		LineRenderer lRend = newLine.AddComponent<LineRenderer> ();
		lRend.tag = "Line";
		lRend.material.color = new Color (255, 255, 255, 0);
		lRend.SetVertexCount(2);
		lRend.SetWidth (10f, 10f);
		Vector3 startVec = new Vector3 (obj1.transform.position.x, obj1.transform.position.y, -50);
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

	public List<GameObject> getReadCrumbsList() {
		return readCrumbsList;
	}

	public IEnumerator movePlayer() {
//		pScript.idleMotion ();
		for (int i = 1; i < readCrumbsList.Count; i++) {
			float positionX = moveListX[i] * 0.4f - 1.2f;
			float positionY = 0.8f - moveListY[i] * 0.4f - 0.6f;
			//			print ("readCrumbsList.Count="+readCrumbsList.Count);
			//			print ("positionX=" + positionX + ", positionY=" + positionY);
			print ("moveListX=" + moveListX[i] + ", moveListY=" + moveListY[i]);
			iTween.MoveTo(player, iTween.Hash("x", positionX, "y", positionY));
			yield return new WaitForSeconds(0.08f);
		}

	}
}
