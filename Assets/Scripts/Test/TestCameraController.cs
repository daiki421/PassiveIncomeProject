using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCameraController : MonoBehaviour {

	GameObject mainCam;
	private int BLOCK_POSITION_Y_MAX = 1100;

	// Use this for initialization
	void Start () {
		mainCam = Camera.main.gameObject;
		print ("mainCam.transform.position.y="+mainCam.transform.position.y);
		print ("Floors.transform.position.y="+GameObject.Find("Floors").transform.position.y);
	}
	
	// Update is called once per frame
	void Update () {
		
		if (mainCam.transform.position.y < GameObject.Find ("Floors").transform.position.y + 667) {
			mainCam.transform.position = new Vector3 (mainCam.transform.position.x, GameObject.Find ("Floors").transform.position.y + 667, -500);
		} else {
			
		}
	}

	public void moveCamera(int dropBlockPosY) {
		iTween.MoveTo (mainCam, iTween.Hash ("x", mainCam.transform.position.x, "y", BLOCK_POSITION_Y_MAX - dropBlockPosY));
	}
}
