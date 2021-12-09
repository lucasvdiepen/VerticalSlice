using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActSelectionLogic : MonoBehaviour
{
    public GameObject[] heartIcons;
    public GameObject menuHolder;
    private int selectedButton = 0;
    private bool canInteract = false;

    public void OpenMenu()
    {
        menuHolder.SetActive(true);
        canInteract = true;
    }

    public void CloseMenu()
    {
        menuHolder.SetActive(false);
        canInteract = false;
    }

    private void Update()
    {
        RunInput();
    }

    private void RunInput()
    {
        if(canInteract)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (selectedButton - 2 >= 0) selectedButton -= 2;
                UpdateButtonSprite();
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (selectedButton + 2 < heartIcons.Length) selectedButton += 2;
                UpdateButtonSprite();
            }

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (selectedButton - 1 >= 0) selectedButton -= 1;
                UpdateButtonSprite();
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (selectedButton + 1 < heartIcons.Length) selectedButton += 1;
                UpdateButtonSprite();
            }

            if (Input.GetKeyDown(KeyCode.Space)) ExecuteButton();
        }
    }

    public void UpdateButtonSprite()
    {
        for(int i = 0; i < heartIcons.Length; i++)
        {
            if (i == selectedButton) heartIcons[i].SetActive(true);
            else heartIcons[i].SetActive(false);
        }
    }

    public void ExecuteButton()
    {
        switch(selectedButton)
        {
            case 3:
                CloseMenu();
                FindObjectOfType<ActionSaveManager>().ChangeCurrentPlayerAction(ActionSaveManager.ActionType.SoftVoice);
                break;
        }
    }
}
