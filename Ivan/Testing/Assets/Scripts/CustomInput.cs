using UnityEngine;

public class CustomInput : ICustomInput {
	public float GetVerticalInput() {
		return Input.GetAxisRaw("Vertical");
	}
}
