using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEditor.UI;

[CustomEditor(typeof(CustomButton)), CanEditMultipleObjects]
public class CustomButtonEditor : ButtonEditor
{
    SerializedProperty
        //vibraType, 
        //vibrate, 
        //soundType, 
        //playSound,
        animate;

    protected override void OnEnable()
    {
        base.OnEnable();

        //vibraType = serializedObject.FindProperty("vibrationType");
        //soundType = serializedObject.FindProperty("soundType");
        //vibrate = serializedObject.FindProperty("vibrateOnPress");
        //playSound = serializedObject.FindProperty("playSoundOnPress");
        animate = serializedObject.FindProperty("animate");
    }

    public override void OnInspectorGUI()
    {
        //EditorGUILayout.PropertyField(vibraType);
        //EditorGUILayout.PropertyField(soundType);
        //EditorGUILayout.PropertyField(vibrate);
        //EditorGUILayout.PropertyField(playSound);
        EditorGUILayout.PropertyField(animate);

        serializedObject.ApplyModifiedProperties();

        base.OnInspectorGUI();
    }
}