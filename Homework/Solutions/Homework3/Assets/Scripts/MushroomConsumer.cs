using UnityEngine;

public class MushroomConsumer : MonoBehaviour {

	public RuntimeAnimatorController bigMarioController;
	public Collider2D smallMarioCollider;
	public Collider2D bigMarioCollider;
	private Animator animator;

	void Start() {
		animator = GetComponent<Animator>();
	}

	private void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.CompareTag("Mushroom")) {
			Destroy(collision.gameObject);
			animator.runtimeAnimatorController = bigMarioController;
			smallMarioCollider.enabled = false;
			bigMarioCollider.enabled = true;
		}
	}
}
