using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	public float jumpForce;

	private Rigidbody2D rigidbody;

	public bool grounded;
	public LayerMask whatIsGround;

	private Collider2D collider;

	private Animator animator;

	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody2D>();

		collider = GetComponent<Collider2D>();

		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		grounded = Physics2D.IsTouchingLayers(collider, whatIsGround);

		rigidbody.velocity = new Vector2(moveSpeed, rigidbody.velocity.y);

		if(Input.GetKeyDown(KeyCode.Space) && grounded) {
			rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpForce);
		}

		if (Input.GetKeyUp(KeyCode.Space) && !grounded) {
			rigidbody.velocity = new Vector2(rigidbody.velocity.x, -(jumpForce/5));
		}

		animator.SetFloat ("Speed", rigidbody.velocity.x);
		animator.SetBool ("Grounded", grounded);
	}
}
