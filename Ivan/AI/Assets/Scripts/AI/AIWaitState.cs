using UnityEngine;

public class AIWaitState : StateMachineBehaviour {

	private MovementController movementController;
	private Transform player;

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		movementController = animator.GetComponent<MovementController>();
		movementController.SetHorizontalMoveDirection(0);
		player = GameObject.FindWithTag("Player").transform;
	}
	
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		float directionToPlayer = player.position.x - animator.transform.position.x;
		movementController.TurnTowards(directionToPlayer);
	}
}
