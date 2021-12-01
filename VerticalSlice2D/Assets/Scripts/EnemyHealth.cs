using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{
    protected override void HandleTakeDamage()
    {
        base.HandleTakeDamage();
        //Run "damaged"
        //Slider

    }

    protected override void HandleDeath()
    {
        base.HandleDeath();
        //Run "run away" animatie
        //Run "mercy" animatie
        //Deactivate enemy
    }
}
