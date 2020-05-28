using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Health : MonoBehaviour
{
    public VignetteEffect ve;
    [SerializeField]
    private int health;
    public event Action<int> onHealthChanged;

    public int getHealth() {
        return health;
    }
    public void reduceWith(int quantity) {
        health = Math.Max(health-quantity,0);
        onHealthChanged(health);
        if (health < 30) {
            //TODO add vignette filter when on low health
            ve.enabled = true;
        }
        if (health == 0) {
            die();
        }
    }
    void die() {
        GetComponent<Ammo>().enabled = false;
        GetComponent<PlayerMovement>().enabled = false;
    }
}
