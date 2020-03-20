using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float speed = 3f;

	private Vector3 movementVector;

	void Update() {
		movementVector = Vector3.zero;
		if (Input.GetKey(KeyCode.W)) { movementVector.y += 1; }
		if (Input.GetKey(KeyCode.A)) { movementVector.x -= 1; }
		if (Input.GetKey(KeyCode.S)) { movementVector.y -= 1; }
		if (Input.GetKey(KeyCode.D)) { movementVector.x += 1; }
		movementVector = movementVector.normalized * speed * Time.deltaTime;

		transform.position += movementVector;
	}
}