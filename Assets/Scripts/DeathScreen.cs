using System.Collections;
using UnityEngine;

public class DeathScreen : MonoBehaviour {

	public string mainMenuLevel;
	
	public void restartGame() {

        FindObjectOfType<GameManager>().Reset();
	}

	public void quitToMainMenu() {

		Application.LoadLevel(mainMenuLevel);


	}
}
