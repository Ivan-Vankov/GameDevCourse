using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
   public IEnumerator shake(float duration, float intensity) {
        float passedTime = 0;
        Vector3 originalPosition = transform.position;
        while (passedTime < duration) {
            passedTime += Time.deltaTime;
            transform.position = originalPosition + (new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), 0) * intensity);
            yield return null;
        }
        transform.position = originalPosition;
    } 

    // Update is called once per frame
    void Start()
    {
    }
}
