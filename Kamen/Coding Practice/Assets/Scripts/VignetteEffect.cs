using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VignetteEffect : MonoBehaviour
{
    public Material vignetteMaterial;
    float intensity;
    bool increasing;
    private void Start() {
        increasing = true;
    }
    private void Update() {
        if (increasing) {
            intensity += Time.deltaTime/2;
        } else {
            intensity -= Time.deltaTime/2;
        }
        if (intensity > 1) {
            increasing = false;
        } else if (intensity < 0) {
            increasing = true;
        }
        vignetteMaterial.SetFloat("_Intensity", intensity);
    }
    private void OnRenderImage(RenderTexture source, RenderTexture destination) {
        Graphics.Blit(source, destination, vignetteMaterial);
    }
}
