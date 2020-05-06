using System;
using UnityEngine;
using static UnityEngine.Mathf;

public class Health : MonoBehaviour {

    public static readonly int maxHealth = 100;

    [SerializeField]
    private int health = maxHealth;

    public int HP {
        get { return health; }
        set {
            health = Clamp(value, 0, maxHealth);
        }
    }

    private Animator animator;
    public GameObject cross;

    public event Action<int> OnDamageTaken;

    void Start() {
        animator = GetComponent<Animator>();
    }

    public int getHealth() {
        return health;
    }

    public void SpawnCross() {
        Vector2 spawnPosition = new Vector2 {
            x = transform.position.x,
            y = -0.1f
        };
        Instantiate(cross, spawnPosition, Quaternion.identity);
    }

    public void Die() {
        Destroy(gameObject);
    }

    public void TakeDamage() {
        int damage = 10;
        health = Max(health - damage, 0);
        animator.SetInteger("Health", health);
        animator.SetTrigger("TookDamage");
        OnDamageTaken?.Invoke(health);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.transform.parent != transform
            && collision.gameObject.CompareTag("Hitbox")) {

            TakeDamage();
        }
    }
}