using UnityEngine;
using System.Collections;

public class MoveSample : MonoBehaviour
{	
	public GameObject gameObject;
	void Start(){
		iTween.MoveBy(gameObject, iTween.Hash("y", -1, "easeType", "easeInOutExpo", "delay", .01));
//		iTween.MoveBy(gameObject, iTween.Hash ("y", gameObject.transform.position.x-1));
	}
}

