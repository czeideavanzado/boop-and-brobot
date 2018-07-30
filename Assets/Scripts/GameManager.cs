using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public Transform terrainGenerator;
	private Vector3 terrainStartPoint;

	public PlayerController playerController;
	private Vector3 playerStartPoint;

	private TerrainDestroyer[] terrainList;

	public PowerupManager powerupManager;

	// Use this for initialization
	void Start () {
		terrainStartPoint = terrainGenerator.position;
		playerStartPoint = playerController.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void RestartGame () {
		StartCoroutine("RestartGameCo");
	}

	public IEnumerator RestartGameCo () {
		playerController.gameObject.SetActive(false);
		yield return new WaitForSeconds(0.5f);

		terrainList = FindObjectsOfType<TerrainDestroyer>();
		for (int i = 0; i < terrainList.Length; i++) {
			terrainList[i].gameObject.SetActive(false);
		}

		terrainGenerator.position = terrainStartPoint;
		playerController.transform.position = playerStartPoint;
		playerController.gameObject.SetActive(true);
		powerupManager.DeactivatePowerups();
	}
}
