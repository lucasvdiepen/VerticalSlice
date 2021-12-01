using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int curHealth = 0;
    public int maxHealth = 100;

    void Start()
    {
        curHealth = maxHealth;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(10);
        }
    }

    public void TakeDamage(int damage)
    {
        curHealth -= damage;

        HandleTakeDamage();

        if (curHealth <= 0)
        {
            HandleDeath();
        }
    }

    protected virtual void HandleTakeDamage()
    {
        
    }

    protected virtual void HandleDeath()
    {
        
    }
}