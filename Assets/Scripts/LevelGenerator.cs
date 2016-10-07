using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelGenerator : MonoBehaviour {
	//static levelGenerator
	public static LevelGenerator instance;
	//all level pieces blueprints used to copy from
	public List<LevelPiece> levelPrefabs = new List<LevelPiece>();
	//starting point of the very first level piece
	public Transform levelStartPoint;
	//all level pieces that are currently in the level
	public List<LevelPiece> pieces = new List<LevelPiece>();
	// piece holder for testing, should hold the next piece to instantiate after the trigger is hit
	public LevelPiece piece;
	//test added, moved from AddPiece. used to track the next level spawn possition
	public Vector3 spawnPosition = Vector3.zero;

	/// <summary>
	/// Testing code to spawn coins
	/// </summary>
	 
	//public CoinSpawn levelCoins = new CoinSpawn(); 


	void Awake() {
		instance = this;
	}

	void Start() {
//		GenerateInitialPieces();
		ResetSpawn();
		//levelCoins.SpawnCoins ();
	}

	public void GenerateInitialPieces() {
		for (int i=0; i<2; i++) {
			AddPiece();
			//makes two coins per level at random location  
			//!!! Yay Works but need to move it to a better location
			//CoinSpawn.CoinInstance.SpawnCoins (spawnPosition);
		}
	}

	//test add to reset starting possition
	public void ResetSpawn(){
		foreach (LevelPiece old in pieces) {
			Destroy (old.gameObject);
		}
		spawnPosition = levelStartPoint.position;
		pieces.Clear ();
		GenerateInitialPieces ();
	}


	public void AddPiece() {

		//pick the random number  (0, levelPrefabs.Count-1);
		int randomIndex = Random.Range(0, levelPrefabs.Count);

		//Instantiate copy of random level prefab and store it in piece variable
		piece = (LevelPiece)Instantiate(levelPrefabs[randomIndex]);

//		LevelPiece piece = (LevelPiece)Instantiate(levelPrefabs[randomIndex]);
		piece.transform.SetParent(this.transform, false);

//		Vector3 spawnPosition = Vector3.zero;

		//position
		if (pieces.Count == 0) {
			//first piece
			spawnPosition = levelStartPoint.position;
		}
		else {
			//take exit point from last piece as a spawn point to new piece
			spawnPosition = pieces[pieces.Count-1].exitPoint.position;
		}
		
		piece.transform.position = spawnPosition;
		pieces.Add(piece);
		//CoinSpawn.CoinInstance.SpawnCoins (spawnPosition);
	}
		
	public void RemoveOldestPiece() {
		LevelPiece oldestPiece = pieces[0];
		pieces.Remove(oldestPiece);
		Destroy(oldestPiece.gameObject);
		CoinSpawn.CoinInstance.SpawnCoins (spawnPosition);
	}
}