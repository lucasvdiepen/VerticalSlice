using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartCollisions : MonoBehaviour
{
    private bool isInvisible = false;
    private float lastInvisibleTime = 0;
    private float invisibiltyTime = 0;

    private void Update()
    {
        
    }

    public void EnableInvisibility(float time)
    {
        lastInvisibleTime = Time.time;
    }

    public void DisableInvisibility()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Ball")
        {

        }
    }
}
