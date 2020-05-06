using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class FinalParticleDispersion : MonoBehaviour {
	
	public float expansionTimeStart = 8;
	public AnimationCurve expansionCurve;

	private new ParticleSystem particleSystem;
	private float startDuration;
	private float sizeMultiplier;

	private Particle[] particles;

	void Start() {
		particleSystem = GetComponent<ParticleSystem>();

		particles = new Particle[particleSystem.main.maxParticles];
	}

	void Update() {
		float timeSinceStart = Time.time - expansionTimeStart;
		if (timeSinceStart < 0) {
			return;
		}

		float currentExpansionFactor = expansionCurve.Evaluate(timeSinceStart);

		particleSystem.GetParticles(particles);
		for (int i = 0; i < particles.Length; ++i) {
			particles[i].position = particles[i].position.normalized * currentExpansionFactor;
		}
		particleSystem.SetParticles(particles);
	}
}
