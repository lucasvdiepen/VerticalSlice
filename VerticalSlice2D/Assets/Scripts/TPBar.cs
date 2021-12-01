using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TPBar : MonoBehaviour
{
    private float startingY;
    [SerializeField] private TextMeshProUGUI TPText;

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
            TPText.text = "<i>T\nP\n</i>" + player.TP.ToString() + "\n%";
        }
       
        if (player.TP >= 100)
        {
            TPText.text = "<i>T\nP\n</i>" + "<color=yellow>M\n A\n  X</color>";
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
