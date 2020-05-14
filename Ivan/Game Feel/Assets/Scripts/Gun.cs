using System.Collections;
using System.Collections.Generic;
using static JuiceUIManager;
using static AudioManager;
using UnityEngine;
using static Controlls;

public class Gun : MonoBehaviour {

    [SerializeField] private GameObject bullet = null;
    private Transform bulletSpawnLocation;

    void Start() {
        bulletSpawnLocation = transform.GetChild(0);
    }
    
    void Update() {
        if (Input.GetKeyDown(fireKey)) {
            Bullet bulletInstance = Instantiate(bullet, 
                bulletSpawnLocation.position, 
                Quaternion.identity).GetComponent<Bullet>();
            PlayGunfireSound();

            bulletInstance.MoveDirection = (bulletSpawnLocation.position
                                          - transform.position).normalized;
            Destroy(bulletInstance.gameObject, 5);
        }
    }
}
