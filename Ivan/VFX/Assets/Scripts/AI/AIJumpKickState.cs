using UnityEngine;
using static UnityEngine.Mathf;

public class AIJumpKickState : StateMachineBehaviour {

	private Animator animator;
	private MovementController movementController;
	private GameObject hitbox;

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		this.animator = animator;
		float kickDirection = Sign(animator.transform.localScale.x);
		hitbox = animator.transform.GetChild(0).gameObject;
		hitbox.SetActive(true);

		movementController = animator.GetComponent<MovementController>();
		movementController.SetHorizontalMoveDirection(kickDirection);
		movementController.OnJumpEnded += ResetAnimationState;
	}

	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		movementController.OnJumpEnded -= ResetAnimationState;
		hitbox.SetActive(false);
	}

	private void ResetAnimationState() {
		animator.SetTrigger("Landed");
	}
}
