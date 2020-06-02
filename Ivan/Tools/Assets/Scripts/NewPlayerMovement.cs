using System.Collections;
using System.Collections.Generic;
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
        playerControlls.Player.Movement.canceled += context => StopMoving();
        playerControlls.Player.Jump.started += context => Jump();
    }

	private void OnEnable() => playerControlls.Enable();
	private void OnDisable() => playerControlls.Disable();

	public IEnumerator Move() {
        if (isMoving) {
            yield break;
        }

        isMoving = true;
        print("Starting the Move coroutine");
        while (isMoving) {
            Vector2 inputDirection = playerControlls.Player.Movement.ReadValue<Vector2>();

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
        }

        print("Ending the Move coroutine");
    }

    public void StopMoving() {
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
