using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupCoin : MonoBehaviour {

	public int amountToGive;

	private AudioSource coinSound;

	private ScoreManager scoreManager;

	private bool moveToMagnet;

	private PowerupManager powerupManager;
	private GameObject player;

	private Vector2 playerDirection;

	private float timeStamp;

	private Rigidbody2D rb;

	public float moveSpeed;
	
	// Use this for initialization
	void Start () {
		scoreManager = FindObjectOfType<ScoreManager>();
		powerupManager = FindObjectOfType<PowerupManager>();

		//Get audio source called CoinSound in the Hierarchy
		coinSound = GameObject.Find("CoinSound").GetComponent<AudioSource>(); 

		rb = GetComponent<Rigidbody2D>();

		moveToMagnet = false;

		
		
	}

	void Update()
	{
		if(moveToMagnet)
		{
			playerDirection = -(transform.position - player.transform.position).normalized;
			rb.velocity = new Vector2(playerDirection.x, playerDirection.y) * moveSpeed * (Time.time/timeStamp);
		}
	}
	

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.name == "Player")
		{
			scoreManager.addCoin(amountToGive);
			gameObject.SetActive(false);
			moveToMagnet = false;

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
		if(other.gameObject.name == "Magnet" && powerupManager.GetHasMagnet())
		{
			timeStamp = Time.time;
			player = GameObject.FindGameObjectWithTag("Player");
			moveToMagnet = true;
		}
	}
}
