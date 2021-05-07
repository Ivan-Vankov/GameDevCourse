using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;

public class PrintNetworkId : NetworkBehaviour
{
    private void OnGUI()
    {
        if (IsOwner)
        {
            ulong networkObjectId = GetComponent<NetworkObject>().NetworkObjectId;
            GUILayout.Label("Network object id " + networkObjectId);
            ulong networkInstanceId = GetComponent<NetworkObject>().NetworkInstanceId;
            GUILayout.Label("Network instance id " + networkInstanceId);
        }
    }

}
