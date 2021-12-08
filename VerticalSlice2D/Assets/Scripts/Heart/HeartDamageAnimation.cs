using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartDamageAnimation : MonoBehaviour
{
    [SerializeField] private float colorChangeDelay = 0.5f;
    [SerializeField] private Color normalColor;
    [SerializeField] private Color damageColor;

    private SpriteRenderer heartImage;
    private bool animationIsPlaying = false;
    private bool isNormalColor = true;
    private float lastColorChangeTime = 0;

    private void Start()
    {
        heartImage = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        CheckChangeColor();
    }

    private void CheckChangeColor()
    {
        if(animationIsPlaying)
        {
            if(Time.time >= lastColorChangeTime + colorChangeDelay)
            {
                ChangeColor();
            }
        }
    }

    private void ChangeColor()
    {
        if (isNormalColor) SetDamageColor();
        else SetNormalColor();

        lastColorChangeTime = Time.time;
    }

    private void SetNormalColor()
    {
        heartImage.color = normalColor;
        isNormalColor = true;
    }

    private void SetDamageColor()
    {
        heartImage.color = damageColor;
        isNormalColor = false;
    }

    public void EnableDamageAnimation()
    {
        animationIsPlaying = true;
    }

    public void DisableDamageAnimation()
    {
        animationIsPlaying = false;
        SetNormalColor();
    }
}
