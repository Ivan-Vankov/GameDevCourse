using UnityEngine;
using static UnityEngine.Mathf;

public class AIMoveToPlayerState : StateMachineBehaviour {

	[SerializeField]
	[Range(0.1f, 0.4f)]
	private float wantedDistanceToPlayer = 0.2f;

	private Transform player;
	private MovementController movementController;

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		GameObject playerGameObject = GameObject.FindWithTag("Player");
		if (playerGameObject == null) {
			Debug.LogError("No GameObject with the \"Player\" tag found");
		} else {
			player = playerGameObject.transform;
		}

		movementController = animator.GetComponent<MovementController>();
	}

	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

		Vector3 vectorToPlayer = player.position - animator.transform.position;
		float distanceToPlayer = vectorToPlayer.magnitude;
		float moveDirection = Sign(vectorToPlayer.x);

		if (distanceToPlayer > wantedDistanceToPlayer) {
			movementController.SetHorizontalMoveDirection(moveDirection);
		} else {
            float random = Random.value;
            if (random <= 0.5f) {
                animator.SetTrigger("ShouldCrouch");
            } else {
			    animator.SetTrigger("ShouldPunch");
            }
		}
	}
}
