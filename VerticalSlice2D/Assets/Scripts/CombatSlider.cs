using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatSlider : MonoBehaviour
{
    public bool canHit;
    private RectTransform rect;
    private CombatLogic combatLogic;
    private bool hitNow;
    [SerializeField] private Vector2 criticalPosition; //box to hit to get a critical hit
    
    private void Start()
    {
        canHit = false;
        combatLogic = FindObjectOfType<CombatLogic>();
        rect = GetComponent<RectTransform>();
    }
    //checks what the slider hit
    public void CheckHit() 
    {
        if (canHit) 
        {
            if (hitNow) 
            {
                Debug.Log("<color=red>CRITICAL HIT</color>");
                combatLogic.SliderDied(gameObject);
            }
            else if (combatLogic.isInCombat && !hitNow) 
            {
                print("Normal hit");
                combatLogic.SliderDied(gameObject);
            }
        }
    }
    private void Update()
    {
        CriticalHitCheck();
    }

    //checks if slider is in the critical hit box
    private void CriticalHitCheck() 
    {
        //x = right side of the critical box and y = left side of the critical box
        if (rect.anchoredPosition.x < criticalPosition.x && rect.anchoredPosition.x > criticalPosition.y) 
        {
            hitNow = true;
        }
        else if (rect.anchoredPosition.x > criticalPosition.y) 
        {
            hitNow = false;
        }
        else 
        {
            combatLogic.SliderDied(gameObject);
        }
    }
}
