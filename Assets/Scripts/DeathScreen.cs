using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour {

	public string mainMenuLevel;
	public AudioSource deathScreenMusic;

	public void Start() {
		if(PlayerPrefs.HasKey("VolumeBG"))
			deathScreenMusic.volume = PlayerPrefs.GetFloat("VolumeBG");
		else
			deathScreenMusic.volume = 0.5f;
	}

	public void restartGame() {

        
				FindObjectOfType<GameManager>().backgroundMusic.Stop();
				FindObjectOfType<GameManager>().Reset();
	}

	public void quitToMainMenu() {
		SceneManager.LoadScene(mainMenuLevel);
	}
}
