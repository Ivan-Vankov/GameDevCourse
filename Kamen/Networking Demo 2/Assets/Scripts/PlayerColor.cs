using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class PlayerColor :  NetworkBehaviour
{
    public NetworkVariable<Color> playerColor = new NetworkVariable<Color>(Color.white,NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Owner);

    public Renderer m_renderer;
    // Start is called before the first frame update
    void Start()
    {
        m_renderer = GetComponent<Renderer>();
        playerColor.Value = new Color(Random.Range(0.0f,1),Random.Range(0.0f,1),Random.Range(0.0f,1));
        Debug.Log(playerColor.Value);
        m_renderer.material.color = (playerColor.Value);
    }

    // Update is called once per frame
    void Update()
    {
        m_renderer.material.color = (playerColor.Value);
    }

}
