using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTake : MonoBehaviour
{
    Health health;
    Armor armor;
    [Range(0,1)]
    float armorAbsobtionRatio;
    // Start is called before the first frame update
    private void Start() {
        armor = GetComponent<Armor>();
        health = GetComponent<Health>();
    }
    void takeDamage(int damage) {
        if (armor.getArmor() > 0) {
            armor.reduceWith((int)(armorAbsobtionRatio * damage));
            health.reduceWith((int)((1 - armorAbsobtionRatio) * damage));
        } else {
            health.reduceWith(damage);
        }
    }    
}
