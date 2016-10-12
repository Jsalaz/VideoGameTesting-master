using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour {
	public static LevelManager levelInstance;

	public float totalDistance = 0;
	public int totalCoins = 0;

	void Awake(){
		levelInstance = this;
		DontDestroyOnLoad (transform.gameObject);
	}

//	void Start(){
//		SceneManager.LoadScene ("Scene1");
//	}

	public Scene getScene(){
		Scene currentScene = SceneManager.GetActiveScene ();
		return currentScene;
	}

	public void SetTotalDistance(float distance){
		if (getScene ().name == "Scene1" || GameState.endLevel == GameManager.instance.currentGameState) {
			totalDistance = distance;
		} else {
			totalDistance += distance;
		}
	}

	public float GetTotalDistance(){
		if (getScene ().name == "Scene1" && GameState.endLevel == GameManager.instance.currentGameState) {
			return PlayerController.instance.GetDistance ();
		} else if (getScene ().name == "Scene2" && GameState.endLevel == GameManager.instance.currentGameState) {
			return totalDistance + PlayerController.instance.GetDistance ();
		} else {
			return totalDistance + PlayerController.instance.GetDistance ();
		}
	}

	public void SetCoins(int coins){
		if (getScene ().name == "Scene1" || GameState.endLevel == GameManager.instance.currentGameState) {
			totalCoins = coins;
		} else {
			totalCoins += coins;
		}
	}

	public int GetCoins(){
		if (getScene ().name == "Scene1" && GameState.endLevel == GameManager.instance.currentGameState) {
			return PlayerController.instance.GetCoins ();
		} else if (getScene ().name == "Scene2" && GameState.endLevel == GameManager.instance.currentGameState) {
			return totalCoins + PlayerController.instance.GetCoins ();
		} else {
			return totalCoins + PlayerController.instance.GetCoins ();
		}

	}

	public void LevelComplete(float distance, int coins){
		//PlayerController.instance.EndLevel ();
		if (getScene ().name == "Scene1" || GameState.endLevel == GameManager.instance.currentGameState) {
			SetTotalDistance (distance);
			SetCoins (coins);
		}
		//SetCoins (coins);
	}

	public void LvlReset(){
		SetCoins (0);
		SetTotalDistance (0);
		//SceneManager.LoadScene ("Scene1");
	}

	public void SceneLoader(){
		if (SceneManager.GetActiveScene().name == "Scene1") {
		//	SceneManager.UnloadScene ("Scene1");
			//totalDistance = totalDistance + PlayerController.instance.GetDistance();
			SceneManager.LoadScene ("Scene2");
		}
			
	}
}