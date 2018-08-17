using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

	public static bool gameIsPaused = false;
	private bool canPause = true;

	public GameObject pauseMenuUI;

	public GameManager gameManager;

	public PlayerController playerController;
	// Update is called once per frame
	void Update () {

		if(playerController.isDead) canPause = false;
		else canPause = true;

		if(canPause)
		{
			if(Input.GetKeyDown(KeyCode.Escape))
			{
				if(gameIsPaused)
					Resume();
				else
					Pause();
			}
		}
		
	}

	void Pause()
	{
		pauseMenuUI.SetActive(true);
		Time.timeScale = 0f;
		gameIsPaused = true;
		gameManager.backgroundMusic.Pause();
	}

	public void Resume()
	{
		pauseMenuUI.SetActive(false);
		Time.timeScale = 1f;
		gameIsPaused = false;
		gameManager.backgroundMusic.Play();
	}

	public void RestartPauseMenu()
	{
		pauseMenuUI.SetActive(false);
		Time.timeScale = 1f;
		playerController.isDead = false;
	}
}
