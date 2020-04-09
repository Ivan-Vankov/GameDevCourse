using UnityEngine;

public class DieState : StateMachineBehaviour {
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		animator.SetBool("IsDying", true);
		animator.GetComponent<MovementController>().SetHorizontalMoveDirection(0);
	}
}
