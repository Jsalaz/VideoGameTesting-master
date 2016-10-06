using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ViewInGame : MonoBehaviour {

	public Text coinLabel;
	public Text scoreLabel;
	public Text highscoreLabel;

	void Update(){
		if (GameManager.instance.currentGameState == GameState.inGame) {
			highscoreLabel.text = PlayerPrefs.GetFloat ("highscore", 0).ToString ("f0");
			scoreLabel.text = PlayerController.instance.GetDistance ().ToString ("f0");
			coinLabel.text = GameManager.instance.collectedCoins.ToString ();
		}
	}
}
