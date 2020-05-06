using UnityEngine;
using System;
using static UnityEngine.Mathf;

public class MovementController : MonoBehaviour {

	[SerializeField]
	[Range(0, 5)]
	private float horizontalMoveSpeed = 2;

	[SerializeField]
	[Range(1, 5)]
	public float gravity = 5f;

	public bool IsAirborne { get; set; } = false;
	private readonly float movementThreshold = 0.01f;

	[SerializeField]
	[Range(1, 5)]
	private float jumpVelocity = 2.3f;

	private Vector2 velocity = Vector2.zero;
	public Vector2 Velocity { get => velocity; }

	private new Rigidbody2D rigidbody;

	public event Action OnJumpEnded;

	void Start() {
		rigidbody = GetComponent<Rigidbody2D>();
	}

	void Update() {
		ResolveLookDirection();
		Move();
		if (IsAirborne) {
			Fall();
		}
	}

	private void Move() {
		Vector2 newPosition = new Vector2 {
			x = velocity.x * horizontalMoveSpeed,
			y = velocity.y
		} * Time.deltaTime + rigidbody.position;
		rigidbody.MovePosition(newPosition);
	}

	private void Fall() {
		velocity.y -= gravity * Time.deltaTime;
	}

	public void SetHorizontalMoveDirection(float amount) {
		velocity.x = amount;
	}

	public void Jump() {
		velocity.y = jumpVelocity;
		IsAirborne = true;
	}

	private void ResolveLookDirection() {
		if (Abs(velocity.x) > movementThreshold) {
			transform.localScale = new Vector3(Sign(velocity.x), 1, 1);
		}
	}

	public void TurnTowards(float direction) {
		transform.localScale = new Vector3(Sign(direction), 1, 1);
	}

	private void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.CompareTag("Ground")) {
			IsAirborne = false;
			OnJumpEnded?.Invoke();
			velocity.y = 0;
		}
	}
}