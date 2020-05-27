using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static JuiceUIManager;

public class BlobSpawner : MonoBehaviour {

    [SerializeField] private GameObject[] blobs = null;

    private void OnEnable() {
        EnemyHealth.OnEnemyDeath += SpawnBlob;
    }

    private void OnDisable() {
        EnemyHealth.OnEnemyDeath -= SpawnBlob;
    }

    public void SpawnBlob(Vector3 position) {
        if (PermananceOn) {
            int blobIndex = Random.Range(0, blobs.Length);
            Instantiate(blobs[blobIndex], position, Quaternion.Euler(0, 0 , Random.Range(0, 360)));
        }
    }
}
