using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewDialogue", menuName = "NewDialogue")]
public class Dialogue : ScriptableObject
{
    [TextArea(1, 2)]
    public string dialogueMessage;
    public string audioClipName;
}
