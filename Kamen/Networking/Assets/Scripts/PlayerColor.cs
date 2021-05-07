using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;
using MLAPI.NetworkVariable;
using MLAPI.Messaging;

public class PlayerColor : NetworkBehaviour
{
    [SerializeField]
    NetworkVariableColor32 color = new NetworkVariableColor32(new NetworkVariableSettings { WritePermission = NetworkVariablePermission.OwnerOnly, ReadPermission = NetworkVariablePermission.Everyone });
    
    private void OnEnable()
    {
        color.OnValueChanged += colorUpdate;
    }

    private void OnDisable()
    {
        color.OnValueChanged -= colorUpdate;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsOwner)
        {
            color.Value = new Color32((byte)Random.Range(0, 255),
                                        (byte)Random.Range(0, 255),
                                        (byte)Random.Range(0, 255), 255);
        }
    }
    void colorUpdate(Color32 prevColor, Color32 newColor)
    {
        //updates the material of the gameobject
        GetComponent<MeshRenderer>().material.color = newColor;
    }
}
