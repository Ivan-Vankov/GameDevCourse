using UnityEngine;

public class Movement : MonoBehaviour {

    // If we had just used Input.GetAxis("Vertical") 
    // then this class would not be testable
	public ICustomInput customInput { get; set; } = new CustomInput();

	void Update() {
		transform.position += Vector3.up * customInput.GetVerticalInput() * Time.deltaTime;
	}
}
