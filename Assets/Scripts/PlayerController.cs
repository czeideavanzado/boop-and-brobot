using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	private float moveSpeedStorage;

	public float speedMultiplier;
	public float speedIncreaseMilestone;
	private float speedIncreaseMilestoneStorage;
	private float speedMilestoneCount;
	private float speedMilestoneCountStorage;

	public float jumpForce;
	public float jumpTime;
	private float jumpTimeCounter;
	private bool jumpedFromGround;

	public bool canFly;
	public bool hasJetPack;

	private Rigidbody2D rigidbody;

	public bool grounded;
	public LayerMask groundLayer;

	public Transform groundChecker;
	public float groundCheckerRadius;

	// private Collider2D collider;

	private Animator animator;

	public GameManager gameManager;

	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody2D>();
		// collider = GetComponent<Collider2D>();
		animator = GetComponent<Animator>();

		moveSpeedStorage = moveSpeed;
		jumpTimeCounter = jumpTime;

		speedIncreaseMilestoneStorage = speedIncreaseMilestone;
		speedMilestoneCount = speedIncreaseMilestone;
		speedMilestoneCountStorage = speedMilestoneCount;
	}
	
	// Update is called once per frame
	void Update () {
		// grounded = Physics2D.IsTouchingLayers(collider, groundLayer);

		if (canFly) {
			grounded = false;
		} else {
			grounded = Physics2D.OverlapCircle(groundChecker.position, groundCheckerRadius, groundLayer);
		}

		if(hasJetPack) {
			rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpForce);
		}

		if(transform.position.x > speedMilestoneCount) {
			speedMilestoneCount += speedIncreaseMilestone;
			speedIncreaseMilestone *= speedMultiplier;
			moveSpeed *= speedMultiplier;
		}

		rigidbody.velocity = new Vector2(moveSpeed, rigidbody.velocity.y);

		if(Input.GetKeyDown(KeyCode.Space) && grounded) {
			rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpForce);
			jumpedFromGround = true;
		} else if (Input.GetKey(KeyCode.Space) && canFly) {
			rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpForce);
		}

		if(Input.GetKey(KeyCode.Space) && jumpTimeCounter > 0 && jumpedFromGround) {
				rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpForce);
				jumpTimeCounter -= Time.deltaTime;
		}

		if(Input.GetKeyUp(KeyCode.Space)) {
			jumpTimeCounter = 0;
			jumpedFromGround = false;
		}

		if(grounded) {
			jumpTimeCounter = jumpTime;
		}

		animator.SetFloat ("Speed", rigidbody.velocity.x);
		animator.SetBool ("Grounded", grounded);
	}

	void OnCollisionEnter2D (Collision2D other) {
		if(other.gameObject.tag == "Death Box") {
			gameManager.RestartGame();
			moveSpeed = moveSpeedStorage;
			speedIncreaseMilestone = speedIncreaseMilestoneStorage;
			speedMilestoneCount = speedMilestoneCountStorage;
		}
	}
}
