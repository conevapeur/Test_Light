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

    private void Update()
    {
        if (interactReadable.card == true)
        {
            _bool= true;
        }
    }

    public void DoSomething()
    {
        if (_bool == true)
        {
            Debug.Log(_debug);
            _animator.SetTrigger("trigger");
        }
    }
}

[CustomEditor(typeof(Devtool))] 
public class DevtoolEditor :  Editor
{
    override public void OnInspectorGUI()
    {
        var myDevtool = target as Devtool;
       
        EditorGUILayout.LabelField("Animation", EditorStyles.boldLabel); // header

        myDevtool.triggerAnim = GUILayout.Toggle(myDevtool.triggerAnim, "Trigger Animation ?"); // affichage du switch
        if (myDevtool.triggerAnim) // switch
            myDevtool._animator = (Animator)EditorGUILayout.ObjectField("Animator", myDevtool._animator, typeof(Animator), true); // cast type Object en Animator

        EditorGUILayout.Space(10);
        EditorGUILayout.LabelField("Sound Effect", EditorStyles.boldLabel);

        myDevtool.triggerSound = GUILayout.Toggle(myDevtool.triggerSound, "Trigger Sound Effect ?");
        if (myDevtool.triggerSound)
            myDevtool._audioSource = (AudioSource)EditorGUILayout.ObjectField("AudioSource",myDevtool._audioSource, typeof(AudioSource), true);

        EditorGUILayout.Space(10);
        EditorGUILayout.LabelField("Debug", EditorStyles.boldLabel);

        myDevtool.triggerDebug = GUILayout.Toggle(myDevtool.triggerDebug, "Debug ?");
        if (myDevtool.triggerDebug)
            myDevtool._debug = EditorGUILayout.TextField(myDevtool._debug);

        EditorGUILayout.Space(10);
        EditorGUILayout.LabelField("Bool", EditorStyles.boldLabel);

        myDevtool._bool = EditorGUILayout.Toggle("Test (always true)",myDevtool._bool); // laisser en true mdr

        EditorGUILayout.Space(10);
        EditorGUILayout.LabelField("Event", EditorStyles.boldLabel);

        var _event = serializedObject.FindProperty("_event");
        myDevtool.triggerEvent = GUILayout.Toggle(myDevtool.triggerEvent, "Event ?");
        if (myDevtool.triggerEvent)
            EditorGUILayout.PropertyField(_event, true);
        serializedObject.ApplyModifiedProperties();

    }
}