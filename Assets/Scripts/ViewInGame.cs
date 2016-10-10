using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ViewInGame : MonoBehaviour {

	public Text coinLabel;
	public Text scoreLabel;
	public Text highscoreLabel;

	public float trueDistance;
	public int trueCoins;

	void Update(){
		if (GameManager.instance.currentGameState == GameState.inGame) {
		//distance
			//trueDistance = PlayerController.instance.GetDistance () + LevelManager.levelInstance.GetTotalDistance ();
			scoreLabel.text = LevelManager.levelInstance.GetTotalDistance ().ToString ("f0");
			//scoreLabel.text = PlayerController.instance.GetDistance ().ToString ("f0");
		//coins
			//trueCoins = PlayerController.instance.GetCoins() + LevelManager.levelInstance.GetCoins();
			coinLabel.text = LevelManager.levelInstance.GetCoins().ToString ();
			highscoreLabel.text = PlayerPrefs.GetFloat ("highscore", 0).ToString ("f0");
		}
	}
}
