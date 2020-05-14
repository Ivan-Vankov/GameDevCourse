using UnityEngine;
using System;
using static Controlls;
using static AudioManager;

public class PlayerGun : MonoBehaviour {

    [SerializeField] private GameObject bullet = null;
    private Transform bulletSpawnLocation = null;

    public static Action OnPlayerShoot;

    private void Start() {
        bulletSpawnLocation = transform.GetChild(0);
    }

    private void Update() {
        if (Input.GetKeyDown(fireKey)) {
            Shoot();
            OnPlayerShoot?.Invoke();
        }
    }
    
    private void Shoot() {
        Bullet bulletInstance = Instantiate(bullet,
            bulletSpawnLocation.position,
            Quaternion.identity).GetComponent<Bullet>();
        PlayGunfireSound();

        bulletInstance.MoveDirection = (bulletSpawnLocation.position
                                      - transform.position).normalized;
        Destroy(bulletInstance.gameObject, 5);
    }
}
