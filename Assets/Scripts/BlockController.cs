using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour {

	private float scale = 0.38f; // ブロックスケール
	private int BLOCK_LINE = 15; // ブロックの行
	private int BLOCK_ROW = 7; // ブロックの列
	float blockPosX = 0;
	float blockPosY = 0;
	// ブロックが存在しているかを格納
	public bool[,] existObjects;
	// 存在しているブロックのオブジェクトを格納
	public GameObject[,] blocks;
	public Material[] _material;
	private int materialNum;

	void Start () {
		existObjects = new bool[BLOCK_ROW,BLOCK_LINE];
		blocks = new GameObject[BLOCK_ROW, BLOCK_LINE];
		createObject(BLOCK_ROW, BLOCK_LINE);
		materialNum = 0;
	}

	// ブロックをプレファブから生成して配置する
	void createObject (int BLOCK_ROW, int BLOCK_LINE) {
		for (int i = 0; i < BLOCK_ROW; i++) {
			for (int j = 0; j < BLOCK_LINE; j++) {
				// オブジェクト名のナンバー
//				int objectNum = Random.Range(1, 5);
				int objectNum = Random.Range(1, 2);
				// プレファブ取得
				GameObject cubePrefab = GameObject.Find("Block"+objectNum);
//				GameObject cubePrefab = GameObject.Find("Block");
//				cubePrefab.GetComponent<Renderer>().material=_material[objectNum]; 
//				print (objectNum);
				// オブジェクトのポジション設定
				blockPosX = -1.2f + i * 0.4f;
				blockPosY = 0.4f - j * 0.4f;
				Vector2 blockPosition = new Vector2(blockPosX, blockPosY);
				// プレファブからインスタンス生成
				// x座標桁落ちのため分岐処理挟む
				if (i == 3) {
					GameObject block = Instantiate(cubePrefab, new Vector2(0, blockPosY), Quaternion.AngleAxis(Random.Range(-1, 1), Vector3.up)) as GameObject;
					// オブジェクトのスケール設定
					block.transform.localScale = Vector3.one * scale;
					setBlock (i, j, block);
				} else {
					GameObject block = Instantiate(cubePrefab, blockPosition, Quaternion.AngleAxis(Random.Range(-1, 1), Vector3.up)) as GameObject;
					// オブジェクトのスケール設定
					block.transform.localScale = Vector3.one * scale;
					setBlock (i, j, block);
				}
//				print (i + "," + j);
//				print (blocks [i, j]);
				existObjects[i, j] = true;
//				print ("(i, j) = "+"("+i+", "+j+")"+":"+existObjects[i, j]);
			}
		}
	}

	void Update () {
	}

	public void setIsExistBlock(int row, int line, bool status) {
		existObjects [row, line] = status;
	}

	public bool getIsExistBlock(int row, int line) {
		return existObjects [row, line];
	}

	public int getRow() {
		return BLOCK_ROW;
	}

	public int getLine() {
		return BLOCK_LINE;
	}
		
	// 指定の座標のブロックを取得
	public GameObject getBlock(int row, int line)
	{
		return blocks [row, line];
	}

	// 存在しているブロックを入れる配列
	public void setBlock(int row, int line, GameObject obj)
	{
		blocks [row, line] = obj;
	}


}
