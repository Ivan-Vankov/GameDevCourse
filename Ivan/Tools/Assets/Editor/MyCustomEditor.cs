using UnityEditor;
using UnityEngine;

// Add the typo of script that you will modify the inspector of
// Extend UnityEditor.Editor and NOT MonoBehaviour
[CustomEditor(typeof(MyScript))]
public class MyCustomEditor : Editor {

    // All the GUI logic should be in this method
    public override void OnInspectorGUI() {
        // You can use show the automatically generated inspector
        base.OnInspectorGUI();

        // You can reference the target script from the Editor.target property
        MyScript myScript = (MyScript)target;

        // GUILayout is used for displaying GUI elements that automatically fit in the inspector
        // You can make a horizontally aligned group of GUI objects
        GUILayout.BeginHorizontal();

        // You can add a label
        GUILayout.Label("Set Size");

        // You can make buttons and call methods of the target script
        if (GUILayout.Button("Small"))  { myScript.SetSmallSize(); }
        if (GUILayout.Button("Medium")) { myScript.SetMediumSize(); }
        if (GUILayout.Button("Large"))  { myScript.SetLargeSize(); }

        GUILayout.EndHorizontal();
    }
}
