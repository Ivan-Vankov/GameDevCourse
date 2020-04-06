using UnityEngine;

public class AIDeciderState : StateMachineBehaviour {
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		float rand = Random.value;
		if      (rand <= 0.2f) { animator.SetBool("ShouldRetreat", true); }
		else if (rand <= 0.4f) { animator.SetTrigger("ShouldWait"); }
		else if (rand <= 1.0f) { animator.SetTrigger("ShouldAttack"); }
	}
}
