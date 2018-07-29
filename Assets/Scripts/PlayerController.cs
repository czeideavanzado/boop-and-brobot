using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	public float speedMultiplier;
	public float speedIncreaseMilestone;
	private float speedMilestoneCount;
	public float jumpForce;
	public float jumpTime;
	private float jumpTimeCounter;

	private Rigidbody2D rigidbody;

	public bool grounded;
	public LayerMask whatIsGround;
	public Transform groundChecker;
	public float groundCheckerRadius;

	// private Collider2D collider;

	private Animator animator;

	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody2D>();

		// collider = GetComponent<Collider2D>();

		animator = GetComponent<Animator>();

		jumpTimeCounter = jumpTime;

		speedMilestoneCount = speedIncreaseMilestone;
	}
	
	// Update is called once per frame
	void Update () {
		// grounded = Physics2D.IsTouchingLayers(collider, whatIsGround);

		grounded = Physics2D.OverlapCircle(groundChecker.position, groundCheckerRadius, whatIsGround);

		if(transform.position.x > speedMilestoneCount) {
			speedMilestoneCount += speedIncreaseMilestone;
			speedIncreaseMilestone *= speedMultiplier;
			moveSpeed *= speedMultiplier;
		}

		rigidbody.velocity = new Vector2(moveSpeed, rigidbody.velocity.y);

		if(Input.GetKeyDown(KeyCode.Space) && grounded) {
			rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpForce);
		}

		if(Input.GetKey(KeyCode.Space)) {
			if(jumpTimeCounter > 0) {
				rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpForce);
				jumpTimeCounter -= Time.deltaTime;
			}
		}

		if(Input.GetKeyUp(KeyCode.Space)) {
			jumpTimeCounter = 0;
		}

		if(grounded) {
			jumpTimeCounter = jumpTime;
		}

		animator.SetFloat ("Speed", rigidbody.velocity.x);
		animator.SetBool ("Grounded", grounded);
	}
}
