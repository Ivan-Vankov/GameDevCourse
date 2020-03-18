using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightObjects : MonoBehaviour {

	private Color highlightColor = Color.red;
	private Color originalColor;
	private GameObject hitObject;
	private Material hitObjectMaterial;

	void Update() {
		HighlightWithScreenPointToRay();
		//HighlightWithScreenToWorldPoint()
	}

	private void HighlightWithScreenPointToRay() {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

		if (!Physics.Raycast(ray, out RaycastHit hit)) {

			if (hitObject != null) {
				hitObjectMaterial.color = originalColor;
				hitObject = null;
			}
		}
		else if (hitObject == null) {

			hitObject = hit.transform.gameObject;
			hitObjectMaterial = hitObject.GetComponent<MeshRenderer>().material;
			originalColor = hitObjectMaterial.color;
			hitObjectMaterial.color = highlightColor;
		}
	}

	private void HighlightWithScreenToWorldPoint() {
		Vector3 nearPlaneMouseScreenPosition = new Vector3() {
			x = Input.mousePosition.x,
			y = Input.mousePosition.y,
			z = Camera.main.nearClipPlane
		};

		Vector3 mousePosition = Camera.main.ScreenToWorldPoint(nearPlaneMouseScreenPosition);
		Vector3 rayDirection = (mousePosition - transform.position).normalized;

		Ray ray = new Ray(transform.position, rayDirection);

		if (!Physics.Raycast(ray, out RaycastHit hit)) {

			if (hitObject != null) {
				hitObjectMaterial.color = originalColor;
				hitObject = null;
			}
		}
		else if (hitObject == null) {

			hitObject = hit.transform.gameObject;
			hitObjectMaterial = hitObject.GetComponent<MeshRenderer>().material;
			originalColor = hitObjectMaterial.color;
			hitObjectMaterial.color = highlightColor;
		}
	}
}