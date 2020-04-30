using UnityEngine;
using System;

public class CameraFollow : MonoBehaviour {

    [SerializeField] private Transform toFollow = null;
    private Vector3 initialOffset;

    public static Action<Vector3, Vector3> OnLookDirectionChanged;
    
    public float mouseSensitivity = 5;

    public float minimumY = -90;
    public float maximumY = 90;

    float rotationY = 0;

    private void Start() {
        initialOffset = transform.position - toFollow.position;
        // Hide the cursor while in Game View.
        Cursor.visible = false;
    }

    void Update() {
        float rotationX = transform.localEulerAngles.y 
            + Input.GetAxis("Mouse X") 
            * mouseSensitivity;

        rotationY += Input.GetAxis("Mouse Y") * mouseSensitivity;
        rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

        transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
        
        // Get the forward direction of the camera in world space
        Vector3 forwardVector  = transform.TransformDirection(Vector3.forward);
        // Get the right direction of the camera in world space
        Vector3 sidewaysVector = transform.TransformDirection(Vector3.right);
        transform.position = toFollow.position + initialOffset;

        OnLookDirectionChanged?.Invoke(forwardVector, sidewaysVector);
    }
}
