using UnityEditor;
using UnityEditor.IMGUI;
using UnityEngine;

public class AudioEventWindow : EditorWindow
{
    string myString = "Hello World";
    bool groupEnabled;
    bool myBool = true;
    float myFloat = 1.23f;
    float slider = 0f;
    AudioCurveRendering curve;
    Texture ic = AssetDatabase.GetCachedIcon("Assets / Audio / Big_Clash1 52 - 471095__spycrah__sword - clash - 1.wav");

    // Add menu item named "My Window" to the Window menu
    [MenuItem("Window/TM_Audio")]
    public static void ShowWindow()
    {
        //Show existing window instance. If one doesn't exist, make one.
        EditorWindow.GetWindow(typeof(AudioEventWindow));
    }

    void OnGUI()
    {
        
        GUILayout.Label("Base Settings", EditorStyles.boldLabel);
        myString = EditorGUILayout.TextField("Text Field", myString);
        EditorGUILayout.BeginHorizontal();

        slider = EditorGUILayout.Slider(slider, 0f, 1f);

        EditorGUILayout.EndHorizontal();
        groupEnabled = EditorGUILayout.BeginToggleGroup("Optional Settings", groupEnabled);
        myBool = EditorGUILayout.Toggle("Toggle", myBool);
        myFloat = EditorGUILayout.Slider("Slider", myFloat, -3, 3);
        EditorGUILayout.EndToggleGroup();

    }

    void createc()
    {
        
    }
}