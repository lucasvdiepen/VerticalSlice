using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatSlider : MonoBehaviour
{
    [HideInInspector]public bool canHit;
    private RectTransform rect;
    private CombatLogic combatLogic;
    [SerializeField] private GameObject blinkingSlider;
    [SerializeField] private Vector2 criticalPosition; //box to hit to get a critical hit
    public bool hitNow;

    private void Start()
    {
        //initial setup
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
                SliderHit(true);
            }
            else if (combatLogic.isInCombat && !hitNow) 
            {
                SliderHit(false);
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
    private void SliderHit(bool criticalHit) 
    {
        if (criticalHit) 
        {
            //Critical Hit! spawns a blinking slider 
            Debug.Log("<color=red>CRITICAL HIT</color>");
            GameObject blinker = Instantiate(blinkingSlider, transform.position, Quaternion.identity);
            blinker.GetComponent<Image>().color = Color.yellow;
            blinker.transform.SetParent(transform.parent);
            KillSlider();
        }
        else 
        {
            //Normal Hit! spawns a blinking slider 
            print("Normal hit");
            GameObject blinker = Instantiate(blinkingSlider, transform.position, Quaternion.identity);
            blinker.transform.SetParent(transform.parent);
            KillSlider();
        }
    }
    //this function is called when we manually want to destroy a slider
    private void KillSlider() 
    {
        combatLogic.SliderDied(gameObject);
    }
}
