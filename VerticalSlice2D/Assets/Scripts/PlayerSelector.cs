using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelector : MonoBehaviour
{
    [SerializeField] private GameObject[] players;

    private int currentPlayer = -1;
    private bool skippedPlayer = false;

    private void Start()
    {
        NextPlayer();
    }

    private void Update()
    {
        //for testing
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //NextPlayer();
        }
    }

    public void NextPlayer()
    {
        if(skippedPlayer)
        {
            skippedPlayer = false;
        }
        else
        {
            if(currentPlayer >= 0) players[currentPlayer].GetComponent<SelectionLogic>().CloseMenu();
        }

        currentPlayer++;

        if (currentPlayer >= players.Length)
        {
            PlayersDone();
            return;
        }

        SelectionLogic currentPlayerSelectionLogic = players[currentPlayer].GetComponent<SelectionLogic>();

        if (HasPlayerDoneAction(currentPlayerSelectionLogic.character))
        {
            skippedPlayer = true;
            NextPlayer();
            return;
        }

        //Open menu
        players[currentPlayer].GetComponent<SelectionLogic>().OpenMenu();
    }

    public void PlayersDone()
    {
        currentPlayer = -1;

        //Game manager can now process all actions
        FindObjectOfType<GameManager>().DoNextAction();
    }

    private bool HasPlayerDoneAction(string player)
    {
        List<ActionSaveManager.Action> actions = FindObjectOfType<ActionSaveManager>().actions;

        foreach(ActionSaveManager.Action action in actions)
        {
            if (action.playerName == player) return true;
        }

        return false;
    }
}