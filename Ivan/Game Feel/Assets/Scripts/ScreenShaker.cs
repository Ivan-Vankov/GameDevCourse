using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShaker : MonoBehaviour {

    [SerializeField] private AnimationCurve shakeCurve;

    private void Start() {
        shakeCurve.AddKey(0, 0);
        shakeCurve.AddKey(0.1f, 1);
        shakeCurve.AddKey(1, 0);
    }

    public void ShakeScreen() {

    }
}
