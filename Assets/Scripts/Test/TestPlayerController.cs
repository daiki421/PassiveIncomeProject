using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerController : MonoBehaviour {

	GameObject player;
	TestGameManagerController gmScript;
	private GameObject firstCollider;
	private GameObject lastCollider;
	private string currentName;
	private Animator animator;
	private const string key_isIdle = "isIdle";
	private const string key_isRun = "isRun";
	private const string key_isWalk = "isWalk";
	private const string key_isAttack = "isAttack";
	private const string key_isJump = "isJump";
	TestBlockController bcScript;
	float afterMovePosY = 0;
	float beforeMovePosY = 0;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
		player.transform.position = new Vector2 (300, 950);
		gmScript = GameObject.Find("GameManager").GetComponent<TestGameManagerController> ();
		this.animator = GetComponent<Animator>();
		beforeMovePosY = player.transform.position.y;
	}

	// Update is called once per frame
	void Update () {
//		print ("MatrixX="+getMatrixX((int)getPosition().x));
//		print ("MatrixY="+getMatrixY((int)getPosition().y));
		if (Input.GetKey (KeyCode.DownArrow)) {
			// WaitからRunに遷移する
			this.animator.SetBool(key_isIdle, false);
			this.animator.SetBool (key_isRun, true);
		} else if (Input.GetKey (KeyCode.RightArrow)) {
			this.animator.SetBool(key_isRun, false);
			this.animator.SetBool (key_isIdle, true);
		}

//		if (player.transform.position.y <= GameObject.Find("Floors").transform.position.y + 0.35f) {
//			player.transform.position = new Vector2 (player.transform.position.x, GameObject.Find("Floors").transform.position.y + 0.35f);
//			Camera.main.gameObject.transform.position = new Vector3 (Camera.main.gameObject.transform.position.x, GameObject.Find("Floors").transform.position.y + 0.35f, -5);
//		}
	}

	public void idleMotion() {
		this.animator.SetBool(key_isRun, false);
		this.animator.SetBool(key_isWalk, false);
		this.animator.SetBool(key_isJump, false);
		this.animator.SetBool(key_isAttack, false);
		this.animator.SetBool(key_isIdle, true);
	}

	public void runMotion() {
		this.animator.SetBool(key_isIdle, false);
		this.animator.SetBool(key_isWalk, false);
		this.animator.SetBool(key_isJump, false);
		this.animator.SetBool(key_isAttack, false);
		this.animator.SetBool(key_isRun, true);
	}

	public void jumpMotion() {
		this.animator.SetBool(key_isIdle, false);
		this.animator.SetBool(key_isWalk, false);
		this.animator.SetBool(key_isRun, false);
		this.animator.SetBool(key_isAttack, false);
		this.animator.SetBool(key_isJump, true);
	}

	// プレイヤーの位置取得
	public Vector2 getPosition() {
		return player.transform.position;
	}


	// プレイヤーを動かす
//	public void movePlayer(int moveX, int moveY) {
//		float positionX = moveX * 0.4f - 1.2f;
//		float positionY = 0.8f - moveY * 0.4f;
//		iTween.MoveTo(player, iTween.Hash("x", positionX, "y", positionY));
//	}

//	public IEnumerator movePlayer() {
//		for (int i = 1; i < gmScript.getReadCrumbsList().Count; i++) {
//			float positionX = gmScript.getMoveListX()[i] * 0.4f - 1.2f;
//			float positionY = 1.2f - gmScript.getMoveListY()[i] * 0.4f - 0.6f;
//			//			print ("readCrumbsList.Count="+readCrumbsList.Count);
//			//			print ("positionX=" + positionX + ", positionY=" + positionY);
//			print ("moveListX=" + gmScript.getMoveListX()[i] + ", moveListY=" + gmScript.getMoveListY()[i]);
//			iTween.MoveTo(player, iTween.Hash("x", positionX, "y", positionY));
//			yield return new WaitForSeconds(0.08f);
//		}
//		idleMotion ();
//	}

	// プレイヤーのXポジションからMatrixX取得
	public int getMatrixX(int x) {
		int row = x / 100;
		return row;
	}

	// ブロックのYポジションからMatrixY取得
	public int getMatrixY(int y) {
		int line = (1100 - (y + 50)) / 100;
		return line;
	}
}
