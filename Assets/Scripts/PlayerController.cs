﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	GameObject player;
	GameManagerController gmScript;
	private GameObject firstCollider;
	private GameObject lastCollider;
	private string currentName;
	private Animator animator;
	private const string key_isIdle = "isIdle";
	private const string key_isRun = "isRun";
	private const string key_isWalk = "isWalk";
	private const string key_isAttack = "isAttack";
	private const string key_isJump = "isJump";

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
		player.transform.position = new Vector2 (0, 0.6f);
		gmScript = GameObject.Find("GameManager").GetComponent<GameManagerController> ();
		this.animator = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.DownArrow)) {
			// WaitからRunに遷移する
			this.animator.SetBool(key_isIdle, false);
			this.animator.SetBool (key_isRun, true);
		} else if (Input.GetKey (KeyCode.RightArrow)) {
			this.animator.SetBool(key_isRun, false);
			this.animator.SetBool (key_isIdle, true);
		}
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

	// プレイヤーの位置取得
	public Vector2 getPosition() {
		return player.transform.position;
	}
		
	// プレイヤーを動かす
//	public void movePlayer(float moveX, float moveY) {
//		float positionX = moveX * 0.4f - 1.2f;
//		float positionY = 0.8f - moveY * 0.4f - 0.6f;
//		iTween.MoveTo(player, iTween.Hash("x", positionX, "y", positionY));
//	}
		
	// プレイヤーのXポジションからMatrixX取得
	public int getMatrixX(float x) {
		float row = (x + 1.2f) / 0.4f;
		return Mathf.CeilToInt(row);
	}

	// ブロックのYポジションからMatrixY取得
	public int getMatrixY(float y) {
		float line = (0.4f - y) / 0.4f;
		return Mathf.CeilToInt(line);
	}
}
