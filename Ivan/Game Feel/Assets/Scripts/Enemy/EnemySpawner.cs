using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    [SerializeField] private GameObject enemy = null;

    [SerializeField]
    [Range(0, 10)]
    private float spawnRate = 1.5f;

    private Transform player;

    void Start() {
        StartCoroutine(SpawnEnemies());
        player = GameObject.FindWithTag("Player").transform;
    }

    private IEnumerator SpawnEnemies() {
        while (true) {
            yield return new WaitForSeconds(1f / spawnRate);

            Vector3 spawnLocation = player.position 
                + (Vector3)Random.insideUnitCircle.normalized * 50;
            Instantiate(enemy,
                spawnLocation, 
                Quaternion.identity);
        }
    }
}
