using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField] private float speed = 10;
    private Transform player;

    void Start() {
        player = GameObject.FindWithTag("Player").transform;
    }
    
    void Update() {
        MoveToPlayer();
    }

    private void MoveToPlayer() {
        Vector3 vectorToPlayer = (player.position - transform.position).normalized;
        transform.position += vectorToPlayer * Time.deltaTime * speed;
        transform.right = vectorToPlayer;
    }
}
