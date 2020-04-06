using UnityEngine;

public class AIJumpState : StateMachineBehaviour {

	private MovementController movementController;

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		movementController = animator.GetComponent<MovementController>();
		movementController.SetHorizontalMoveDirection(0);
		movementController.Jump();

		Transform player = GameObject.FindWithTag("Player").transform;
		float directionToPlayer = player.position.x - animator.transform.position.x;
		movementController.TurnTowards(directionToPlayer);
	}

	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		if (movementController.Velocity.y < 0) {
			animator.SetTrigger("ShouldJumpKick");
		}
	}
}
