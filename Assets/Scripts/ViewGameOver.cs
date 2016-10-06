using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ViewGameOver : MonoBehaviour {

	public Text coinLabel;
	public Text scoreLabel;

	void Update(){
		if(GameManager.instance.currentGameState == GameState.gameOver){
			coinLabel.text = GameManager.instance.collectedCoins.ToString ();
			scoreLabel.text = PlayerController.instance.GetDistance ().ToString ("f0");
		}
	}

}
