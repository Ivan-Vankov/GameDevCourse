using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static JuiceUIManager;

public class SmokeParticleHandler : MonoBehaviour {

    [SerializeField] private ParticleSystem smokeParticles = null;

    private void OnEnable() {
        PlayerMovement.OnPlayerDash += SpawnSmokeParticles;
    }

    private void OnDisable() {
        PlayerMovement.OnPlayerDash -= SpawnSmokeParticles;
    }

    private void SpawnSmokeParticles() {
        if (ParticlesOn) {
            smokeParticles.gameObject.SetActive(true);
            smokeParticles.Stop();
            smokeParticles.Play();
        }
    }
}
