using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerHealth : Health
{
    public TextMeshProUGUI healthText;
    public Slider slider;

    protected override void HandleTakeDamage()
    {
        base.HandleTakeDamage();
        healthText.text = curHealth.ToString() + " / " + maxHealth.ToString();
        slider.value = (float)curHealth / (float)maxHealth * 100;
        FindObjectOfType<AudioManager>().Play("Hurt");
    }

    protected override void HandleDeath()
    {
        base.HandleDeath();
        print("Erg dood");
    }
}
