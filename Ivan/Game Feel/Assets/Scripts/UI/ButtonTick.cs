using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonTick : MonoBehaviour {

    private bool isActive = false;
    private GameObject tickImage;

    void Start() {
        tickImage = transform.GetChild(0).gameObject;
    }
    
    public void SwitchOnOrOff() {
        isActive = !isActive;
        tickImage.SetActive(isActive);
    }
}
