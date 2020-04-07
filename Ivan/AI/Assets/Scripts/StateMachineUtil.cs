using UnityEngine;
using System;
using System.Collections;
using static Controlls;
using static UnityEngine.Mathf;

public class StateMachineUtil : MonoBehaviour {

	private static StateMachineUtil instance;

	private void Start() {
		instance = this;
	}

	public static void DoMove(Animator animator, MovementController movementController) {
		float horizontalMoveDirection = Input.GetAxisRaw(HorizontalMovementAxis);
		movementController.SetHorizontalMoveDirection(horizontalMoveDirection);
		animator.SetFloat("NormalizedSpeed", Abs(horizontalMoveDirection));
	}

	public static void DoWithDelay(float delayInSeconds, Action action) {
		instance.DoWithDelayUtil(delayInSeconds, action);
	}

	private void DoWithDelayUtil(float delayInSeconds, Action action) {
		StartCoroutine(DoWithDelayCoroutine(delayInSeconds, action));
	}

	private IEnumerator DoWithDelayCoroutine(float delayInSeconds, Action action) {
		yield return new WaitForSeconds(delayInSeconds);
		action();
	}
}
