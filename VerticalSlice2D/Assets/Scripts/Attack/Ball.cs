using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float height = 5f;
    private Vector2 target;
    private float startTime;
    private float timeToReachTarget;
    private bool projectileStarted;
    private Vector3 startPosition;
    private float timeElapsed = 0f;
    private Vector3 lastPosition;
    private Vector3 diff;

    public void StartProjectile(Vector2 target, float time)
    {
        this.target = target;
        timeToReachTarget = time;
        startTime = Time.time;
        projectileStarted = true;
        startPosition = transform.position;
    }

    private void Start()
    {
        StartProjectile(new Vector2(-1, -1), 3f);
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (projectileStarted)
        {
            if(timeElapsed / timeToReachTarget >= 1)
            {
                if(diff == null) diff = transform.position - lastPosition;

                transform.position = transform.position + diff * timeToReachTarget;
            }
            else
            {
                lastPosition = transform.position;
                Vector3 newPosition = Parabola(startPosition, target, height, timeElapsed / timeToReachTarget);
                transform.position = newPosition;
                timeElapsed += Time.deltaTime;
            }
        }
    }

    private Vector3 Parabola(Vector3 start, Vector3 end, float height, float t)
    {
        Func<float, float> f = x => -4 * height * x * x + 4 * height * x;

        var mid = Vector3.Lerp(start, end, t);

        return new Vector3(mid.x, f(t) + Mathf.Lerp(start.y, end.y, t), mid.z);
    }
}
