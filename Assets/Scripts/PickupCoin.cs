using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupCoin : MonoBehaviour {

	public int amountToGive;

	private ScoreManager scoreManager;
	
	// Use this for initialization
	void Start () {
		scoreManager = FindObjectOfType<ScoreManager>();
		
	}
	
	// Update is called once per frame
	void Update () 
	{

		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.name == "Player")
		{
			scoreManager.addCoin(amountToGive);
			gameObject.SetActive(false);
		}
	}
}
