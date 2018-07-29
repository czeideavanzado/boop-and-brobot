using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupManager : MonoBehaviour {

	private bool hasShield;
	private bool hasJetPack;
	private bool hasMagnet;
	private bool canFly;

	private bool isPowerupActive;
	private float powerupTimer;

	public PlayerController playerController;
	private GameObject shield;
	private GameObject jetpack;
	private GameObject magnet;
	private GameObject wings;

	// Use this for initialization
	void Start () {
		shield = playerController.transform.Find("Shield").gameObject; 
		jetpack = playerController.transform.Find("Jetpack").gameObject;
		// magnet = playerController.transform.Find("Magnet").gameObject;
		wings = playerController.transform.Find("Wings").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if(isPowerupActive) {
			powerupTimer -= Time.deltaTime;

			if(hasShield) {
				shield.SetActive(true);
			}

			if(hasJetPack) {
				jetpack.SetActive(true);
			}

			// if(hasMagnet) {
			// 	magnet.SetActive(true);
			// }

			if(canFly) {
				wings.SetActive(true);
			}

			if(powerupTimer <= 0) {
				isPowerupActive = false;

				shield.SetActive(false);
				jetpack.SetActive(false);
				// magnet.SetActive(false);
				wings.SetActive(false);
			}
		}
	}

	public void ActivatePowerup (bool shield, bool jetpack, bool magnet, bool fly, float time) {
		hasShield = shield;
		hasJetPack = jetpack;
		hasMagnet = magnet;
		canFly = fly;
		powerupTimer = time;

		isPowerupActive = true;
	}
}
