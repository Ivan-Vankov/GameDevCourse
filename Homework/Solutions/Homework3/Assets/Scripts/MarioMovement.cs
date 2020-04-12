using UnityEngine;
using static UnityEngine.Mathf;

[RequireComponent(typeof(Animator))]
public class MarioMovement : MonoBehaviour {

	[SerializeField]
	[Range(0, 50)]
	private float moveSpeed = 10;

	[SerializeField]
	[Range(0.1f, 5)]
	public float jumpForce = 3.5f;

	private bool isCrouching = false;
	private bool isJumping = false;
	private readonly float movementThreshold = 0.01f;
	private float horizontalVelocity = 0;

	[SerializeField]
	private KeyCode jumpKey = KeyCode.W;

	[SerializeField]
	private KeyCode crouchKey = KeyCode.S;

	private Animator animator;
	private new Rigidbody2D rigidbody;
	private Transform graphics;

	void Start() {
		animator = GetComponent<Animator>();
		rigidbody = GetComponent<Rigidbody2D>();
		graphics = transform.GetChild(0);
	}

	void Update() {
		isCrouching = Input.GetKey(crouchKey);

		if (isJumping && rigidbody.velocity.y < 0) {
			animator.SetBool("IsJumping", false);
			animator.SetBool("IsFalling", true);
		}

		if (!isJumping) {
			animator.SetBool("IsCrouching", isCrouching);
			if (isCrouching) {
				return;
			}
		}

		horizontalVelocity = Input.GetAxisRaw("Horizontal");

		if (Abs(horizontalVelocity) > movementThreshold) {
			transform.localScale = new Vector3(Sign(horizontalVelocity), 1, 1);
		}

		if (!isJumping && Input.GetKeyDown(jumpKey)) {
			rigidbody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
			animator.SetBool("IsJumping", isJumping = true);
		}
	}

	private void FixedUpdate() {
		if (!isCrouching) {
			rigidbody.AddForce(new Vector2(horizontalVelocity, 0) * Time.fixedDeltaTime * moveSpeed,
							   ForceMode2D.Impulse);
			animator.SetFloat("HorizontalMovement", Abs(rigidbody.velocity.x));
		}
	}

	private void EndFall() {
		isJumping = false;
		animator.SetBool("IsJumping", false);
		animator.SetBool("IsFalling", false);
	}

	private void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.CompareTag("Floor")
			|| collision.gameObject.CompareTag("Obstacle")) {
			EndFall();
		}
	}

	private void OnTriggerEnter2D(Collider2D collision) {
		if (collision.gameObject.CompareTag("BoxTop")) {
			EndFall();
		}
	}
}
