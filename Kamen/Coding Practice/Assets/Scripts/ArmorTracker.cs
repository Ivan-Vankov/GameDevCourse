using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorTracker : NumberTracker 
{
    public GameObject armorCarrier;
    private void OnEnable() {
        armorCarrier.GetComponent<Armor>().onArmorChanged += onChangedValue; 
    }
    private void OnDisable() {
        armorCarrier.GetComponent<Armor>().onArmorChanged -= onChangedValue; 
    }
}
