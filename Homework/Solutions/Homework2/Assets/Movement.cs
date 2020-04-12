using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	[SerializeField]
	[Range(1, 30)]
	private float speed = 10;

	[SerializeField]
	[Range(1, 30)]
	private float jumpForce = 10;

	private bool isJumping = false;
	private Vector3 direction;

	private new Rigidbody rigidbody;

	private void Start() {
		rigidbody = GetComponent<Rigidbody>();
	}

	void Update() {
		direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
		if (Input.GetKey("space")) {
			isJumping = true;
		}
		if (Input.GetKeyUp("space")) {
			isJumping = false;
		}
	}

	void FixedUpdate() {
		if (isJumping) {
			int mask = LayerMask.GetMask("Default");
			float rayLength = 0.7f;
			float sphereRadius = 0.2f;
			Vector3 origin = transform.position;
			Vector3 direction = new Vector3(0, -1, 0);
			if (Physics.SphereCast(origin,
								   sphereRadius,
								   direction,
								   out RaycastHit hit,
								   rayLength,
								   mask,
								   QueryTriggerInteraction.Collide)
				&& hit.collider.CompareTag("Ground")) {

				rigidbody.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
			}
		}
		rigidbody.AddForce(direction * speed * Time.fixedDeltaTime, ForceMode.Impulse);
	}
}
