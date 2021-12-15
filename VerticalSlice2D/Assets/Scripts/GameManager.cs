using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject heartMinigameHolder;
    [SerializeField] private float heartMinigameDuration = 5f;

    private int currentActionIndex = -1;
    private float lastHeartMinigameTime = 0;

    private void Update()
    {
        HeartMinigameTimer();
    }

    private void HeartMinigameTimer()
    {
        if (heartMinigameHolder.activeSelf)
        {
            if (Time.time >= lastHeartMinigameTime + heartMinigameDuration)
            {
                StopHeartMinigame();
            }
        }
    }

    public void DoNextAction()
    {
        List<ActionSaveManager.Action> actions = FindObjectOfType<ActionSaveManager>().GetActions();

        currentActionIndex++;

        if(currentActionIndex == actions.Count + 1)
        {
            ActionsDone();
            return;
        }

        if (currentActionIndex == actions.Count)
        {
            StartHeartMinigame();
            return;
        }

        ActionSaveManager.Action action = actions[currentActionIndex];

        switch(action.actionType)
        {
            case ActionSaveManager.ActionType.Fight:
                //Start fight script
                StartCoroutine(FindObjectOfType<CombatLogic>().StartCombat());
                break;
            case ActionSaveManager.ActionType.SoftVoice:
                //Set all enemy mergy 100%
                foreach (GameObject currentEnemy in FindObjectOfType<EnemyMenu>().GetAllEnemies())
                {
                    currentEnemy.GetComponent<Mercy>().AddMercy(100);
                }
                DoNextAction();
                break;
            case ActionSaveManager.ActionType.Spare:
                //if mercy is 100% then kill enemy
                GameObject enemy = action.enemyObject;
                if (enemy.GetComponent<Mercy>().GetCurrentMercy() >= 100)
                {
                    enemy.GetComponent<Health>().Spare();
                }
                DoNextAction();
                break;
            case ActionSaveManager.ActionType.Defend:
                //Set higher defense here
                // +16 tp and 50% damage reduction
                FindObjectOfType<TPBar>().AddTp(16);
                GameObject.FindGameObjectWithTag(action.playerName).GetComponent<Health>().SetDamageReduction(50);
                DoNextAction();
                break;
            default:
                DoNextAction();
                break;
        }
    }

    public GameObject GetCurrentEnemy()
    {
        return FindObjectOfType<ActionSaveManager>().GetActions()[currentActionIndex].enemyObject;
    }

    private void ActionsDone()
    {
        //Remove all damage reductions
        foreach(Health playerHealth in FindObjectsOfType<Health>())
        {
            playerHealth.ResetDamageReduction();
        }

        FindObjectOfType<ActionSaveManager>().ResetActions();
        currentActionIndex = -1;

        FindObjectOfType<PlayerSelector>().NextPlayer();
    }

    public void ActionDone()
    {
        DoNextAction();
    }

    private void Spare()
    {

    }

    private void StartHeartMinigame()
    {
        lastHeartMinigameTime = Time.time;

        heartMinigameHolder.SetActive(true);
        FindObjectOfType<HeartMovement>().ResetPosition();

        FindObjectOfType<HeartCollisions>().SetRandomTarget();

        //Start enemy attacks
        FindObjectOfType<BallAttack>().StartAttack();
    }

    private void StopHeartMinigame()
    {
        //Stop enemy attack
        FindObjectOfType<BallAttack>().StopAttack();

        heartMinigameHolder.SetActive(false);

        DoNextAction();
    }
}
