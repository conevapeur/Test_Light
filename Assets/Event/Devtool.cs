using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Devtool : MonoBehaviour
{
    public bool triggerAnim;
    public Animator _animator;

    public bool triggerSound;
    public AudioSource _audioSource;

    public bool triggerDebug;
    public string _debug;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log(_debug);
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

        myDevtool.triggerAnim = GUILayout.Toggle(myDevtool.triggerAnim, "Trigger Animation ?"); // switch
        if (myDevtool.triggerAnim)
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
            myDevtool._debug = EditorGUILayout.TextField("Chien");




    }
}