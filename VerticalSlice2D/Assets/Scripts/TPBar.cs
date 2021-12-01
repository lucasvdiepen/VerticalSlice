using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPBar : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void UpdateSprite()
    {
        //y = 0.715
        //y = 3.52
        Transform spriteMask = GameObject.Find("TPBar_Spritemask").GetComponent<Transform>();
        GameObject thePlayer = GameObject.Find("Player");
        Player playerTP = thePlayer.GetComponent<Player>();
        spriteMask.position = new Vector2(spriteMask.position.x, 0.16f+(0.02805f*playerTP.TP));

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
