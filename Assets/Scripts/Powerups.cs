using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerups : MonoBehaviour {

	public bool hasShield;
	public bool hasJetPack;
	public bool hasMagnet;
	public bool canFly;

	public float powerupLength;

	private PowerupManager powerupManager;

	// Use this for initialization
	void Start () {
		powerupManager = FindObjectOfType<PowerupManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/// <summary>
	/// Sent when another object enters a trigger collider attached to this
	/// object (2D physics only).
	/// </summary>
	/// <param name="other">The other Collider2D involved in this collision.</param>
	void OnTriggerEnter2D(Collider2D other) {
			if(other.name == "Player" ) {
				powerupManager.ActivatePowerup (hasShield, hasJetPack, hasMagnet, canFly, powerupLength);
				gameObject.SetActive(false);
			}

			else if(other.gameObject.name == "Magnet")
			{
				Physics2D.IgnoreCollision(other.GetComponent<Collider2D>(), GetComponent<Collider2D>());
			}

			
	}
}
