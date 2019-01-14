using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Mathf;

public class TestBlockController : MonoBehaviour {

	private int scale = 95;
	private int goalScale = 33;
	private int BLOCK_LINE = 11; // ブロックの行
	private int BLOCK_ROW = 7; // ブロックの列
	int blockPosX = 0;
	int blockPosY = 0;
	// ブロックが存在しているかを格納
	public bool[,] existObjects;
	// 存在しているブロックのオブジェクトを格納
	public GameObject[,] blocks;
	public Material[] _material;
	private int materialNum;
	TestEnemyController ecScript;
	List<int> rows;
	List<int> lines;
	void Start () {
		existObjects = new bool[BLOCK_ROW, BLOCK_LINE+2];
		blocks = new GameObject[BLOCK_ROW, BLOCK_LINE+2];
		setExistsInArray (BLOCK_ROW, BLOCK_LINE+2);
		materialNum = 0;
		ecScript = GameObject.Find("Enemys").GetComponent<TestEnemyController> ();
		rows = ecScript.getEnemyRow ();
		lines = ecScript.getEnemyLine ();
		ecScript.createEnemy (rows, lines);
		createObject(BLOCK_ROW, BLOCK_LINE);
	}

	// ゴール設置列ランダム取得
	int getGoalRow () {
		return Random.Range (0, 6);
	}

	// ブロックをプレファブから生成して配置する
	void createObject (int BLOCK_ROW, int BLOCK_LINE) {
		int goalRow = getGoalRow ();
		for (int i = 0; i < BLOCK_ROW; i++) {
			for (int j = 2; j < BLOCK_LINE + 2; j++) {
				// オブジェクト名のナンバー
				//				int objectNum = Random.Range(1, 5); // 本番
				int objectNum = Random.Range(1, 2);
				if (i == goalRow && j == BLOCK_LINE + 1) {
					GameObject.Find ("Goal").transform.position = new Vector3 (100 * goalRow, 900 - (j - 2) * 100, 80);
				} else {
					// プレファブ取得
					GameObject cubePrefab = GameObject.Find("Block"+objectNum);
					// オブジェクトのポジション設定
					blockPosX = 100 * i;
					blockPosY = 900 - (j - 2) * 100;
					Vector2 blockPosition = new Vector2(blockPosX, blockPosY);
					// プレファブからインスタンス生成
					GameObject block = Instantiate(cubePrefab, blockPosition, Quaternion.AngleAxis(Random.Range(-1, 1), Vector3.up)) as GameObject;
					// オブジェクトのスケール設定
					block.transform.localScale = Vector3.one * scale;
					setBlock (i, j, block);
				}
			}
		}
		for (int i = 0; i < rows.Count; i++) {
			Destroy (getBlock (rows [i], lines [i]));
		}

	}

	// ブロックの存在判定を配列に格納
	void setExistsInArray (int BLOCK_ROW, int BLOCK_LINE) {
		for (int i = 0; i < BLOCK_ROW; i++) {
			for (int j = 2; j < BLOCK_LINE; j++) {
				setIsExistBlock (i, j, true);
			}
		}
	}

	// ブロックが存在しているかどうかを格納する配列
	public void setIsExistBlock(int row, int line, bool status) {
		existObjects [row, line] = status;
	}

	// ブロックが存在しているかどうかを取得する
	public bool getIsExistBlock(int row, int line) {
		return existObjects [row, line];
	}

	// 生成するブロックの列を取得
	public int getRow() {
		return BLOCK_ROW;
	}

	// 生成するブロックの行を取得
	public int getLine() {
		return BLOCK_LINE;
	}

	// 指定した座標のブロックを取得
	public GameObject getBlock(int row, int line)
	{
		return blocks [row, line];
	}

	// 存在しているブロックを格納する配列
	public void setBlock(int row, int line, GameObject obj)
	{
		blocks [row, line] = obj;
	}

	// ブロックのXMatrix取得
	public int getMatrixX(int x) {
		return x / 100;
	}

	// ブロックのYMatrix取得
	public int getMatrixY(int y) {
		// blockPosY = 900 - (j - 2) * 100の逆算
		return (900 - y) / 100 + 2;
	}

}
