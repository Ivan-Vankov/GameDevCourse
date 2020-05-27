using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoTracker : NumberTracker 
{
    public GameObject ammoCarrier;

    private void OnEnable() {
        ammoCarrier.GetComponent<Ammo>().onAmmoChanged+=onChangedValue; 
    }
    private void OnDisable() {
        ammoCarrier.GetComponent<Ammo>().onAmmoChanged-=onChangedValue; 
    }
}
