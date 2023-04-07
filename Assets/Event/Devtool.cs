using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class Devtool : MonoBehaviour
{
    public bool triggerAnim;
    public Animator _animator;

    public bool triggerSound;
    public AudioSource _audioSource;

    public bool triggerDebug;
    public string _debug;

    public bool triggerEvent;
    public UnityEvent _event;

    public bool triggerBool;
    public bool _bool;
    public string nameBool;

    public bool triggerScriptable;
    public SO_dialogue _dialogue;

    public void DoSomething()
    {
         
        
        
    }
}

[CustomEditor(typeof(Devtool))] 
public class DevtoolEditor :  Editor
{
    override public void OnInspectorGUI()
    {
        var myDevtool = target as Devtool;
       
        EditorGUILayout.LabelField("Condition", EditorStyles.boldLabel); // header

        myDevtool.triggerAnim = GUILayout.Toggle(myDevtool.triggerAnim, "Trigger Animation ?"); // affichage du switch
        myDevtool.triggerSound = GUILayout.Toggle(myDevtool.triggerSound, "Trigger Sound Effect ?");
        myDevtool.triggerDebug = GUILayout.Toggle(myDevtool.triggerDebug, "Debug ?");
        myDevtool.triggerBool = GUILayout.Toggle(myDevtool.triggerBool,"Test (always true)"); // laisser en true mdr
        myDevtool.triggerScriptable = GUILayout.Toggle(myDevtool.triggerScriptable, "Dialogue"); // laisser en true mdr
        var _event = serializedObject.FindProperty("_event");
        myDevtool.triggerEvent = GUILayout.Toggle(myDevtool.triggerEvent, "Event ?");

        if (myDevtool.triggerAnim) // switch
        {
            EditorGUILayout.Space(10);
            EditorGUILayout.LabelField("Animation", EditorStyles.boldLabel);
            myDevtool._animator = (Animator)EditorGUILayout.ObjectField("Animator", myDevtool._animator, typeof(Animator), true); // cast type Object en Animator
        }

        if (myDevtool.triggerSound)
        {
            EditorGUILayout.Space(10);
            EditorGUILayout.LabelField("Sound Effect", EditorStyles.boldLabel);
            myDevtool._audioSource = (AudioSource)EditorGUILayout.ObjectField("AudioSource", myDevtool._audioSource, typeof(AudioSource), true);
        }
           
        if (myDevtool.triggerDebug)
        {
            EditorGUILayout.Space(10);
            EditorGUILayout.LabelField("Debug", EditorStyles.boldLabel);
            myDevtool._debug = EditorGUILayout.TextField(myDevtool._debug);
        }

        if (myDevtool.triggerBool)
        {
            EditorGUILayout.Space(10);
            EditorGUILayout.LabelField("Bool", EditorStyles.boldLabel);
            myDevtool.nameBool = EditorGUILayout.TextField(myDevtool.nameBool);
            myDevtool._bool = EditorGUILayout.Toggle("Test (always true)", myDevtool._bool); // laisser en true mdr

        }
        
        if (myDevtool.triggerEvent)
        {
            EditorGUILayout.Space(10);
            EditorGUILayout.LabelField("Event", EditorStyles.boldLabel);
            EditorGUILayout.PropertyField(_event, true);
            serializedObject.ApplyModifiedProperties();
        }

        if (myDevtool.triggerScriptable)
        {
            EditorGUILayout.Space(10);
            EditorGUILayout.LabelField("Dialogue", EditorStyles.boldLabel);
            myDevtool._dialogue = (SO_dialogue)EditorGUILayout.ObjectField("Dialogue", myDevtool._dialogue, typeof(SO_dialogue), true);
        }
    }
}