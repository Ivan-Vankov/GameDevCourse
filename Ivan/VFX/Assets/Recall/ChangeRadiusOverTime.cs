using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class ChangeRadiusOverTime : MonoBehaviour {

	public ParticleSystem sizeReferenceParticleSystem;
	private new ParticleSystem particleSystem;
	private ShapeModule shape;
	private AnimationCurve sizeCurve;
	private float startDuration;
	private float sizeMultiplier;
	private float initialRadius;

	private Particle[] particles;

	void Start() {
		particleSystem = GetComponent<ParticleSystem>();
		sizeCurve = sizeReferenceParticleSystem.sizeOverLifetime.size.curve;
		sizeMultiplier = sizeReferenceParticleSystem.sizeOverLifetime.size.curveMultiplier;
		startDuration = sizeReferenceParticleSystem.main.duration;
		shape = particleSystem.shape;
		initialRadius = shape.radius;

		particles = new Particle[particleSystem.main.maxParticles];
	}

	void Update() {
		particleSystem.GetParticles(particles);

		shape.radius = sizeCurve.Evaluate(Time.time / startDuration) * sizeMultiplier * initialRadius;
		//shape.radius = 1 + Mathf.Sin(Time.time) / 2;
		for (int i = 0; i  < particles.Length; ++i) {
			particles[i].position = particles[i].position.normalized * shape.radius;
		}
		particleSystem.SetParticles(particles);
	}
}
