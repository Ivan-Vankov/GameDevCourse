using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static JuiceUIManager;

public class MuzzleFlashSpawner : MonoBehaviour {

    [SerializeField] private GameObject muzzleFlash = null;

    private void OnEnable() {
        PlayerGun.OnPlayerShoot += SpawnMuzzleFlash;
    }

    private void OnDisable() {
        PlayerGun.OnPlayerShoot -= SpawnMuzzleFlash;
    }

    private void SpawnMuzzleFlash(Vector3 position) {
        if (MuzzleFlashOn) {
            Instantiate(muzzleFlash, 
                        position, 
                        Quaternion.Euler(0, 0, Random.Range(0, 360)));
        }
    }
}
