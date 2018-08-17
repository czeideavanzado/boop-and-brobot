using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {
	public AudioSource backgroundMusic;

	public void Start()
	{
		if(PlayerPrefs.HasKey("VolumeBG"))
			backgroundMusic.volume = PlayerPrefs.GetFloat("VolumeBG");
		
		backgroundMusic.Play();
	}
	public void QuitGame() {
		Application.Quit();
	}
}
