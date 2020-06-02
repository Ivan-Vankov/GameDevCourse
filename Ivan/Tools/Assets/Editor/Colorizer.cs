using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Colorizer : EditorWindow {

    public Color tint;

    // Can now open this window from Unity
    [MenuItem("Window/Custom Colorizer")]
    public static void ShowWindow() {
        // Opens a new window if one is not open yet
        // othewise focuses on the opened.
        GetWindow<Colorizer>("Custom Colorizer");
    }

    // The logic for displaying the UI is all here
    private void OnGUI() {
        // Most drawing functions come from 
        // GUILayout:       https://docs.unity3d.com/ScriptReference/GUILayout.html
        // and 
        // EditorGUILayout: https://docs.unity3d.com/ScriptReference/EditorGUILayout.html

        GUILayout.Label("Select Tint");

        EditorGUILayout.BeginHorizontal();
        tint = EditorGUILayout.ColorField(tint, GUILayout.MaxWidth(300), GUILayout.Height(30));

        if (GUILayout.Button(Resources.Load<Texture>("Sprites/Brush"), 
            GUILayout.Height(30), 
            GUILayout.Width(30))) {

            foreach (GameObject gameObject in Selection.gameObjects) {
                Renderer renderer = gameObject.GetComponent<Renderer>();

                if (renderer != null) {
                    renderer.sharedMaterial.color = tint;
                }
            }
        }

        EditorGUILayout.EndHorizontal();
    }
}
