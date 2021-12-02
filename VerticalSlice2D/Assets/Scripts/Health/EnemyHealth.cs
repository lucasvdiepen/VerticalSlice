using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class EnemyHealth : Health
{
    public TextMeshProUGUI healthText;
    public Slider slider;

    protected override void HandleTakeDamage()
    {

        base.HandleTakeDamage();
        //Run "damaged" animatie
        healthText.text = curHealth.ToString() + " % ";
        slider.value = (float)curHealth / (float)maxHealth * 100;
    }

    protected override void HandleDeath()
    {
        base.HandleDeath();
        //Run "run away" animatie
        //Run "mercy" animatie
        //Deactivate enemy
    }
}
