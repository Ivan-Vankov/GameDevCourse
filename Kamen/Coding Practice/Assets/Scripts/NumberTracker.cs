using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberTracker : MonoBehaviour
{
    //Digits should have an Image Component and be ordered from least important to most important 
    public GameObject[] digits;

    public void onChangedValue(int value) {
        Debug.Log(value);
        activateDigits(value);
    }

    void activateDigits(int value) {
        foreach(GameObject current in digits) {
            if (value != 0) {
                current.SetActive(true);

                Sprite spriteDigit = Resources.Load<Sprite>($"UI/Numbers/winum{value % 10}");
                current.GetComponent<Image>().sprite = spriteDigit;
            } else {
                current.SetActive(false);
            }
            value /= 10;
        }

    }
}
