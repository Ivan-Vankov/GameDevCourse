using UnityEngine;
using static UnityEngine.Mathf;
using static StateMachineUtil;

public class AIRetreatState : StateMachineBehaviour {

	[SerializeField]
	[Range(0.1f, 3)]
	private float delay = 0.3f;

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		float moveDirection = -Sign(animator.transform.localScale.x);
		MovementController movementController = animator.GetComponent<MovementController>();
		movementController.SetHorizontalMoveDirection(moveDirection);

		DoWithDelay(delay, () => animator.SetBool("ShouldRetreat", false));
	}
}
