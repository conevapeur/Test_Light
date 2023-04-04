using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Devtool : MonoBehaviour
{
    public bool flag;
    public int i = 1;
    public GameObject _gameObject;
}

[CustomEditor(typeof(Devtool))]
public class DevtoolEditor :  Editor
{
    override public void OnInspectorGUI()
    {
        var myDevtool = target as Devtool;

        myDevtool.flag = GUILayout.Toggle(myDevtool.flag, "Flag");

        if (myDevtool.flag)
            myDevtool.i = EditorGUILayout.IntSlider("I field:", myDevtool.i, 1, 100);
            //myDevtool._gameObject = EditorGUILayout.ObjectField("gameObject",myDevtool._gameObject, typeof(Object));

    }
}