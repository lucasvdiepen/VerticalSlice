using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [HideInInspector] public int curHealth = 0;
    public int maxHealth = 100;
    [HideInInspector] public float damageReduction;
    private bool isDead = false;

    private void Start()
    {
        curHealth = maxHealth;
    }

    private void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(10);
        }*/
    }

    public void TakeDamage(int damage)
    {
        float reduction = 100 - damageReduction;

        float damageToDeal = damage * reduction * 0.01f;

        curHealth -= Convert.ToInt32(damageToDeal);

        HandleTakeDamage();

        if (curHealth <= 0)
        {
            HandleDeath();
        }
    }

    public bool IsDead()
    {
        return isDead;
    }

    public void SetDamageReduction(float amount)
    {
        damageReduction = amount;
    }

    public void ResetDamageReduction()
    {
        damageReduction = 0;
    }

    protected virtual void HandleTakeDamage()
    {
        
    }

    protected virtual void HandleDeath()
    {
        isDead = true;

        Debug.Log("Handle death called");
    }
}