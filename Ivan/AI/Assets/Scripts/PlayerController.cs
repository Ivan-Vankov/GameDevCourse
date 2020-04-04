using UnityEngine;
using static UnityEngine.Mathf;

[RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour {

	[SerializeField]
	[Range(0, 5)]
	private float moveSpeed = 2;

	[SerializeField]
	[Range(1, 5)]
	public float gravity = 4f;
	
	private bool isAirborne = false;
	private bool isAttacking = false;
	private readonly float movementThreshold = 0.01f;

	[SerializeField]
	[Range(1, 5)]
	private float jumpVelocity = 2;
	private Vector2 velocity = Vector2.zero;

	[SerializeField]
	private KeyCode jumpKey = KeyCode.W;
	[SerializeField]
	private KeyCode punchKey = KeyCode.E;

	private Animator animator;
	private new Rigidbody2D rigidbody;

	void Start() {
		animator = GetComponent<Animator>();
		rigidbody = GetComponent<Rigidbody2D>();
	}

	void OnEnable() {
		MonkPunchState.OnPunchExit += SetIsNotAttacking;
	}

	void OnDisable() {
		MonkPunchState.OnPunchExit -= SetIsNotAttacking;
	}

	void SetIsNotAttacking() {
		isAttacking = false;
	}

	void Update() {
		if (!isAirborne && Input.GetKeyDown(punchKey)) {
			animator.SetTrigger("IsPunching");
			isAttacking = true;
		}

		if (isAttacking) {
			return;
		}

		velocity.x = Input.GetAxisRaw("Horizontal");
		animator.SetFloat("NormalizedSpeed", Abs(velocity.x));

		if (Abs(velocity.x) > movementThreshold) {
			transform.localScale = new Vector3(Sign(velocity.x), 1, 1);
		}

		if (!isAirborne && Input.GetKeyDown(jumpKey)) {
			velocity.y = jumpVelocity;
			animator.SetBool("IsJumping", isAirborne = true);
		}

		if (velocity.y < 0) {
			animator.SetBool("IsJumping", false);
			animator.SetBool("IsFalling", true);
		}

		rigidbody.MovePosition(rigidbody.position + velocity * moveSpeed * Time.deltaTime);

		if (isAirborne) {
			velocity.y -= gravity * Time.deltaTime;
		}
	}

	private void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.CompareTag("Ground")) {
			isAirborne = false;
			animator.SetBool("IsJumping", false);
			animator.SetBool("IsFalling", false);
			velocity.y = 0;
		}
	}
}
