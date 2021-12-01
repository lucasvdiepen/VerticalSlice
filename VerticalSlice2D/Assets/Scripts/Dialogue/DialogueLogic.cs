using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueLogic : MonoBehaviour
{
    private bool isActive;
    [SerializeField] private GameObject dialogueBoxUI;
    [SerializeField] private TextMeshProUGUI dialogueUIText;
    [SerializeField] private Dialogue dialogueObj;
    [SerializeField] private float talkingSpeed, pauzeSpeed;

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
            yield return new WaitForSeconds(talkingSpeed); 
        }
        yield return new WaitForSeconds(pauzeSpeed); //pauses after very completed sentence
        isActive = false;
        dialogueBoxUI.SetActive(false);
        dialogueUIText.text = string.Empty;
    }
}
