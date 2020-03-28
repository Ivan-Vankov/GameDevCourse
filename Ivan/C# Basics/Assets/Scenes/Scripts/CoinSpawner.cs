using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour {

	public float spawnInterval = 1;
	public float spawnRadius = 5;
	public GameObject coinPrefab;

	void Start() {
		StartCoroutine(SpawnCoins());
	}

	private IEnumerator SpawnCoins() {
		while (true) {
			Instantiate(coinPrefab,
				Random.insideUnitCircle * spawnRadius,
				Quaternion.identity);

			yield return new WaitForSeconds(spawnInterval);
		}
	}
}
