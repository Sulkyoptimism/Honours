using UnityEditor;
using UnityEditor.IMGUI;
using UnityEngine;

public class AudioEventWindow : EditorWindow
{
    string myString = "Hello World";
    float slider = 0f;
    AnimationCurve curve;
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

        slider = EditorGUILayout.Slider(slider, 0f, 1f);

        curve = EditorGUILayout.CurveField(curve);

        EditorGUILayout.EndToggleGroup();



      
    }

    void createc()
    {
        
    }
}