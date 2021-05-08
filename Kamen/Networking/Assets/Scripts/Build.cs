using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;
using MLAPI.Messaging;

public class Build : NetworkBehaviour
{
    public GameObject building;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    [ServerRpc]
    void BuildServerRpc() {
        Debug.Log("Server RPC called");
        GameObject go = Instantiate(building,transform.position,Quaternion.identity);
        go.GetComponent<NetworkObject>().Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && IsOwner) {
            BuildServerRpc();
        }
    }
}
