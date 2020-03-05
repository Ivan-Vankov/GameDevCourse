using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCube : MonoBehaviour
{

    public float moveSpeed=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDirection =
        new Vector3(Input.GetAxis("Horizontal"),
                    0,
                    Input.GetAxis("Vertical"))
                    .normalized
        * Time.deltaTime
        * moveSpeed;
        Vector3 pointToLookAt = transform.position
                              + moveDirection * 100;

        transform.position += moveDirection;
        transform.LookAt(pointToLookAt);
    }
}
