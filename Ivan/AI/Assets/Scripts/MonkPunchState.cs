using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MonkPunchState : StateMachineBehaviour {
	
	public static event Action OnPunchExit;

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		OnPunchExit?.Invoke();
	}
}
