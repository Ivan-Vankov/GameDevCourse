using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MyScript))]
public class MyCustomEditor : Editor {
    public override void OnInspectorGUI() {
        MyScript myScript = (MyScript)target;

        if (GUILayout.Button(Resources.Load<Texture>("Sprites/Explosion"), 
            GUILayout.Width(40),
            GUILayout.Height(40))) {

            myScript.BOOM();
        }
    }
}
