using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ObjectData", menuName = "Pick up Object Data")]
public class ObjectData : ScriptableObject
{
    [Tooltip("This is the text you want to appear in the inspect window")]
    [TextArea(12, 12)] public string inspectText;

}
