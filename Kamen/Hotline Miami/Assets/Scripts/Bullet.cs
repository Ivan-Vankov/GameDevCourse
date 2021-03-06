﻿using System.Collections;
using System.Collections.Generic;
using static AudioManager;
using static ScreenShaker;
using static JuiceUIManager;
using UnityEngine;

public class Bullet : MonoBehaviour {

    [SerializeField] private GameObject hitParticles = null;
    [SerializeField] private GameObject trailParticles = null;
    [SerializeField] private float speed = 100;

    public Vector3 MoveDirection { get; set; } = Vector3.zero;
    private bool hasHit = false;

    private void Start() {
        hitParticles = transform.GetChild(0).gameObject;
        trailParticles.SetActive(ParticlesOn);
    }

    private void Update() {
        transform.position += MoveDirection * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Enemy") && !hasHit) {
            hasHit = true;

            GetComponent<SpriteRenderer>().enabled = false;
            MoveDirection = Vector3.zero;
            if (ParticlesOn) { hitParticles.SetActive(true); }
            PlayHitSound();
            ShakeScreenLight();

            Destroy(gameObject, 1);
        }
    }
}
