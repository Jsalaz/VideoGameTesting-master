using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public void getScene(){
		Scene currentScene = SceneManager.GetActiveScene ();
		Debug.Log (currentScene.name);
		Debug.Log (currentScene.buildIndex);
	}

	public void SceneLoader(){
		Scene currentScene = SceneManager.GetActiveScene ();
		Debug.Log (currentScene.name);
		Debug.Log (currentScene.buildIndex);

		if (GameManager.instance.collectedCoins < 15) {
			SceneManager.LoadScene ("Scene1");
			currentScene = SceneManager.GetActiveScene ();
			Debug.Log (currentScene.name);
			Debug.Log (currentScene.buildIndex);
	
		}
		else if (GameManager.instance.collectedCoins < 30) {
			SceneManager.LoadScene ("Scene2");
			currentScene = SceneManager.GetActiveScene ();
			Debug.Log (currentScene.name);
			Debug.Log (currentScene.buildIndex);

		}
			
	}
}
