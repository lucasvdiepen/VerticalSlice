using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TPBar : MonoBehaviour
{
    public float TP = 0;
    private float startingY;
    [SerializeField] private TextMeshProUGUI tpText;
    [SerializeField] private GameObject orangeTPBar;
    [SerializeField] private GameObject max;
    [SerializeField] private GameObject tpPercentage;
    [SerializeField] Transform spriteMask;

    // Start is called before the first frame update
    void Start()
    {
        
        startingY = spriteMask.position.y;
    }

    void UpdateSprite()
    {
        Transform spriteMask = GameObject.Find("TPBar_Spritemask").GetComponent<Transform>();

        //this is very precise and hopefully still works after moving it please dont kill me
        spriteMask.position = new Vector2(spriteMask.position.x, startingY+(0.02805f*TP));
        //0.02805f is de sprite hoogte. Zodra wij sprites krijgen MOET DIT AANGEPAST WORDEN OM GOED TE WERKEN. Ik zou er een functie voor maken maar ik gebruik hier geen spriterenderer, dus kan ik niet de grootte aanroepen.
    }

    void UpdateTextAndTP()
    {

        if (TP < 0)
        {
            TP = 0;
        }
        
        if (TP < 100)
        {
            tpText.text = TP.ToString();
            orangeTPBar.SetActive(true);
            max.SetActive(false);
            tpPercentage.SetActive(true);
        }
       
        if (TP >= 100)
        {
            TP = 100;
            tpText.text = "";
            orangeTPBar.SetActive(false);
            max.SetActive(true);
            tpPercentage.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSprite();
        UpdateTextAndTP();
    }

    public void AddTP(float functionTP)
    {
        TP = TP + functionTP;
    }
}
