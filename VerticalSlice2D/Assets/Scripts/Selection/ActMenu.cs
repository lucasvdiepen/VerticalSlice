using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActMenu : Menu
{
    public override void RunInput()
    {
        base.RunInput();

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
        }
    }

    public override void ExecuteButton()
    {
        switch (selectedButton)
        {
            case 3:
                FindObjectOfType<ActionSaveManager>().ChangeCurrentPlayerAction(ActionSaveManager.ActionType.SoftVoice);
                CloseMenu();
                FindObjectOfType<PlayerSelector>().NextPlayer();
                break;
        }
    }
}
