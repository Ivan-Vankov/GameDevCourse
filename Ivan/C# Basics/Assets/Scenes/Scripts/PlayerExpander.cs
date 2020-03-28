using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExpander : MonoBehaviour {

	[SerializeField]
	private float scaleAmount = 1.1f;

	private void OnEnable() {
		CoinPickup.OnCoinPickup += ExpandPlayer;
	}

	private void OnDisable() {
		CoinPickup.OnCoinPickup -= ExpandPlayer;
	}

	private void ExpandPlayer() {
		transform.localScale *= scaleAmount;
	}
}
