using UnityEngine;

public class Spawner : MonoBehaviour {
	public GameObject mushroom;
	public Sprite emptyBlockSprite;

	private bool hasSpawned = false;
	private SpriteRenderer spriteRenderer;

	void Start() {
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	private void OnTriggerEnter2D(Collider2D collision) {
		if (collision.gameObject.CompareTag("Player") && !hasSpawned) {
			hasSpawned = true;
			Instantiate(mushroom);
			spriteRenderer.sprite = emptyBlockSprite;
		}
	}
}
