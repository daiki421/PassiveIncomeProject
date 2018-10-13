using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour {

	private float scale = 0.38f; // ブロックスケール
	private int BLOCK_LINE = 16; // ブロックの行
	private int BLOCK_ROW = 7; // ブロックの列
	float blockPosX = 0;
	float blockPosY = 0;
	// ブロックが存在しているかを格納
	public bool[,] existObjects;
	// 存在しているブロックのオブジェクトを格納
	public GameObject[,] blocks;
	public Material[] _material;
	private int materialNum;
	private Dictionary<float, int> dicX = new Dictionary<float, int> ();

	void Start () {
		existObjects = new bool[BLOCK_ROW,20];
		blocks = new GameObject[BLOCK_ROW, BLOCK_LINE];
		createObject(BLOCK_ROW, BLOCK_LINE);
		setExistsInArray (BLOCK_ROW, BLOCK_LINE);
		materialNum = 0;
		dicX = new Dictionary<float, int> () {{-1.2f, 0}, {-0.8f, 1}, {-0.4f, 2}, {0, 3}, {0.4f, 4}, {0.8f, 5}, {1.2f, 6}};
	}

	// ブロックをプレファブから生成して配置する
	void createObject (int BLOCK_ROW, int BLOCK_LINE) {
		for (int i = 0; i < BLOCK_ROW; i++) {
			for (int j = 2; j < BLOCK_LINE; j++) {
				// オブジェクト名のナンバー
//				int objectNum = Random.Range(1, 5);
				int objectNum = Random.Range(1, 2);
				// プレファブ取得
				GameObject cubePrefab = GameObject.Find("Block"+objectNum);
				// オブジェクトのポジション設定
				blockPosX = -1.2f + i * 0.4f;
				blockPosY = 0.8f - j * 0.4f;
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
			}
		}
	}

	// ブロックの存在判定を配列に格納
	void setExistsInArray (int BLOCK_ROW, int BLOCK_LINE) {
		for (int i = 0; i < BLOCK_ROW; i++) {
			for (int j = 0; j < 20; j++) {
				if (j == 0 || j == 1) {
					setIsExistBlock (i, j, false);
				} else {
					setIsExistBlock (i, j, true);
				}
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
	public int getMatrixX(float x) {
		float row = (x + 1.2f) / 0.4f;
		return Mathf.CeilToInt(row);
	}

	// ブロックのYMatrix取得
	public int getMatrixY(float y) {
		float line = (0.8f - y) / 0.4f;
		return Mathf.CeilToInt(line);
	}
}
