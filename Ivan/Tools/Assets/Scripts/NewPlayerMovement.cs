using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewPlayerMovement : MonoBehaviour {

	[SerializeField]
	[Range(0, 10)]
	private float speed = 5f;

    private bool isMoving = false;
    private bool isJumping = false;

    private Rigidbody body;
	private PlayerControlls playerControlls;

	private void Awake() {
        playerControlls = new PlayerControlls();
        body = GetComponent<Rigidbody>();

        playerControlls.Player.Movement.started += context => StartCoroutine(Move());
        playerControlls.Player.Jump.started += context => Jump();
    }

	private void OnEnable() => playerControlls.Enable();
	private void OnDisable() => playerControlls.Disable();

	public IEnumerator Move() {
        if (isMoving) {
            yield break;
        }

        isMoving = true;
        Vector2 inputDirection;
        print("Starting the Move coroutine");
        do {
            inputDirection = playerControlls.Player.Movement.ReadValue<Vector2>();

            //playerControlls.Player.Movement.PerformInteractiveRebinding()
            //        // To avoid accidental input from mouse motion
            //        .WithControlsExcluding("Mouse")
            //        .OnMatchWaitForAnother(0.1f)
            //        .Start();

            if (inputDirection == null) {
                Debug.LogError("Can't read Vector2 input from playerControlls.Player.Movement");
                yield break;
            }

            Vector3 movement = new Vector3 {
                x = inputDirection.x,
                y = 0,
                z = inputDirection.y
            } * speed * Time.deltaTime;

            body.MovePosition(body.position + movement);

            yield return null;
        } while (inputDirection.sqrMagnitude > 0);

        print("Ending the Move coroutine");
        isMoving = false;
    }

	public void Jump() {
        if (isJumping) {
            return;
        }

        isJumping = true;

        Vector3 upVector = Vector3.up * speed;

        body.AddForce(upVector, ForceMode.Impulse);
	}

    private void OnCollisionEnter(Collision collision) {
        isJumping = false;
    }
}
