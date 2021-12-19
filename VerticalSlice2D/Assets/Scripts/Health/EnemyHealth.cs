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
        FindObjectOfType<AudioManager>().Play("Damage");
    }

    protected override void HandleDeath()
    {
        base.HandleDeath();
        GetComponent<AnimationController>().Run();
        GetComponent<Animator>().enabled = false;
        FindObjectOfType<AudioManager>().Play("Run");
        //Run "run away" animatie
        //Run "mercy" animatie
        //Deactivate enemy
    }

    public void Spare()
    {
        FindObjectOfType<AudioManager>().Play("Mercy");

        HandleDeath();
    }
}
