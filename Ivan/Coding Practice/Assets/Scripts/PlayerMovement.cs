using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMovement : MonoBehaviour {

    [SerializeField]
    [Range(0.5f, 3)]
    private float speed = 2;

    private NavMeshAgent agent;
    private RaycastHit hitInfo = new RaycastHit();

    private Vector3 forwardDirection = Vector3.forward;
    private Vector3 sidewaysDirection = Vector3.right;

    void Start() {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update() {
        //if (Input.GetMouseButton(0) && !Input.GetKey(KeyCode.LeftShift)) {
        //    var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    if (Physics.Raycast(ray, out hitInfo))
        //        agent.destination = hitInfo.point;
        //}

        //Vector3 destination = transform.position;
        //destination.z += Input.GetAxisRaw("Vertical") * speed;
        //destination.x += Input.GetAxis("Horizontal") * speed;
        agent.destination = transform.position 
            + (forwardDirection  * Input.GetAxisRaw("Vertical")
            + sidewaysDirection * Input.GetAxisRaw("Horizontal")).normalized;
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
