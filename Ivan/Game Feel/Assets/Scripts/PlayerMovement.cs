using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Controlls;
using static AudioManager;

public class PlayerMovement : MonoBehaviour {

    [SerializeField] private float speed = 30;
    private Animator animator;

    private Vector3 lastNonZeroMoveDirection = Vector3.zero;

    private void Start() {
        animator = GetComponent<Animator>();
    }

    void Update() {
        Move();
        LookAtMouse();
        if (Input.GetKeyDown(dashKey)) { Dash(); }
    }

    private void Move() {
        transform.position += new Vector3(Input.GetAxisRaw("Horizontal"),
                                          Input.GetAxisRaw("Vertical"),
                                          0).normalized
                                          * speed * Time.deltaTime;
    }

    private void LookAtMouse() {
        Vector3 screenMousePosition = new Vector3(Input.mousePosition.x,
                                                  Input.mousePosition.y,
                                                  -Camera.main.transform.position.z);
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(screenMousePosition);
        mousePosition.z = 0;

        Vector3 vectorToMouse = (mousePosition - transform.position).normalized;
        transform.right = vectorToMouse;
    }

    private void Dash() {
        animator.SetTrigger("IsDashing");
        PlayDashSound();
    }
}
