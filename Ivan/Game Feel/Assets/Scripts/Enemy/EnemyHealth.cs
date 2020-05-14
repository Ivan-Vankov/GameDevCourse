using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using static AudioManager;
using static ScreenShaker;

public class EnemyHealth : MonoBehaviour {

    [SerializeField]
    [Range(1, 5)]
    protected int hp = 3;

    public static event Action OnEnemyDeath;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Bullet")) {
            TakeDamage();
        }
    }

    protected void TakeDamage() {
        hp -= 1;
        if (hp <= 0) {
            PlayDeathSound();
            ShakeScreenHeavy();
            OnEnemyDeath?.Invoke();
            Destroy(gameObject);
        }
    }
}
