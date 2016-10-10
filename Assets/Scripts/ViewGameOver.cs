using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ViewGameOver : MonoBehaviour {

	public Text coinLabel;
	public Text scoreLabel;

	void Update(){
		if(GameManager.instance.currentGameState == GameState.gameOver){
			coinLabel.text = LevelManager.levelInstance.GetCoins().ToString ();
			//PlayerController.instance.collectedCoins.ToString ();
			scoreLabel.text = LevelManager.levelInstance.GetTotalDistance().ToString ("f0");
			//PlayerController.instance.GetDistance ().ToString ("f0");
		}
	}

}
