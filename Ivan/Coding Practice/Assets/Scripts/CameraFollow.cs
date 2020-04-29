using UnityEngine;
using System;

public class CameraFollow : MonoBehaviour {

    [SerializeField] private Transform toFollow;
    private Vector3 initialOffset;

    public static Action<Vector3, Vector3> OnLookDirectionChanged;

    public float sensitivityX = 15F;
    public float sensitivityY = 15F;

    public float minimumX = -360F;
    public float maximumX = 360F;

    public float minimumY = -60F;
    public float maximumY = 60F;

    public float moveSpeed = 1.0f;

    public bool lockHeight = false;

    float rotationY = 0F;

    private void Start() {
        initialOffset = transform.position - toFollow.position;
        Cursor.visible = false;
    }

    void Update() {
        float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;

        rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
        rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

        transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);

        //Vector3 lookDirection = new Vector3(Input.GetAxis("Mouse X"), 0, Input.GetAxis("Mouse Y")).normalized;

        Vector3 forwardVector = transform.TransformDirection(Vector3.forward);
        Vector3 sidewaysVector = transform.TransformDirection(Vector3.right);
        OnLookDirectionChanged?.Invoke(forwardVector, sidewaysVector);
        transform.position = toFollow.position + initialOffset;
        //if (lockHeight) {
        //    var dir = transform.TransformDirection(new Vector3(xAxisValue, 0.0f, zAxisValue) * moveSpeed);
        //    dir.y = 0.0f;
        //    transform.position += dir;
        //} else {
        //    transform.Translate(new Vector3(xAxisValue, 0.0f, zAxisValue) * moveSpeed);
        //}
    }
}
