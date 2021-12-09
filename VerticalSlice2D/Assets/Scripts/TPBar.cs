using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TPBar : MonoBehaviour
{
    public float tp = 0;
    private float startingY;
    [SerializeField] private TextMeshProUGUI tpText;
    [SerializeField] private GameObject orangeTPBar;
    [SerializeField] private GameObject max;
    [SerializeField] private GameObject tpPercentage;
    [SerializeField] Transform spriteMask;

    // Start is called before the first frame update
    private void Start()
    {   
        startingY = spriteMask.position.y;
    }

    private void UpdateSprite()
    {
        //this is very precise and hopefully still works after moving it please dont kill me
        spriteMask.position = new Vector2(spriteMask.position.x, startingY+(0.02805f*tp));
        //0.02805f is de sprite hoogte. Zodra wij sprites krijgen MOET DIT AANGEPAST WORDEN OM GOED TE WERKEN. Ik zou er een functie voor maken maar ik gebruik hier geen spriterenderer, dus kan ik niet de grootte aanroepen.
    }

    private void UpdateTextAndTp()
    {
        if (tp < 0)
        {
            tp = 0;
        }
        
        if (tp < 100)
        {
            tpText.text = tp.ToString();
            orangeTPBar.SetActive(true);
            max.SetActive(false);
            tpPercentage.SetActive(true);
        }
       
        if (tp >= 100)
        {
            tp = 100;
            tpText.text = "";
            orangeTPBar.SetActive(false);
            max.SetActive(true);
            tpPercentage.SetActive(false);
        }
    }

    public void AddTp(float amount)
    {
        tp += amount;
        UpdateTextAndTp();
        UpdateSprite();       
    }
    public void RemoveTp(float amount)
    {
        tp -= amount;
        UpdateTextAndTp();
        UpdateSprite();
    }
}
