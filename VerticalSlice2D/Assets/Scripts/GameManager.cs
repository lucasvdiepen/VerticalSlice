using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int currentActionIndex = -1;

    public void DoNextAction()
    {
        List<ActionSaveManager.Action> actions = FindObjectOfType<ActionSaveManager>().GetActions();

        currentActionIndex++;

        if(currentActionIndex >= actions.Count)
        {
            ActionsDone();
            return;
        }

        ActionSaveManager.Action action = actions[currentActionIndex];

        switch(action.actionType)
        {
            case ActionSaveManager.ActionType.Fight:
                //Start fight script
                break;
        }
    }

    private void ActionsDone()
    {
        FindObjectOfType<ActionSaveManager>().ResetActions();
        currentActionIndex = -1;
    }

    public void ActionDone()
    {
        DoNextAction();
    }
}
