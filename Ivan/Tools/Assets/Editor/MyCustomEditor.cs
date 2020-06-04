using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MyScript))]
public class MyCustomEditor : Editor {
    public override void OnInspectorGUI() {
        base.OnInspectorGUI();

        MyScript myScript = (MyScript)target;
        
        GUILayout.BeginHorizontal();

        GUILayout.Label("Set Size");

        if (GUILayout.Button("Small"))  { myScript.SetSmallSize(); }
        if (GUILayout.Button("Medium")) { myScript.SetMediumSize(); }
        if (GUILayout.Button("Large"))  { myScript.SetLargeSize(); }

        GUILayout.EndHorizontal();
    }
}
