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
	TestBlockController blockController;
	// 落下予定のオブジェクトを入れる配列
	public GameObject[,] moveObjects;
	int[] countDel;
	TestGameManagerController gameManagerController;
//	TestPlayerController pScript;
	GameObject light;
	Material originalMaterial1;
	Material originalMaterial2;
	Material originalMaterial3;
	Material originalMaterial4;
	private Renderer renderer;
	private Dictionary<float, int> test = new Dictionary<float, int> ();
	// ボタン押下許可フラグ
	private bool isPushReloadButton = false;

	// ボタンが押されてから次にまた押せるまでの時間(秒)
	private TimeSpan allowTime = new TimeSpan(0, 0, 1);

	// 前回ボタンが押された時点と現在時間との差分を格納
	private TimeSpan pastTime;
	private DateTime reloadTime;

	// Use this for initialization
	void Start () {
		mainCam = Camera.main.gameObject;
		blockController = mainCam.GetComponent<TestBlockController> ();
		moveObjects = new GameObject[blockController.getRow(),blockController.getLine()+2];
		countDel = new int[blockController.getRow()];
		gameManagerController = GameObject.Find("GameManager").GetComponent<TestGameManagerController> ();
//		pScript = GameObject.Find ("Player").GetComponent<TestPlayerController> ();
		light = GameObject.Find ("BlockLight");
		renderer = GetComponent<Renderer>();
		originalMaterial1 = new Material(renderer.material);
//		GameObject.Find("RayCutMain").GetComponent<BoxCollider> ().enabled = false;
	}

	void Update () {
		if (isPushReloadButton) {
			pastTime = DateTime.Now - reloadTime;
			if(pastTime > allowTime){
				isPushReloadButton = false;
			}
		}
	}

	// マウスボタンが押された時にコールされる
	void OnMouseDown() {
		if (isPushReloadButton) {
			return;
		}
		isPushReloadButton = true;
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit = new RaycastHit ();
		if (Physics.Raycast (ray, out hit)) {
			if (hit.collider != null) {
				// ヒットしたオブジェクト取得
				GameObject hitObj = hit.collider.gameObject;
				// オブジェクトの名前取得
				string ballName = hitObj.name;
				if (ballName.StartsWith ("Block")) {
//					float distance = Vector2.Distance (pScript.getPosition (), hitObj.transform.position);
//					if (distance < 0.5f) {
						firstBlock = hitObj;
						lastBlock = hitObj;
						prominentColor (hitObj);
						currentName = hitObj.name;
						// 消すブロックをリストに格納
						PushToList (hitObj);
						// ヒットしたブロックの座標を取得
						int matrixX = blockController.getMatrixX ((int)hitObj.transform.position.x);
						int matrixY = blockController.getMatrixY ((int)hitObj.transform.position.y);
//					print (matrixX + "," + matrixY);
						// ヒットしたブロックの存在判定をfalse
						blockController.setIsExistBlock (matrixX, matrixY, false);
//					}
				} 
			}
		}
		reloadTime = DateTime.Now;
	}

	// ドラッグしている間コールされ続ける
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
						PushToList (hitObj);
						// 連結のライン用事
						gameManagerController.lineDrawing (removableBallList[removableBallList.Count - 2], lastBlock);
						// ドラッグしたブロックの座標を算出
						int matrixX = blockController.getMatrixX ((int)hitObj.transform.position.x);
						int matrixY = blockController.getMatrixY ((int)hitObj.transform.position.y);
						// ブロックの存在有無を格納
						blockController.setIsExistBlock (matrixX, matrixY, false);
					}
				} 
			}
		}
	}

	// マウスボタンを離した時にコールされる
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
//		GameObject.Find("RayCutMain").GetComponent<BoxCollider> ().enabled = true;

		// ブロック削除
		gameManagerController.StartCoroutine ("DeleteBlock", removableBallList);
		// ブロック落下
		gameManagerController.StartCoroutine("MoveBlock", (removableBallList.Count-1)*0.03f);
		GameObject[] lines = GameObject.FindGameObjectsWithTag("Line");
		foreach (GameObject line in lines) {
			Destroy(line);
		}
	}

	void PushToList (GameObject obj) {
		removableBallList.Add (obj);
		//		ChangeColor(obj, 0.5f);
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
}
