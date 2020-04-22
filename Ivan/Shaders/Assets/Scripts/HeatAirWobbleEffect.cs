using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class HeatAirWobbleEffect : MonoBehaviour {

	public Material wobbleMaterial;

	// source: the image about to be rendered
	// destination: what the image will look like after our effect is applied
	private void OnRenderImage(RenderTexture source, RenderTexture destination) {
		// What Blit does:
		// 1) Adds a screen sized quad on top and 
		// 2) Gives it the passed material
		// 3) Sets the material's _MainTex to be the source texture
		// 4) Places the result to the destination texture
		Graphics.Blit(source, destination, wobbleMaterial);
	}
}
