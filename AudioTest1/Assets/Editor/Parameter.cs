using UnityEditor;
using UnityEditor.IMGUI;
using UnityEngine;


public class Parameter : EditorWindow
{
    public Component[] Acomps;
    public AnimationCurve curve;
    string myString = "Hello World";
    UnityEngine.Object Affetee;
    public string[] options = new string[] { "One", "Two", "Three" };
    public int index = 0;

    float slider = 0f;

    // Add menu item named "My Window" to the Window menu
    [MenuItem("Window/TM_Audio")]
    public static void ShowWindow()
    {
        //Show existing window instance. If one doesn't exist, make one.
        EditorWindow.GetWindow(typeof(Parameter));
    }

    void OnGUI()
    {

        GUILayout.Label("ParameterCreator", EditorStyles.boldLabel);
        myString = EditorGUILayout.TextField("ParameterName", myString);
        Affetee = EditorGUILayout.ObjectField(Affetee,typeof(object),allowSceneObjects:true);
        index = EditorGUILayout.Popup(index, options);
        if (GUILayout.Button("Create"))
            InstantiatePrimitive();
        slider = EditorGUILayout.Slider(slider, 0f, 1f);

        curve= EditorGUILayout.CurveField(curve);
   

    }

    void InstantiatePrimitive()
    {
        switch (index)
        {
            case 0:
                Debug.Log("1");
                break;
            case 1:
                Debug.Log("2");

                break;
            case 2:
                Debug.Log("3");

                break;
            default:
                Debug.LogError("Unrecognized Option");
                break;
        }
    }

    
    private void Update()
    {
   

    }
}
