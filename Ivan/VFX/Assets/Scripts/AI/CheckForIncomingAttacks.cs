using UnityEngine;

public class CheckForIncomingAttacks : MonoBehaviour {

	// Distance threshold from the player which will check for incoming attacks and crouch
	[SerializeField]
	private float distanceThreshold = 0.4f;

	// The chance that the bot will dodge a player punch
	[SerializeField]
	private float dodgeChance = 0.5f;

	private Animator animator;
	private Transform player;
	private Animator playerAnimator;

	void Start() {
		animator = GetComponent<Animator>();
		player = GameObject.FindWithTag("Player").transform;
		playerAnimator = player.GetComponent<Animator>();
	}
	
	void Update() {
		if (playerAnimator.GetBool("IsPunching")) {
			float random = Random.value;
			float distanceToPlayer = (player.position - transform.position).magnitude;
			
			if (random <= dodgeChance && distanceToPlayer < distanceThreshold) {
				animator.SetTrigger("ShouldCrouch");
			}
		}
	}
}
