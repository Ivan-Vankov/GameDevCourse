using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider), typeof(Renderer))]
public class AABBCollision : MonoBehaviour {

	public BoxCollider otherCollider;
	private BoxCollider boxCollider;

	[SerializeField]
	private Color markedColor = Color.red;
	private Color originalColor;
	private Material material;

	void Start() {
		boxCollider = GetComponent<BoxCollider>();
		material = GetComponent<Renderer>().material;
		originalColor = material.color;
	}
	
	void Update() {
		material.color = Intersect(boxCollider.bounds, otherCollider.bounds)
			? markedColor
			: originalColor;
	}

	private static bool Intersect(Bounds a, Bounds b) {
		return (a.min.x <= b.max.x && a.max.x >= b.min.x)
			&& (a.min.y <= b.max.y && a.max.y >= b.min.y)
			&& (a.min.z <= b.max.z && a.max.z >= b.min.z);
	}
}
