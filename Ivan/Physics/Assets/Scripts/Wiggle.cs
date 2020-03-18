using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wiggle : MonoBehaviour {

	[SerializeField]
	public Vector3 offset = new Vector3(-2, 0, 0);

	[SerializeField]
	[Range(0.1f, 2f)]
	public float speed = 1f;

	private float epsilon = 0.1f;

	private Vector3 destination;
	private Vector3 originalPosition;

	void Start() {
		originalPosition = transform.position;
		destination = originalPosition + offset;
		StartCoroutine(MoveAround());
	}

	IEnumerator MoveAround() {
		while (true) {
			Vector3 moveDirection = destination - transform.position;

			if (moveDirection.sqrMagnitude < epsilon) {
				Vector3 temp = originalPosition;
				originalPosition = destination;
				destination = temp;
				yield return new WaitForSeconds(0.1f);
				continue;
			}

			transform.position += moveDirection * speed * Time.deltaTime;
			yield return null;
		}
	}
}
