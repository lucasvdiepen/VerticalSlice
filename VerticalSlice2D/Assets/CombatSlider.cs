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
        combatLogic = FindObjectOfType<CombatLogic>();
        rect = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            if(hitNow) 
            {
                Debug.Log("<color=red>CRITICAL HIT</color>");
                combatLogic.SliderDied(gameObject);
            }
            else if(combatLogic.isInCombat && !hitNow) 
            {
                print("Normal hit");
                combatLogic.SliderDied(gameObject);
            }
        }
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
