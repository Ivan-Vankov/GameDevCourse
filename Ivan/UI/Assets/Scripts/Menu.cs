using UnityEngine;
using static UnityEngine.Mathf;

public class Menu : MonoBehaviour {

	[SerializeField]
	[Range(0, 5)]
	private float rotationAmplitude = 2;

	[SerializeField]
	[Range(0, 5)]
	private float rotationFrequency = 0.65f;

    void Update() {
		transform.rotation = Quaternion.Euler(0, 0, 
			rotationAmplitude * Sin(rotationFrequency * Time.time));
    }
}
