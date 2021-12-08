using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueLogic : MonoBehaviour
{
    private bool isActive;
    private AudioManager audioManager;
    [Header("UI")]
    [SerializeField] private GameObject dialogueSpeechBubble;
    [SerializeField] private GameObject dialogueSpeechHeader;
    [SerializeField] private TextMeshProUGUI dialogueBubbleText;
    [SerializeField] private TextMeshProUGUI dialogueHeaderText;
    [SerializeField] private Image imageToChange;
    [Header("Settings")]
    [SerializeField] private Dialogue dialogueObj;
    [SerializeField] private float talkingSpeed, pauseSpeed;
    private void Awake() {
        audioManager = FindObjectOfType<AudioManager>();
    }
    private void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isActive) 
        {
            StartDialogue();
        }
    }
    private void StartDialogue() 
    {
        if(dialogueObj.typeOfDialogue == dialogueType.speechBubble) 
        {
            StartCoroutine(TriggerDialogue(true));
        }
        else 
        {
            StartCoroutine(TriggerDialogue(false));
        }
    }
    private IEnumerator TriggerDialogue(bool dialogueType) 
    {
        isActive = true;
        dialogueBubbleText.text = string.Empty;
        dialogueHeaderText.text = string.Empty;
        if (dialogueType) 
        {
            //speech bubble
            dialogueSpeechBubble.SetActive(true);
            dialogueSpeechHeader.SetActive(false);
        }
        else 
        {
            //speech header
            imageToChange.sprite = dialogueObj.talkingHead;
            dialogueSpeechHeader.SetActive(true);
            dialogueSpeechBubble.SetActive(false);
        }
        foreach (char letter in dialogueObj.dialogueMessage) 
        {
            if (dialogueType) 
            {
                dialogueBubbleText.text += letter;
            }
            else 
            {
                dialogueHeaderText.text += letter;
            }
            if (!char.IsWhiteSpace(letter)) 
            {
                //audioManager.Play("DialogueVoice");
            }
            yield return new WaitForSeconds(talkingSpeed);
        }
        yield return new WaitForSeconds(pauseSpeed); //pauses after very completed sentence
        isActive = false;
        ToggleObj(true, false);
        ToggleObj(false, false);
      
    }
    private void ToggleObj(bool dialogueType, bool trueFalse) 
    {
        if (dialogueType) 
        {
            //bubble dialogue
            dialogueSpeechBubble.SetActive(trueFalse);
            if (!trueFalse) 
            {
                dialogueBubbleText.text = string.Empty;
            }
        }
        else 
        {
            //header dialogue
            dialogueSpeechHeader.SetActive(trueFalse);
            if (!trueFalse) 
            {
                dialogueHeaderText.text = string.Empty;
            }
        }
    }
}
