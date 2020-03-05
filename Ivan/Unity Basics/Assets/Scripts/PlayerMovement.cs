using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	[SerializeField]
	private float speed = 3;

	[SerializeField]
	private BoxCollider boxCollider;

	private void Start() {
	}

	void Update() {
		Vector3 moveDirection =
				new Vector3(Input.GetAxis("Horizontal"),
							0,
							Input.GetAxis("Vertical"))
							.normalized
				* Time.deltaTime
				* speed;
		Vector3 pointToLookAt = transform.position
							  + moveDirection * 100;

		transform.position += moveDirection;
		transform.LookAt(pointToLookAt);
	}
}
