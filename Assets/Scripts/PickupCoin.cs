using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupCoin : MonoBehaviour {

	public int amountToGive;

	private AudioSource coinSound;

	private ScoreManager scoreManager;
	
	// Use this for initialization
	void Start () {
		scoreManager = FindObjectOfType<ScoreManager>();

		//Get audio source called CoinSound in the Hierarchy
		coinSound = GameObject.Find("CoinSound").GetComponent<AudioSource>(); 
		
	}
	

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "Player")
		{
			scoreManager.addCoin(amountToGive);
			gameObject.SetActive(false);

			if(coinSound.isPlaying)
			{
				coinSound.Stop();
				coinSound.Play();
			}
			else
			{
				coinSound.Play();
			}
				
		}
	}
}
