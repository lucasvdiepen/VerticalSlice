using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMenu : Menu
{
    public GameObject[] enemies;

    public override void ExecuteButton()
    {
        FindObjectOfType<ActionSaveManager>().AddEnemyTarget(enemies[selectedButton]);
    }
}
