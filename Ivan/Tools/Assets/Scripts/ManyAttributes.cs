using UnityEngine;

public class ManyAttributes : MonoBehaviour {
    // Headers apper as bold text
    // Can be used for indicating 
    [Header("My Header")]
    // A [TextArea(minLines, maxLines)] adds an expandable and scrollable 
    // view for text editing in the inspector
    [TextArea(2, 5)]
    [Tooltip("Appears when hovering over")]
    [SerializeField]
    private string myVariable;

    // [Space(n)] adds n pixels of empty space from the last element
    [Space(20)]
    [Header("Color Attributes")]
    [SerializeField]
    // By default colors appear as rgba in the inspector
    private Color colorNormal;

    // [ColorUsage(showAlpha = false)] makes them appear in rgb mode
    [ColorUsage(false)]
    [SerializeField]
    private Color colorNoAlpha;

    // [ColorUsage(hdr = false)] makes them appear as hdr (high dynamic range) colors
    [ColorUsage(true, true)]
    [SerializeField]
    private Color colorHDR;

    [Space(20)]
    [Header("Can be changed from the context menu")]
    [SerializeField]
    private float randomValue;

    // Appears in the context menu as an extra function
    [ContextMenu("My Context Menu Method")]
    private void ChooseRandomValues() {
        randomValue = Random.Range(-5f, 5f);
    }
}