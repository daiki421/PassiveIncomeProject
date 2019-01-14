using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemyController : MonoBehaviour {

	GameObject mainCam;
	TestBlockController bcScript;
	GameObject enemys;
	List<int> randRows = new List<int>();
	List<int> randLines = new List<int>();

	int enemyPosX = 0;
	int enemyPosY = 0;

	// Use this for initialization
	void Start () {
		mainCam = Camera.main.gameObject;
		bcScript = mainCam.GetComponent<TestBlockController> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void createEnemy(List<int> rowList, List<int> lineList) {
		foreach (Transform child in transform)
		{
			for (int i = 0; i < bcScript.getRow (); i++) {
				enemyPosX = 100 * rowList[i];
				enemyPosY = 900 - (lineList[i] - 2) * 100;
				Vector2 enemyPosition = new Vector2(enemyPosX, enemyPosY);
				GameObject enemy = Instantiate(child.gameObject, enemyPosition, Quaternion.AngleAxis(Random.Range(0, 0), Vector3.up)) as GameObject;
				enemy.transform.Rotate (0, 0, 180);
			}
		}
	}

	// 敵のX座標
	public List<int> getEnemyRow () {
		List<int> rows = new List<int>();
		for (int i = 0; i < bcScript.getRow (); i++) {
			rows.Add (i);
		}
		while (rows.Count > 0) {
			int index = Random.Range(0, rows.Count - 1);
			int ransu = rows[index];
			randRows.Add (ransu);
			rows.RemoveAt(index);
		}
		return randRows;
	}

	// 敵のY座標
	public List<int> getEnemyLine () {
		List<int> lines = new List<int>();
		for (int i = 2; i < bcScript.getLine () + 1; i++) {
			lines.Add (i);
		}
		while (lines.Count > 0) {
			int index = Random.Range(0, lines.Count);
			int ransu = lines[index];
			randLines.Add (ransu);
			lines.RemoveAt(index);
		}
		return randLines;
	}
}
