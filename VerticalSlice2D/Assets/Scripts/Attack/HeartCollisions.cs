using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartCollisions : MonoBehaviour
{
    private HeartInvisibility heartInvisibility;

    private void Start()
    {
        heartInvisibility = GetComponent<HeartInvisibility>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Ball")
        {
            if(!heartInvisibility.IsInvisible())
            {
                //Deal damage here

                heartInvisibility.EnableInvisibility();

                Destroy(collision.gameObject);
            }

            
        }
    }
}
