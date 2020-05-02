using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class PostProcessing : MonoBehaviour {

    [SerializeField] private Material postProcessMaterial = null;

    private void OnRenderImage(RenderTexture source, RenderTexture destination) {
        Graphics.Blit(source, destination, postProcessMaterial);
    }
}
