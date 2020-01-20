//Create a folder and name it “Editor” and place this second script within it. To do this right click within the Assets directory and go to Create>Folder
using UnityEditor;
using UnityEngine;
using System.Collections;

// Custom Editor using SerializedProperties.
// Automatic handling of multi-object editing, undo, and Prefab overrides.
//[CustomEditor(typeof(TriggerScript))]
//[CanEditMultipleObjects]
public class MyPlayerEditor : Editor
{
    SerializedProperty damageProp;
    SerializedProperty armorProp;
    SerializedProperty gunProp;

    Parameter _targ;
    void OnEnable()
    {
        // Setup the SerializedProperties.
        damageProp = serializedObject.FindProperty("Pitch");
        armorProp = serializedObject.FindProperty("PitchRand");
        gunProp = serializedObject.FindProperty("RolloffMin");
    }

    public override void OnInspectorGUI()
    { }


    void test()
    {
        _targ = (Parameter)target;
    }
}