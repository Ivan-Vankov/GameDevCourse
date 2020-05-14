using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using static Controlls;
using static AudioManager;
using static JuiceUIManager;

public class PlayerMovement : MonoBehaviour {

    [SerializeField] private float speed = 30;
    private Animator animator;

    private Vector3 lastNonZeroMoveDirection = Vector3.zero;

    public static event Action OnPlayerMove;
    public static event Action OnPlayerDash;

    [SerializeField]
    [Range(0, 5)]
    private float recoilDuration = 0.3f;

    [SerializeField]
    [Range(0, 50)]
    private float recoilIntensity = 0.5f;

    [SerializeField] private AnimationCurve recoilCurve = null;

    private Vector3 recoilDirection = Vector3.zero;
    private float recoilStart = 0;
    private float recoilEnd = 0;

    private void Start() {
        animator = GetComponent<Animator>();
    }

    void Update() {
        Move();
        LookAtMouse();
        if (Input.GetKeyDown(dashKey)) { Dash(); }
    }

    private void Move() {
        transform.position += CalculateVelocity() * speed * Time.deltaTime;
        OnPlayerMove?.Invoke();
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
        OnPlayerDash?.Invoke();
    }

    private Vector3 CalculateVelocity() {
        Vector3 inputVelocity = new Vector3(Input.GetAxisRaw("Horizontal"),
                                          Input.GetAxisRaw("Vertical"),
                                          0).normalized;

        Vector3 recoilVelocity = Vector3.zero;
        if (Time.time < recoilEnd) {
            float normalizedTime = (Time.time - recoilStart) / recoilDuration;
            recoilVelocity = recoilDirection 
                * recoilIntensity 
                * Time.deltaTime
                * recoilCurve.Evaluate(normalizedTime);
        }

        return inputVelocity + recoilVelocity;
    }

    private void AddRecoil() {
        if (RecoilOn) {
            recoilDirection = -transform.right;
            recoilStart = Time.time;
            recoilEnd = recoilStart + recoilDuration;
        }
    }

    private void OnEnable() {
        PlayerGun.OnPlayerShoot += AddRecoil;
    }

    private void OnDisable() {
        PlayerGun.OnPlayerShoot -= AddRecoil;
    }
}
