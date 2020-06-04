using UnityEngine;

public class MyScript : MonoBehaviour {

    public Vector3 mediumSize = Vector3.one;

    public void SetSmallSize() {
        transform.localScale = mediumSize * 0.5f;
    }

    public void SetMediumSize() {
        transform.localScale = mediumSize;
    }

    public void SetLargeSize() {
        transform.localScale = mediumSize * 2;
    }
}
