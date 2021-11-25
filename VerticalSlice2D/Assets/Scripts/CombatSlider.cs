using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatSlider : MonoBehaviour
{
    public bool canHit;
    private RectTransform rect;
    private CombatLogic combatLogic;
    private bool hitNow;
    [SerializeField] private Vector2 criticalPosition;
    // Start is called before the first frame update
    void Start()
    {
        canHit = false;
        combatLogic = FindObjectOfType<CombatLogic>();
        rect = GetComponent<RectTransform>();
    }
    public void checkHit() {
        if (canHit) {
            if (hitNow) {
                Debug.Log("<color=red>CRITICAL HIT</color>");
                combatLogic.SliderDied(gameObject);
            }
            else if (combatLogic.isInCombat && !hitNow) {
                print("Normal hit");
                combatLogic.SliderDied(gameObject);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(rect.anchoredPosition.x < criticalPosition.x && rect.anchoredPosition.x > criticalPosition.y) 
        {
            hitNow = true;
        }
        else  if(rect.anchoredPosition.x > criticalPosition.y)
        {
            hitNow = false; 
        }
        else 
        {
            combatLogic.SliderDied(gameObject);
        }
    }
}
