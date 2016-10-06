using UnityEngine;
using System.Collections;
//using System.Collections.Generic;

public class CoinSpawn : MonoBehaviour {

	//public static coinSpawn
	public static CoinSpawn CoinInstance;

	//get gameObject to be generated... could come from an instance or a data structure
	public GameObject aCoin;
//	public List<GameObject> coinList = new List<GameObject>();

	//the X range for the object
	[Header ("X Spawn Range")]
	public float xMin;
	public float xMax;

	//the Y range for the object
	[Header ("Y Spawn Range")]
	public float yMin = -2f;
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
	
	}
	
	// Update is called once per frame
	void Update () {
		//for the spawn time code section
		//Since I am going to try to tie this to LevelGenerator I will leave this blank for now
		//SpawnCoins(); spawns toooo many coins
	}

	public void SpawnCoins(Vector3 spawnPosition){
		yMin = spawnPosition.y;
		yMax = yMin + 10;
		xMin = spawnPosition.x;
		xMax = xMin + 18;

		//defines the min and max ranges for x and y
		Vector2 position = new Vector2(Random.Range (xMin,xMax), Random.Range(yMin, yMax));

		//if the object is taken from a data structure
//		GameObject thisCoin = coinList[Random.Range (0, coinList.Count)]; 

		//creates the random object at the random 2d position
		Instantiate (aCoin, position, transform.rotation);
	}
}
