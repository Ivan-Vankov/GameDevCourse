using UnityEngine;
using static Controlls;
using static StateMachineUtil;

public class MonkJumpState : StateMachineBehaviour {
	
	private MovementController movementController;

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		movementController = animator.GetComponent<MovementController>();
		movementController.Jump();
	}

	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		DoMove(animator, movementController);

		if (movementController.Velocity.y < 0) {
			animator.SetBool("IsJumping", false);
			animator.SetBool("IsFalling", true);
		}

		if (Input.GetKeyDown(attackKey)) {
			animator.SetBool("IsJumpKicking", true);
		}
	}
}
