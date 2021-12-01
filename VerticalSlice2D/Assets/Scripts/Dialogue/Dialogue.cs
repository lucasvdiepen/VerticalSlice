using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewDialogue", menuName = "NewDialogue")]
public class Dialogue : ScriptableObject
{
    //dialoguelogic.cs uses this scriptableObject to make the dialogue
    [TextArea(1, 2)]
    public string dialogueMessage;
    public AudioClip soundEffect;
}
