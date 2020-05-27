using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField]
    private int ammo;
    public event Action<int> onAmmoChanged;
    // Start is called before the first frame update
    void Start()
    {
        //sets initial value
        onAmmoChanged?.Invoke(ammo);    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && ammo>0) {
            ammo--;
            onAmmoChanged?.Invoke(ammo);

            //Raycast and hit enemy
            //TODO
        } 
    }
}
