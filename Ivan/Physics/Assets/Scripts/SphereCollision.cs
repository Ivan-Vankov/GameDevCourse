using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider), typeof(Renderer))]
public class SphereCollision : MonoBehaviour {

	public SphereCollider otherCollider;
	private SphereCollider sphereCollider;

	[SerializeField]
	private Color markedColor = Color.red;
	private Color originalColor;
	private Material material;

	void Start() {
		sphereCollider = GetComponent<SphereCollider>();
		material = GetComponent<Renderer>().material;
		originalColor = material.color;
	}

	void Update() {
		material.color = 
			Intersect(sphereCollider.bounds.center,
					  sphereCollider.radius * transform.lossyScale.x, 
					  otherCollider.bounds.center,
					  otherCollider.radius * transform.lossyScale.x)
			? markedColor
			: originalColor;
	}

	private static bool Intersect(Vector3 aCenter, float aRadius, 
	                              Vector3 bCenter, float bRadius) {

		float distance = Mathf.Sqrt(
			(aCenter.x - bCenter.x) * (aCenter.x - bCenter.x) +
			(aCenter.y - bCenter.y) * (aCenter.y - bCenter.y) +
			(aCenter.z - bCenter.z) * (aCenter.z - bCenter.z));
		return distance < (aRadius + bRadius);
	}
}
