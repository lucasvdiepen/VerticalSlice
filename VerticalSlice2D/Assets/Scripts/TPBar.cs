using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPBar : MonoBehaviour
{
    public float startingY;
    // Start is called before the first frame update
    void Start()
    {
        Transform spriteMask = GameObject.Find("TPBar_Spritemask").GetComponent<Transform>();
        startingY = spriteMask.position.y;
    }

    void UpdateSprite()
    {
        Transform spriteMask = GameObject.Find("TPBar_Spritemask").GetComponent<Transform>();
        GameObject thePlayer = GameObject.Find("Player");
        Player playerTP = thePlayer.GetComponent<Player>();

        //this is very precise and hopefully still works after moving it please dont kill me
        spriteMask.position = new Vector2(spriteMask.position.x, startingY+(0.02805f*playerTP.TP));
        //0.02805f is de sprite hoogte. Zodra wij sprites krijgen MOET DIT AANGEPAST WORDEN OM GOED TE WERKEN. Ik zou er een functie voor maken maar ik gebruik hier geen spriterenderer, dus kan ik het niet oproepen.
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSprite();   
    }

    public void AddTP(float functionTP)
    {
        GameObject thePlayer = GameObject.Find("Player");
        Player playerTP = thePlayer.GetComponent<Player>();

        playerTP.TP = playerTP.TP + functionTP;
    }
}
