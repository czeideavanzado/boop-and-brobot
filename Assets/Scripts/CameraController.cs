using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public PlayerController playerController;
	private Rigidbody2D playerCamera;

	private Vector3 playerPosition;
	private float distance;

	// Use this for initialization
	void Start () {
		playerController = FindObjectOfType<PlayerController>();
		// playerPosition = playerController.transform.position;
		playerCamera = GameObject.Find("Player Camera").GetComponent<Rigidbody2D>();
		playerPosition = playerCamera.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		// distance = playerController.transform.position.x - playerPosition.x;
		playerCamera.velocity = new Vector2(playerController.moveSpeed, playerCamera.velocity.y);
		distance = playerCamera.transform.position.x - playerPosition.x;

		transform.position = new Vector3(transform.position.x + distance, transform.position.y, transform.position.z);

		// playerPosition = playerController.transform.position;
		playerPosition = playerCamera.transform.position;
	}
}
