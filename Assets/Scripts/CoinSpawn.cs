using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CoinSpawn : MonoBehaviour {

	//public static coinSpawn
	public static CoinSpawn CoinInstance;

	//get gameObject to be generated... could come from an instance or a data structure
/*	public CoinTransformer aCoin;
	public List<CoinTransformer> coinList = new List<CoinTransformer>();
	public List<CoinTransformer> coinPrefab = new List<CoinTransformer>();
	public Transform refpoint;
*/
	public GameObject aCoin;
	public List<GameObject> coinList = new List<GameObject>();

	public int numCoins = 3;

	//the X range for the object
	[Header ("X Spawn Range")]
	public float xMin;
	public float xMax;

	//the Y range for the object
	[Header ("Y Spawn Range")]
	public float yMin = -1f;
	public float yMax = 5.0f;

	//time for the object to appear if needed
	/**
	 * [Space(3)]
	 * public float waitForNextSpawn = 10;
	 * public float theCountDown =10;
	 * */

	void Awake(){
		CoinInstance = this;
	}

	// Use this for initialization
	void Start () {
//		CoinInstance = this;
	}
	
	// Update is called once per frame
	void Update () {
		//for the spawn time code section
		//Since I am going to try to tie this to LevelGenerator I will leave this blank for now
		//SpawnCoins(); spawns toooo many coins
	}

	public void SpawnCoins(Vector3 spawnPosition){
		yMin = spawnPosition.y + 1.5f;
		yMax = yMin + 10;
		xMin = spawnPosition.x;
		xMax = xMin + 18;

		GameObject tempCoin;
		//for loop creates n coins per platform. 
		//x can be defined by the programmer or by another mechanism like
		//int x = spawnPosition % n
		for (int i = 0; i < numCoins; i++) {
			//defines the min and max ranges for x and y
			Vector2 position = new Vector2 (Random.Range (xMin, xMax), Random.Range (yMin, yMax));
			//creates the aCoin at the random 2d position 
			tempCoin = (GameObject) Instantiate (aCoin, position, transform.rotation);
			tempCoin.transform.parent = gameObject.transform;
		}
	}
}
