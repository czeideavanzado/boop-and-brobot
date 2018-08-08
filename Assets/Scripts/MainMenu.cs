using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {
	public AudioSource backgroundMusic;

	public void Start()
	{
		backgroundMusic.Play();
	}
	public void QuitGame() {
		Application.Quit();
	}
}
