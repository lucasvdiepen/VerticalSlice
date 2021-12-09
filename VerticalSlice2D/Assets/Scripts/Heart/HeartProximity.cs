using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartProximity : MonoBehaviour
{
    [SerializeField] private float fadeTime = 0.4f;
    [SerializeField] private float showTime = 1f;
    [SerializeField] private float proximityRange = 0.25f;
    [SerializeField] private SpriteRenderer heartLine;
    [SerializeField] private LayerMask bulletsLayer;

    private bool isFading = false;
    private bool isWaitingForHide = false;
    private float timeElapsed = 0;
    private float lastShowTime = 0;

    private void Update()
    {
        CheckNearbyBullets();

        CheckWaitingForHide();
        CheckFade();
    }

    private void CheckNearbyBullets()
    {
        Collider2D[] nearbyBullets = Physics2D.OverlapCircleAll(transform.position, proximityRange, bulletsLayer);
        if (nearbyBullets.Length > 0) ShowLine();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, proximityRange);
    }

    public void ShowLine()
    {
        heartLine.gameObject.SetActive(true);
        heartLine.color = new Color(1f, 1f, 1f, 1f);
        lastShowTime = Time.time;
        isFading = false;
        isWaitingForHide = true;
    }

    private void HideLine()
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
                isWaitingForHide = false;
                HideLine();
            }
        }
    }

    private void CheckFade()
    {
        if(isFading)
        {
            timeElapsed += Time.deltaTime;
            heartLine.color = new Color(1f, 1f, 1f, Mathf.Lerp(1f, 0f, timeElapsed / fadeTime));
            if(timeElapsed >= fadeTime)
            {
                isFading = false;
            }
        }
    }
}
