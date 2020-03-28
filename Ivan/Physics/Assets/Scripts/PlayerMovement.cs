using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	[SerializeField]
	private float speed = 3;

	void Update() {
		Vector3 moveDirection =
				new Vector3(-Input.GetAxis("Vertical"),
							+0,
							+Input.GetAxis("Horizontal"))
							.normalized
				* Time.deltaTime
				* speed;
		Vector3 pointToLookAt = transform.position
							  + moveDirection * 100;

		transform.position += moveDirection;
		transform.LookAt(pointToLookAt);
	}
}
