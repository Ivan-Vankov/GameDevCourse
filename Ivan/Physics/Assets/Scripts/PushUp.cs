using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PushUp : MonoBehaviour {

	private Rigidbody body;

	private void Start() {
		body = GetComponent<Rigidbody>();
	}

	private void FixedUpdate() {
		body.AddForce(Vector3.up * 10 * Time.fixedDeltaTime);
		body.AddTorque(Vector3.up * 10 * Time.fixedDeltaTime);
	}
}
