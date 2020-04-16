using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public SceneAsset initialScene;
	public SceneAsset mainMenuScene;

	public void LoadGame() {
		SceneManager.LoadScene(initialScene.name);
	}

	public void LoadMainMenu() {
		SceneManager.LoadScene(mainMenuScene.name);
	}

	public void EndGame() {
		Application.Quit();
	}
}
