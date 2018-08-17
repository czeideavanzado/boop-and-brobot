using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public Text distanceScoreText;
	public Text distanceHighScoreText;
	public Text coinsCollectedText;

	public float distanceScore;

	public float distanceHighScore;

	public int coinsCollected;

	
	public float distancePerSecond; //The amount of distance gained per second while the player is alive.

	public bool scoreIncreasing;//is false when the player is dead.

	// Use this for initialization
	void Start () {
		distanceScore = 0;
		distanceHighScore = 0;
		coinsCollected = 0;
		scoreIncreasing = true;

		//If a highscore was saved before.
		if(PlayerPrefs.HasKey("DistanceHighScore"))
		{
			//Retrieve the highscore
			distanceHighScore = PlayerPrefs.GetFloat("DistanceHighScore");
		}
		
	}
	
	// Update is called once per frame
	void Update () {

		if(scoreIncreasing)
		{
			//Increase distance score over time
			distanceScore += (distancePerSecond * Time.deltaTime);
		}

		//If current score is greater than highscore
		if(distanceScore > distanceHighScore)
		{
			//Update the highscore to the current score
			distanceHighScore = distanceScore;

			//Save the highscore
			PlayerPrefs.SetFloat("DistanceHighScore", distanceHighScore);
		}

		//Update the distance score text
		distanceScoreText.text = Mathf.RoundToInt(distanceScore) + "m";

		//Update distance highscore text
		distanceHighScoreText.text = Mathf.RoundToInt(distanceHighScore) + "m";

		coinsCollectedText.text = coinsCollected+"";
	}

	public void addCoin(int amount)
	{
		coinsCollected+=amount;
	}
}
