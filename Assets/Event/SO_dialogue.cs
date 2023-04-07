using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Line
{
    [TextArea(5, 7)]
    public string text;
} 

[CreateAssetMenu(fileName = "newDialogue", menuName = "Dialogue")]
public class SO_dialogue : ScriptableObject
{
    public Line[] lines;
}
