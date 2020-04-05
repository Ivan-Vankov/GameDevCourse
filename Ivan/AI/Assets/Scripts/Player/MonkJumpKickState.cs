using UnityEngine;

public class MonkJumpKickState : StateMachineBehaviour {

	private Animator animator;
	private MovementController movementController;
	
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		this.animator = animator;
		float kickDirection = Mathf.Sign(animator.transform.localScale.x);

		movementController = animator.GetComponent<MovementController>();
		movementController.SetHorizontalMoveDirection(kickDirection);
		movementController.OnJumpEnded += ResetAnimationState;
	}

	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		movementController.OnJumpEnded -= ResetAnimationState;
	}

	private void ResetAnimationState() {
		animator.SetBool("IsJumping", false);
		animator.SetBool("IsJumpKicking", false);
	}
}
