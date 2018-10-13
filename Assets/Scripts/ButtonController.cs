using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class ButtonController : MonoBehaviour {
	BlockController bcScript;
	GameObject mainCam;
	// Use this for initialization
	void Start () {
		mainCam = Camera.main.gameObject;
		bcScript = mainCam.GetComponent<BlockController> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnResetButton() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void OnGetBlockExistButton() {
		for (int i = 0; i < bcScript.getRow(); i++) {
			for (int j = 0; j < bcScript.getLine(); j++) {
				print ("("+i+","+ j+")="+bcScript.getIsExistBlock (i, j));
			}
		}
	}
}
