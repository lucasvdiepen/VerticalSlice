using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelector : MonoBehaviour
{
    [SerializeField] private GameObject[] players;

    private int currentPlayer = -1;

    private void Start()
    {
        NextPlayer();
    }

    public void NextPlayer()
    {
        //players[currentPlayer].GetComponent<SelectionLogic>() Close menu

        currentPlayer++;
        SelectionLogic currentPlayerSelectionLogic = players[currentPlayer].GetComponent<SelectionLogic>();

        if (currentPlayer >= players.Length)
        {
            PlayersDone();
            return;
        }

        if (HasPlayerDoneAction(currentPlayerSelectionLogic.character))
        {
            NextPlayer();
            return;
        }

        //Open menu
    }

    public void PlayersDone()
    {
        currentPlayer = -1;

        //Game manager can now process all actions
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