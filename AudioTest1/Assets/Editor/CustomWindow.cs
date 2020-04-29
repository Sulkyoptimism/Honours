//Create a folder and name it “Editor” and place this second script within it. To do this right click within the Assets directory and go to Create>Folder
using UnityEditor;
using UnityEngine;
using System.Collections;

// Custom Editor using SerializedProperties.
// Automatic handling of multi-object editing, undo, and Prefab overrides.
[CustomEditor(typeof(AudioContainer))]
//[CanEditMultipleObjects]
public class MyPlayerEditor : Editor
{
    public Component[] Acomps;
    public AnimationCurve curve= new AnimationCurve();
    string myString = "Hello World";
    UnityEngine.Object Affetee;
    public string[] options = new string[] { "One", "Two", "Three" };
    public int index = 0;
    string[] optionsbar = new string[] { "Object", "Bake", "Layers" };
    int tab = 0;
    float slider = 0f;
    AudioContainer Container;
    float scrollval = 0f;
    Vector2 scrollbar = new Vector2();


    private void Awake()
    {

        AudioContainer Container = (AudioContainer)target;

    }
    void OnEnable()
    {
        
    }

    public override void OnInspectorGUI()
    {

        GUILayout.BeginHorizontal();
        tab = GUILayout.Toolbar(tab, optionsbar);
        GUILayout.EndHorizontal();

        switch (tab)
        {
            case 0:
                GUILayout.Label("ParameterCreator", EditorStyles.boldLabel);
                myString = EditorGUILayout.TextField("ParameterName", myString);
                Affetee = EditorGUILayout.ObjectField(Affetee, typeof(object), allowSceneObjects: true);
                index = EditorGUILayout.Popup(index, options);
                if (GUILayout.Button("Create")) ;
                slider = EditorGUILayout.Slider(slider, 0f, 1f);

                curve = EditorGUILayout.CurveField(curve);

                break;

            case 1:
                scrollbar = GUILayout.BeginScrollView(scrollbar);

                GUILayout.BeginHorizontal();
                GUILayout.Box("a box");
                GUILayout.Box("a box");
                GUILayout.Box("a box");
                GUILayout.Box("a box");
                GUILayout.Box("a box");
                GUILayout.Box("a box");
                GUILayout.Box("a box");
                GUILayout.Box("a box");
                GUILayout.Box("a box");
                GUILayout.Box("a box");
                GUILayout.Box("a box");
                GUILayout.Box("a box");
                GUILayout.Box("a box");
                GUILayout.Box("a box");
                GUILayout.Box("a box");
                GUILayout.Box("a box");
                GUILayout.Box("a box");
                GUILayout.Box("a box");
                GUILayout.Box("a box");
                GUILayout.Box("a box");
                GUILayout.Box("a box");
                GUILayout.Box("a box");
                GUILayout.Box("a box");
                GUILayout.Box("a box");
                GUILayout.Box("a box");

                GUILayout.EndHorizontal(); GUILayout.BeginHorizontal();
                GUILayout.Box("a box");
                GUILayout.Box("a box");
                GUILayout.Box("a box");
                GUILayout.Box("a box");
                GUILayout.Box("a box");
                GUILayout.Box("a box");
                GUILayout.Box("a box");
                GUILayout.Box("a box");
                GUILayout.Box("a box");
                GUILayout.Box("a box");
                GUILayout.Box("a box");
                GUILayout.Box("a box");
                GUILayout.Box("a box");
                GUILayout.Box("a box");
                GUILayout.Box("a box");
                GUILayout.Box("a box");
                GUILayout.Box("a box");
                GUILayout.Box("a box");
                GUILayout.Box("a box");
                GUILayout.Box("a box");
                GUILayout.Box("a box");
                GUILayout.Box("a box");
                GUILayout.Box("a box");
                GUILayout.Box("a box");
                GUILayout.Box("a box");

                GUILayout.EndHorizontal();
                GUILayout.EndScrollView();
                break;

        }
    }



}