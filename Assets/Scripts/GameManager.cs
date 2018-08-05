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
		playerStartPoint = playerController.transform.position;

		playerCamera = GameObject.Find("Player Camera");

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
		yield return new WaitForSeconds(0.5f);

		terrainList = FindObjectsOfType<TerrainDestroyer>();
		for (int i = 0; i < terrainList.Length; i++) {
			terrainList[i].gameObject.SetActive(false);
		}

		terrainGenerator.position = terrainStartPoint;
		playerController.transform.position = playerStartPoint;
		playerCamera.transform.position = playerStartPoint;

		scoreManager.distanceScore = 0; //Reset score to 0
		scoreManager.scoreIncreasing = true;

		yield return new WaitForSeconds(0.5f);
		playerCamera.SetActive(true);
		playerController.gameObject.SetActive(true);
		
		powerupManager.DeactivatePowerups();
	}
}
