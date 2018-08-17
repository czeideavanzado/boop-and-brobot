using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour {

	// Use this for initialization
	// void Start () {
		
	// }
	
	// // Update is called once per frame
	// void Update () {
		
	// }
	
	public string playGameLevel;

	public void PlayGame() {
		SceneManager.LoadScene(playGameLevel);
	}

	public void SelectCharacter(string characterName)
	{
		PlayerPrefs.SetString("CharacterSelected", characterName);
	}
}
