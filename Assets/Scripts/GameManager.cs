using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public Transform terrainGenerator;
	private Vector3 terrainStartPoint;

	public PlayerController playerController;
	private Vector3 playerStartPoint;

	private TerrainDestroyer[] terrainList;

	private ScoreManager scoreManager;

	public PowerupManager powerupManager;

	private GameObject playerCamera;

	// Use this for initialization
	void Start () {
		terrainStartPoint = terrainGenerator.position;
		//playerStartPoint = playerController.transform.position;
		playerStartPoint = Camera.main.ViewportToWorldPoint(new Vector3(0.25f, 0.25f, 10f));
		playerController.transform.position = playerStartPoint;

		playerCamera = GameObject.Find("Player Camera");
		playerCamera.transform.position = playerStartPoint;

		scoreManager = FindObjectOfType<ScoreManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void RestartGame () {
		StartCoroutine("RestartGameCo");
	}

	public IEnumerator RestartGameCo () {
		scoreManager.scoreIncreasing = false;
		playerController.gameObject.SetActive(false);
		playerCamera.SetActive(false);

		/*
		Update total amount of coins the player has by adding the amount of coins collected in the game.
		Can be used for future features like Shop etc.
		*/
		if(PlayerPrefs.HasKey("Coins"))
			PlayerPrefs.SetInt("Coins",PlayerPrefs.GetInt("Coins")+scoreManager.coinsCollected);
		else
			PlayerPrefs.SetInt("Coins", scoreManager.coinsCollected);

		yield return new WaitForSeconds(0.5f);

		terrainList = FindObjectsOfType<TerrainDestroyer>();
		for (int i = 0; i < terrainList.Length; i++) {
			terrainList[i].gameObject.SetActive(false);
		}

		terrainGenerator.position = terrainStartPoint;
		playerController.transform.position = playerStartPoint;
		playerCamera.transform.position = playerStartPoint;

		scoreManager.distanceScore = 0; //Reset score to 0
		scoreManager.coinsCollected = 0; //Reset no. of coins collected to 0
		scoreManager.scoreIncreasing = true;

		yield return new WaitForSeconds(0.5f);
		playerCamera.SetActive(true);
		playerController.gameObject.SetActive(true);
		
		powerupManager.DeactivatePowerups();
	}
}
