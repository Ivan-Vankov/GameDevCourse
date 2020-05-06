using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Moves the player using the NavMeshAgent component 
/// in the forward direction of the camera.
/// </summary>
[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMovement : MonoBehaviour {

    [SerializeField]
    [Range(0.5f, 3)]
    private float speed = 1;

    private float initialSpeed;
    private float initialAngularSpeed;
    private float initialAccelaration;

    private NavMeshAgent agent;

    private Vector3 forwardDirection = Vector3.forward;
    private Vector3 sidewaysDirection = Vector3.right;

    void Start() {
        agent = GetComponent<NavMeshAgent>();

        initialSpeed = agent.speed;
        initialAngularSpeed = agent.angularSpeed;
        initialAccelaration = agent.acceleration;
    }

    void Update() {
        agent.speed = initialSpeed * speed;
        agent.angularSpeed = initialAngularSpeed * speed;
        agent.acceleration = initialAccelaration * speed;

        agent.destination = transform.position 
            + (forwardDirection  * Input.GetAxisRaw("Vertical")
            +  sidewaysDirection * Input.GetAxisRaw("Horizontal")).normalized;
    }

    private void OnEnable() {
        CameraFollow.OnLookDirectionChanged += Move;
    }

    private void OnDisable() {
        CameraFollow.OnLookDirectionChanged -= Move;
    }

    private void Move(Vector3 forwardDirection, Vector3 sidewaysDirection) {
        this.forwardDirection = forwardDirection;
        this.sidewaysDirection = sidewaysDirection;
    }
}
