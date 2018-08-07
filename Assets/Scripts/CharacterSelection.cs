using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelection : MonoBehaviour {

	// Use this for initialization
	// void Start () {
		
	// }
	
	// // Update is called once per frame
	// void Update () {
		
	// }
	
	public string playGameLevel;
	public string mainMenuLevel;

	public void PlayGame() {
		Application.LoadLevel(playGameLevel);
	}

	public void MainMenu() {
		Application.LoadLevel(mainMenuLevel);
	}
}
