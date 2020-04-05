using UnityEngine;
using static Controlls;

public static class StateMachineUtil {
	public static void DoMove(Animator animator, MovementController movementController) {
		float horizontalMoveDirection = Input.GetAxisRaw(HorizontalMovementAxis);
		movementController.SetHorizontalMoveDirection(horizontalMoveDirection);
		animator.SetFloat("NormalizedSpeed", horizontalMoveDirection);
	}
}
