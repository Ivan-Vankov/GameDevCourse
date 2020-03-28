using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAbove : MonoBehaviour {

	private void Start() {
		Physics2D.queriesStartInColliders = false;
	}

	void Update() {
		RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up);

		if (hit.collider == null) {
			Debug.DrawRay(transform.position, Vector2.up, Color.green);
		}
		else {
			Debug.DrawLine(transform.position, hit.point, Color.red);
			print("Beware of the " + hit.transform.name + " above!");
		}
	}

}
