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

		if (distanceToPlayer > wantedDistanceToPlayer) {
			movementController.SetHorizontalMoveDirection(Sign(vectorToPlayer.x));
		} else {
			animator.SetBool("ShouldPunch", true);
		}
	}
}
