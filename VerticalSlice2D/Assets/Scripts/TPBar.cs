using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPBar : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void updateSprite()
    {
        RectTransform sprite1 = GameObject.Find("TPBarFull").GetComponent<RectTransform>();
        GameObject thePlayer = GameObject.Find("Player");
        Player playerScript = thePlayer.GetComponent<Player>();

        sprite1.sizeDelta = new Vector2(28, Mathf.RoundToInt((float)(2.79 * playerScript.TP)));
    }

    // Update is called once per frame
    void Update()
    {
        updateSprite();   
    }
}
