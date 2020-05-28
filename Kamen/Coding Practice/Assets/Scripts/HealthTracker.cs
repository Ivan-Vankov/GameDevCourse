using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthTracker : NumberTracker 
{
    public GameObject healthCarrier;
    private void OnEnable() {
        Debug.Log(healthCarrier.name);
        healthCarrier.GetComponent<Health>().onHealthChanged += onChangedValue; 
    }
    private void OnDisable() {
        healthCarrier.GetComponent<Health>().onHealthChanged -= onChangedValue; 
    }
}
