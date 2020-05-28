using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    private Transform player;
    private Vector3 initialOffset;
    
    void Start() {
        player = GameObject.FindWithTag("Player").transform;
        initialOffset = transform.position - player.position;
    }

    private void FollowPlayer() {
        Vector2 vectorToPlayer = (Vector2)player.position
                       - (Vector2)transform.position;
        if (vectorToPlayer.magnitude > 0.01f) {
            Vector3 targetPosition = (Vector3)vectorToPlayer + initialOffset;
            transform.position = player.position + initialOffset;
        }
    }

    private void OnEnable() {
        PlayerMovement.OnPlayerMove += FollowPlayer;
    }

    private void OnDisable() {
        PlayerMovement.OnPlayerMove -= FollowPlayer;
    }
}
