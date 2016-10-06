using UnityEngine;
using System.Collections;

public class CoinGenerator : MonoBehaviour {

	//public static CoinGenerator instance;
	public float spawnTime = 1.5f;
	public Transform[] spawnPoints;

	//for testing 
	public int spawnpLength; //= spawnPoints.Length;
	public int spawnIndex;

	public GameObject Coins;
	//public GameObject[] Coins;
	//void Awake(){
	//	instance = this;
	//}


	// Use this for initialization
	void Start () {
		InvokeRepeating ("CoinSpawn", spawnTime, spawnTime); // repeats CoinSpawn method every 1.5 seconds
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void CoinSpawn(){
		spawnpLength = spawnPoints.Length;
		spawnIndex = Random.Range (0, spawnpLength);//spawnPoints.Length); // random place for the coing to spawn from our spawn points.
		Instantiate(Coins, spawnPoints[spawnIndex]);
	}
}
