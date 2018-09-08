using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockExistController : MonoBehaviour {

	// Use this for initialization
//	void Start () {
//		GameObject cube = GameObject.Find ("Cube");
//		MeshRenderer mesh = cube.GetComponent<MeshRenderer>();
//		print (mesh.materials [0]);
//		cube.GetComponent<Renderer>().material.SetColor = mesh.materials[0];
//		GameObject block = Instantiate(cube, new Vector2(0, 0), Quaternion.AngleAxis(Random.Range(-1, 1), Vector3.up)) as GameObject;
//	}

	public Material[] _material;           // 割り当てるマテリアル. 
	private int i;

	// Use this for initialization 
	void Start () { 
		i = 0; 
	}

	// Update is called once per frame 
	void Update () {

		if (Input.GetKeyUp(KeyCode.Space)) { 
			
			if (i == 3) { 
				i = 0; 
			}
			 
			this.GetComponent<Renderer>().material=_material[i]; 
			i++;
		} 

	} 

	// Update is called once per frame
//	void Update () {
//		
//	}


}
