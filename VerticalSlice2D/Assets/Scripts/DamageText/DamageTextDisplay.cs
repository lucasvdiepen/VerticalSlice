using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTextDisplay : MonoBehaviour
{
    //used as a animation event to destroy the text when the animation is done
    public void DestroyText() 
    {
        Destroy(transform.parent.gameObject);
    }
}
