using UnityEngine;
using static Controlls;
using static StateMachineUtil;

public class MonkFallState : StateMachineBehaviour {

	private Animator animator;
	private MovementController movementController;

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		this.animator = animator;
		movementController = animator.GetComponent<MovementController>();
		movementController.OnJumpEnded += ResetAnimationState;
	}
	
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		DoMove(animator, movementController);

		if (Input.GetKeyDown(attackKey)) {
			animator.SetBool("IsJumpKicking", true);
		}
	}

	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		movementController.OnJumpEnded -= ResetAnimationState;
	}

	private void ResetAnimationState() {
		animator.SetBool("IsFalling", false);
	}
}
