using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Mathf;

[RequireComponent(typeof(Animator))]
public class DragonMovement : MonoBehaviour {

	public float moveSpeed = 2;
	public float gravity = 0.5f;
	private bool isJumping = false;
	private bool isFalling = false;
	private readonly float movementThreshold = 0.01f;
	private Vector2 velocity = Vector2.zero;

	private KeyCode jumpKey = KeyCode.W;

	private Animator animator;
	private new Rigidbody2D rigidbody;

	[Header("Height for falling to idle transition")]
	[Range(0, 1)]
	public float fallingThreshold = 0.8f;

	void Start() {
		animator = GetComponent<Animator>();
		rigidbody = GetComponent<Rigidbody2D>();
	}

	void Update() {
		velocity.x = Input.GetAxis("Horizontal");
		animator.SetFloat("NormalizedRunSpeed", Abs(velocity.x));

		if (Abs(velocity.x) > movementThreshold) {
			transform.localScale = new Vector3(-Sign(velocity.x), 1, 1);
		}

		if (isJumping && velocity.y < 0) {
			animator.SetBool("IsJumping", isJumping = false);
			animator.SetBool("IsFalling", isFalling = true);
		}

		if (!isJumping && !isFalling && Input.GetKeyDown(jumpKey)) {
			velocity.y = 1;
			animator.SetBool("IsJumping", isJumping = true);
		}

		rigidbody.MovePosition(rigidbody.position + velocity * moveSpeed * Time.deltaTime);

		if (isJumping || isFalling) {
			velocity.y -= gravity * Time.deltaTime;
		}

		if (isFalling && transform.position.y < fallingThreshold) {
			animator.SetBool("IsFalling", isFalling = false);
		}
	}

	private void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.CompareTag("Floor")) {
			velocity.y = 0;
		}
	}
}
