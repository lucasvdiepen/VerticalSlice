using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TPBar : MonoBehaviour
{
    private float startingY;
    [SerializeField] private TextMeshProUGUI tpText;
    [SerializeField] private GameObject orangeTPBar;
    [SerializeField] private GameObject max;
    [SerializeField] private GameObject tpPercentage;

    // Start is called before the first frame update
    void Start()
    {
        Transform spriteMask = GameObject.Find("TPBar_Spritemask").GetComponent<Transform>();
        startingY = spriteMask.position.y;
    }

    void UpdateSprite()
    {
        GameObject thePlayer = GameObject.Find("Player");
        Player playerTP = thePlayer.GetComponent<Player>();
        Transform spriteMask = GameObject.Find("TPBar_Spritemask").GetComponent<Transform>();

        //this is very precise and hopefully still works after moving it please dont kill me
        spriteMask.position = new Vector2(spriteMask.position.x, startingY+(0.02805f*playerTP.TP));
        //0.02805f is de sprite hoogte. Zodra wij sprites krijgen MOET DIT AANGEPAST WORDEN OM GOED TE WERKEN. Ik zou er een functie voor maken maar ik gebruik hier geen spriterenderer, dus kan ik niet de grootte aanroepen.
    }

    void UpdateText()
    {
        
        GameObject thePlayer = GameObject.Find("Player");
        Player player = thePlayer.GetComponent<Player>();
        
        if (player.TP < 100)
        {
            tpText.text = player.TP.ToString();
            orangeTPBar.SetActive(true);
            max.SetActive(false);
            tpPercentage.SetActive(true);
        }
       
        if (player.TP >= 100)
        {
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
        UpdateText();
    }

    public void AddTP(float functionTP)
    {
        GameObject thePlayer = GameObject.Find("Player");
        Player playerTP = thePlayer.GetComponent<Player>();

        playerTP.TP = playerTP.TP + functionTP;
    }
}
