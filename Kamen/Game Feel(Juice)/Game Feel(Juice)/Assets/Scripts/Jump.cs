using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    // tells us how high is the jump
    public CameraShake camera;
    public float intensity;
    Rigidbody rb;
    bool shouldJump;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Jump") > 0) {
            Debug.Log("Jump key pressed");
            if (Physics.SphereCast(transform.position, .1f, new Vector3(0, -1, 0), out RaycastHit hitInfo, .5f)){
                shouldJump = true;
                Debug.Log("ray");
            }
       }
    }
    private void FixedUpdate() {
        if (shouldJump) {
            rb.AddForce(new Vector3(0,1,0)*intensity);
            shouldJump = false;
        }
    }
    private void OnCollisionEnter(Collision collision) {
        StartCoroutine(camera.shake(0.5f,0.05f));
    }
}
