using UnityEngine;

public class MushroomMovement : MonoBehaviour {

	[SerializeField]
	[Range(0.1f, 2)]
	private float speed = 2;
	private Vector3 direction;

	void Start() {
		direction = new Vector3(1, 0, 0);
	}
	
	void Update() {
		transform.Translate(direction * Time.deltaTime * speed);
	}

	private void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.CompareTag("Obstacle")) {
			direction *= -1;
		}
	}

}
