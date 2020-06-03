using UnityEngine;
using UnityEngine.InputSystem;

public class LegacyPlayerMovvement : MonoBehaviour {

    private float speed = 5;

	void Update() {
		Move();
	}

	private void Move() {
        // If you just want to use regular keyboard input for debugging 
        Vector3 moveVector = Vector3.zero;
        if (Keyboard.current.wKey.isPressed) { moveVector += Vector3.forward; }
        if (Keyboard.current.sKey.isPressed) { moveVector -= Vector3.forward; }
        if (Keyboard.current.aKey.isPressed) { moveVector += Vector3.right; }
        if (Keyboard.current.dKey.isPressed) { moveVector -= Vector3.right; }

        transform.position += moveVector.normalized * speed * Time.deltaTime;
        
        // If you selected Edit/Project Settings/Player/Active Input handling
        // to Both then you can still use the old input system
        //transform.position += new Vector3(0, 0, speed * Input.GetAxis("Vertical") * Time.deltaTime);
    }
}
