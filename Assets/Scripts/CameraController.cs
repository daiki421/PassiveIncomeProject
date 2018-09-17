using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void moveCamera(float distance) {
		iTween.MoveBy(Camera.main.gameObject, iTween.Hash("y", distance));
//		print("distance="+distance);
	}
}
