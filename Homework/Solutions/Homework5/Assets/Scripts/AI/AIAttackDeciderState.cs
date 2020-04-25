using UnityEngine;

public class AIAttackDeciderState : StateMachineBehaviour {
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		float rand = Random.value;
		if      (rand <= 0.5f) { animator.SetTrigger("ShouldJump"); }
		else if (rand <= 1.0f) { animator.SetTrigger("ShouldMoveToPlayer"); }
	}
}
