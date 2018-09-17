using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockStatusController : MonoBehaviour {

	private GameObject firstBlock;
	private GameObject lastBlock;
	private string currentName;
	List<GameObject> removableBallList = new List<GameObject>();
	List<GameObject> moveBlockList = new List<GameObject>();
	List<float> moveBlockPosYList = new List<float>();
	GameObject mainCam;
	BlockController bcScript;
	// 落下予定のオブジェクトを入れる配列
	public GameObject[,] moveObjects;
	int[] countDel;
	GameManagerController gmScript;
	BlockStatusController bsScript;
	PlayerController pScript;
	GameObject light;
	Material originalMaterial1;
	Material originalMaterial2;
	Material originalMaterial3;
	Material originalMaterial4;
	private Renderer renderer;

	// Use this for initialization
	void Start () {
		mainCam = Camera.main.gameObject;
		bcScript = mainCam.GetComponent<BlockController> ();
		moveObjects = new GameObject[bcScript.getRow(),bcScript.getLine()];
		countDel = new int[bcScript.getRow()];
		gmScript = GameObject.Find("GameManager").GetComponent<GameManagerController> ();
		pScript = GameObject.Find ("Player").GetComponent<PlayerController> ();
		light = GameObject.Find ("BlockLight");
		renderer = GetComponent<Renderer>();
		originalMaterial1 = new Material(renderer.material);
		GameObject.Find("RayCutMain").GetComponent<BoxCollider> ().enabled = false;
	}

	// マウスボタンが押された時にコールされる
	void OnMouseDown() {
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit = new RaycastHit ();
		if (Physics.Raycast (ray, out hit)) {
			if (hit.collider != null) {
				GameObject hitObj = hit.collider.gameObject;
				string ballName = hitObj.name;
				if (ballName.StartsWith ("Block")) {
					float distance = Vector2.Distance (pScript.getPosition (), hitObj.transform.position);
					if (distance < 0.8f) {
						firstBlock = hitObj;
						lastBlock = hitObj;
						prominentColor (hitObj);
						currentName = hitObj.name;
						PushToList (hitObj);
						int matrixX = getMatrixX (hitObj.transform.position.x);
						int matrixY = getMatrixY (hitObj.transform.position.y);
						bcScript.setIsExistBlock (matrixX, matrixY, false);
						print ("Drag:("+matrixX+", "+matrixY+")"+bcScript.getIsExistBlock (matrixX, matrixY));
						setMoveObject (matrixX, matrixY, hitObj);
					}
				} 
			}
		}
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
					if (distance < 0.8f) {
						lastBlock = hitObj;
						PushToList (hitObj);
						gmScript.lineDrawing (removableBallList[removableBallList.Count - 2], lastBlock);
						int matrixX = getMatrixX (hitObj.transform.position.x);
						int matrixY = getMatrixY (hitObj.transform.position.y);
						bcScript.setIsExistBlock (matrixX, matrixY, false);
//						print ("Drag:("+matrixX+", "+matrixY+")"+bcScript.getIsExistBlock (matrixX, matrixY));
						setMoveObject (matrixX, matrixY, hitObj);
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
		GameObject.Find("RayCutMain").GetComponent<BoxCollider> ().enabled = true;

		// ブロック削除
		gmScript.StartCoroutine ("DeleteBlock", removableBallList);

		// ブロック落下
		gmScript.StartCoroutine("MoveBlock", (removableBallList.Count-1)*0.03f);
		GameObject[] lines = GameObject.FindGameObjectsWithTag("Line");
		foreach (GameObject line in lines) {
			Destroy(line);
		}
	}

	void PushToList (GameObject obj) {
		removableBallList.Add (obj);
//		ChangeColor(obj, 0.5f);
	}

	// 消すブロックの色変える
	void ChangeColor (GameObject obj, float transparency) {
		MeshRenderer meshrender = obj.GetComponent<MeshRenderer> ();
		meshrender.material.color = new Color(5, 5, 5, transparency);
	}

	// ブロックのXMatrix取得
	public int getMatrixX(float x) {
		float row = (x + 1.2f) / 0.4f;
		return Mathf.CeilToInt(row);
	}

	// ブロックのYMatrix取得
	public int getMatrixY(float y) {
		float line = (0.8f - y) / 0.4f;
		return Mathf.CeilToInt(line);
	}
		
	// ブロックを動かす処理
	public void moveBlock (GameObject obj, float moveY) {
		iTween.MoveBy(obj, iTween.Hash("y", moveY));
	}

	// 落下予定のブロックをセット
	public void setMoveObject(int row, int line, GameObject obj) {
		moveObjects [row, line] = obj;
	}

	// 落下予定のブロックを取得
	public GameObject getMoveObject(int row, int line) {
		return moveObjects [row, line];
	}

	// 落下距離算出
	public float getBlockDistance(float distance) {
		return distance * -0.4f;
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
