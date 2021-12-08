using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartInvisibility : MonoBehaviour
{
    [SerializeField] private float defaultInvisibilityTime = 1.5f;

    private bool isInvisible = false;
    private float lastInvisibleTime = 0;
    private float invisibiltyTime = 0;
    private HeartDamageAnimation heartDamageAnimation;

    private void Start()
    {
        heartDamageAnimation = GetComponent<HeartDamageAnimation>();
    }

    private void Update()
    {
        CheckInvisibilityTime();
    }

    private void CheckInvisibilityTime()
    {
        if(isInvisible)
        {
            if(Time.time >= lastInvisibleTime + invisibiltyTime)
            {
                DisableInvisibility();
            }
        }
    }

    public void EnableInvisibility()
    {
        EnableInvisibility(defaultInvisibilityTime);
    }

    public void EnableInvisibility(float time)
    {
        lastInvisibleTime = Time.time;
        invisibiltyTime = time;
        isInvisible = true;
        heartDamageAnimation.EnableDamageAnimation();
        
    }

    public void DisableInvisibility()
    {
        isInvisible = false;
        heartDamageAnimation.DisableDamageAnimation();
    }

    public bool IsInvisible()
    {
        return isInvisible;
    }
}
