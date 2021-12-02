using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum dialogueType { speechBubble, speechHeader }

[CreateAssetMenu(fileName = "NewDialogue", menuName = "NewDialogue")]
public class Dialogue : ScriptableObject
{
    //dialoguelogic.cs uses this scriptableObject to make the dialogue
    public dialogueType typeOfDialogue;
    [TextArea(1, 2)]
    public string dialogueMessage;
    public AudioClip soundEffect;
    public Sprite talkingHead;
}
