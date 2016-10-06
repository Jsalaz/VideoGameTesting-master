using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelGenerator : MonoBehaviour {

	public static LevelGenerator instance;
	//all level pieces blueprints used to copy from
	public List<LevelPiece> levelPrefabs = new List<LevelPiece>();
	//starting point of the very first level piece
	public Transform levelStartPoint;
	//all level pieces that are currently in the level
	public List<LevelPiece> pieces = new List<LevelPiece>();

	public LevelPiece piece;

	public Vector3 spawnPosition = Vector3.zero;//test added, moved from AddPiece

	void Awake() {
		instance = this;
	}

	void Start() {
//		GenerateInitialPieces();
		ResetSpawn();
	}

	public void GenerateInitialPieces() {
		for (int i=0; i<2; i++) {
			AddPiece();
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
	}
		
	public void RemoveOldestPiece() {
		
		LevelPiece oldestPiece = pieces[0];
		
		pieces.Remove(oldestPiece);
		Destroy(oldestPiece.gameObject);
	}
}