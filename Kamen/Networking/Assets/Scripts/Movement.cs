using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;

public class Movement : NetworkBehaviour
{
    [SerializeField]
    float speed = 5;

    private float horizontal;
    private float vertical;

    // Update is called once per frame
    void Update()
    {
        if (IsOwner)
        {
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");
            transform.Translate(Time.deltaTime * speed * new Vector3(horizontal, 0, vertical));
        }
    }
}
