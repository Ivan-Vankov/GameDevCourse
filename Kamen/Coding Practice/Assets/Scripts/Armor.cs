using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : MonoBehaviour
{
    [SerializeField]
    private int armor;
    public event Action<int> onArmorChanged;

    
    public int getArmor() {
        return armor;
    }

    public void reduceWith(int quantity) {
        armor -= quantity;
        onArmorChanged(armor);
    }
        
}
