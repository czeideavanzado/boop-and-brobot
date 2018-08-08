using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {

	public string nextLevel;

	void Update() {
		if(Input.GetKeyDown("space")) {
			Application.LoadLevel(nextLevel);
		}
	}
}
