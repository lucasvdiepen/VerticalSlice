using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartProximity : MonoBehaviour
{
    [SerializeField] private float fadeTime = 0.4f;
    [SerializeField] private float showTime = 1f;
    [SerializeField] private SpriteRenderer heartLine;

    private bool isFading = false;
    private bool isWaitingForHide = false;
    private float timeElapsed = 0;
    private float lastShowTime = 0;

    private void Update()
    {
        CheckFade();
    }

    public void ShowLine()
    {
        heartLine.gameObject.SetActive(true);
        heartLine.color = new Color(0, 0, 0, 1f);
        isFading = false;
        isWaitingForHide = true;
    }

    public void HideLine()
    {
        timeElapsed = 0;
        isFading = true;
    }

    private void CheckWaitingForHide()
    {
        if(isWaitingForHide)
        {
            if(Time.time >= lastShowTime + showTime)
            {

            }
        }
    }

    private void CheckFade()
    {
        if(isFading)
        {
            timeElapsed += Time.deltaTime;
            heartLine.color = new Color(0, 0, 0, Mathf.Lerp(1f, 0f, timeElapsed / fadeTime));
            if(timeElapsed >= fadeTime)
            {
                isFading = false;
            }
        }
    }
}
