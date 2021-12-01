using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkSelfDestruct : MonoBehaviour
{
    //this function is called as a animation event so we know when the blinking
    //combatslider should be destroyed
    public void SelfDestruct() 
    {
        Destroy(gameObject);
    }
}
