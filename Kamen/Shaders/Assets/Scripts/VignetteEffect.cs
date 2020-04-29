using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public class VignetteEffect : MonoBehaviour {

	public Material vignetteMaterial;

	private void OnRenderImage(RenderTexture source, RenderTexture destination) {
		Graphics.Blit(source, destination, vignetteMaterial);
	}
}
