﻿using UnityEngine;
using System.Collections;

public enum GameState {
	menu,
	inGame,
	endLevel,
	gameOver
}

public class GameManager : MonoBehaviour {

	public static GameManager instance;
	public GameState currentGameState = GameState.menu;

	public Canvas menuCanvas;
	public Canvas inGameCanvas;
	public Canvas gameOverCanvas;
	public Canvas endLevelCanvas;

	public int collectedCoins;

	void Awake() {
		instance = this;
	}

	void Start() {
//		StartGame ();
		currentGameState = GameState.menu;

		//added for scene change
	}
	
	//called to start the game
	public void StartGame() {
		PlayerController.instance.StartGame();
		LevelGenerator.instance.ResetSpawn ();//added to test
		SetGameState(GameState.inGame);
		collectedCoins = 0;
	}
	
	//called when player dies
	public void GameOver() {
		SetGameState(GameState.gameOver);
	}

	//called when player decide to go back to the menu
	public void BackToMenu() {
		SetGameState(GameState.menu);
	}

	void SetGameState (GameState newGameState) {
		
		if (newGameState == GameState.menu) {
			//setup Unity scene for menu state
			menuCanvas.enabled = true;
			inGameCanvas.enabled = false;
			gameOverCanvas.enabled = false;
			endLevelCanvas.enabled = false;
		} else if (newGameState == GameState.inGame) {
			//setup Unity scene for inGame state
			menuCanvas.enabled = false;
			inGameCanvas.enabled = true;
			gameOverCanvas.enabled = false;
			endLevelCanvas.enabled = false;
		} else if (newGameState == GameState.gameOver) {
			//setup Unity scene for gameOver state
			menuCanvas.enabled = false;
			inGameCanvas.enabled = false;
			gameOverCanvas.enabled = true;
			endLevelCanvas.enabled = false;
		} else if (newGameState == GameState.endLevel) {
			//set up for the end level canvas event
			menuCanvas.enabled = false;
			inGameCanvas.enabled = false;
			gameOverCanvas.enabled = false;
			endLevelCanvas.enabled = true;
		}

		currentGameState = newGameState;
	}


	public void Update() {

		if (Input.GetButtonDown("s")) {
			//LevelGenerator.instance.ResetSpawn ();//added to test
			StartGame();
		}
	}

	public void CollectedCoin(){
		collectedCoins++;
		if (collectedCoins >= 15) {
			PlayerController.instance.EndLevel ();
			SetGameState (GameState.endLevel);
		}
	}

}