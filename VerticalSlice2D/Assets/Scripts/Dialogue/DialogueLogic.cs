using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueLogic : MonoBehaviour
{
    private bool isActive;
    private AudioManager audioManager;
    [SerializeField] private GameObject dialogueBoxUI;
    [SerializeField] private TextMeshProUGUI dialogueUIText;
    [SerializeField] private Dialogue dialogueObj;
    [SerializeField] private float talkingSpeed, pauseSpeed;
    private void Awake() {
        audioManager = FindObjectOfType<AudioManager>();
    }
    private void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isActive) 
        {
            dialogueBoxUI.SetActive(true);
            StartCoroutine(StartDialogue());
        }
    }
    private IEnumerator StartDialogue() 
    {
        isActive = true;
        dialogueUIText.text = string.Empty;
        foreach (char letter in dialogueObj.dialogueMessage) 
        {
            dialogueUIText.text += letter;
            if(!char.IsWhiteSpace(letter)){
                audioManager.Play("DialogueVoice");
            }
            yield return new WaitForSeconds(talkingSpeed); 
        }
        yield return new WaitForSeconds(pauseSpeed); //pauses after very completed sentence
        isActive = false;
        dialogueBoxUI.SetActive(false);
        dialogueUIText.text = string.Empty;
    }
}
