using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class PlayerMovement : NetworkBehaviour
{
    Vector3 movementDirection;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(IsOwner){
            float horizontal = Input.GetAxis("Horizontal"); 
            float vertical = Input.GetAxis("Vertical"); 
            UpdateInputServerRpc(horizontal, vertical);
        }
        if(IsServer){
            transform.Translate(Time.deltaTime * movementDirection);
            Debug.Log("Server translated Player");
        }
    }

    [ServerRpc]
    void UpdateInputServerRpc(float horizontal, float vertical){
        if(horizontal <= 1.0 && vertical <= 1.0)
            movementDirection = new Vector3(horizontal, 0, vertical);
            Debug.Log("Movement direction updated");
    }
}
