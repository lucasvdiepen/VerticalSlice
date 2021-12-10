using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject heartMinigameHolder;

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
                StartCoroutine(FindObjectOfType<CombatLogic>().StartCombat());
                break;
            case ActionSaveManager.ActionType.Defend:
                //For testing heart minigame
                StartHeartMinigame();
                break;
        }
    }

    public GameObject GetCurrentEnemy()
    {
        return FindObjectOfType<ActionSaveManager>().GetActions()[currentActionIndex].enemyObject;
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

    private void StartHeartMinigame()
    {
        heartMinigameHolder.SetActive(true);
        FindObjectOfType<HeartMovement>().ResetPosition();

        //Start enemy attacks
    }

    private void StopHeartMinigame()
    {
        //Stop enemy attack

        //Remove all enemy bullets

        heartMinigameHolder.SetActive(false);
    }
}
