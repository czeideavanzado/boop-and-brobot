using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour {

	public string mainMenuLevel;
	
	public void restartGame() {

        FindObjectOfType<GameManager>().Reset();
	}

	public void quitToMainMenu() {

		SceneManager.LoadScene(mainMenuLevel);


	}
}
