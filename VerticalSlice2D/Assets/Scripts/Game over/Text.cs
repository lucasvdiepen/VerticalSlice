using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text : MonoBehaviour
{
    float timeLeft = 3f;

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0.1f & timeLeft >= 0.09f)
        {
            FindObjectOfType<DialogueLogic>().StartDialogue();
        }
        if (timeLeft <= -6.5f)
        {
            FindObjectOfType<GameOverMenu>().OpenMenu();
        }
    }
}