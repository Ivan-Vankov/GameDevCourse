using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    float force;
    bool isJumping;
    Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        isJumping = false;
    }

    // Update is called once per frame
    void Update()
    {
        direction = new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"));
        if (Input.GetKey("space"))
        {
            //Debug.Log("space pressed");
            isJumping = true;
        }
        if (Input.GetKeyUp("space"))
        {
            //Debug.Log("space not pressed");
            isJumping = false;
        }
    }
    void FixedUpdate()
    {
        if (isJumping)
        {
            int mask = LayerMask.GetMask("Default");
            float rayLength = 0.7f;
            float sphereRadius = 0.2f;
            Vector3 origin = transform.position;
            Vector3 direction = new Vector3(0,-1,0);
            if (Physics.SphereCast(origin,
                                sphereRadius,
                                direction,
                                out RaycastHit hit,
                                rayLength,
                                mask,
                                QueryTriggerInteraction.Collide))
            {
                if(hit.collider.tag.Equals("Ground")){
                    Debug.Log("Found ground");
                    GetComponent<Rigidbody>().AddForce(new Vector3(0,1,0),ForceMode.Impulse);
                }
                else
                {
                    Debug.Log("No ground beneath us");
                }
            }
        }
        GetComponent<Rigidbody>().AddForce(direction*force);    
    }
}
