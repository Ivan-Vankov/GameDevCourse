using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMover : MonoBehaviour {

	void Update() {
		Move();
	}

	private void Move() {
		if (Keyboard.current.wKey.isPressed) {
			transform.position += new Vector3(0, 0, 5 * Time.deltaTime);
		}
	}
}
