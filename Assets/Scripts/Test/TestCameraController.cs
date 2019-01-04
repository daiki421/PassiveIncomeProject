using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCameraController : MonoBehaviour {

	GameObject mainCam;
	private int BLOCK_POSITION_Y_MAX = 1100;
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
	TestCameraController ccScript;
	private int PLAYER_POSITION_Y_MAX = 1150;
	//	public bool isPushRemoveList = false;
	List<bool> isPushRemoveList = new List<bool>();

	// Use this for initialization
	void Start () {
		mainCam = Camera.main.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		
//		if (mainCam.transform.position.y < GameObject.Find ("Floors").transform.position.y + 667) {
//			mainCam.transform.position = new Vector3 (mainCam.transform.position.x, 300, -500);
//		} else {
//			
//		}
	}

	public void moveCamera(int dropBlockPosY) {
		iTween.MoveTo (mainCam, iTween.Hash ("x", mainCam.transform.position.x, "y", BLOCK_POSITION_Y_MAX - dropBlockPosY));
	}
}
