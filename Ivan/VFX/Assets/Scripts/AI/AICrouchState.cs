using UnityEngine;

public class AICrouchState : StateMachineBehaviour {
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		MovementController movementController = animator.GetComponent<MovementController>();
		movementController.SetHorizontalMoveDirection(0);
		animator.SetTrigger("ShouldAttack");
	}
}
