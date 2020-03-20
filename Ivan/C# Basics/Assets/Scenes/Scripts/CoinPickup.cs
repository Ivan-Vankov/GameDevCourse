using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CoinPickup : MonoBehaviour {

	public static event Action OnCoinPickup;

	private void OnTriggerEnter(Collider other) {
		if (other.CompareTag("Coin")) {
			Destroy(other.gameObject);

			if (OnCoinPickup != null) {
				OnCoinPickup();
			}
			print("Picked up coin!");
		}
	}
}
