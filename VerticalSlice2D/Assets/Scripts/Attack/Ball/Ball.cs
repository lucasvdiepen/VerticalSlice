using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private float height;
    private float timeToReachTarget;
    private float timeElapsed = 0f;
    private float speedAfterTrajectory;
    private bool projectileStarted;

    private Vector2 target;
    private Vector3 startPosition;
    private Vector3 lastPosition;
    private Vector3 diff;

    public void StartProjectile(Vector2 target, float height, float time, float speedAfterTrajectory)
    {
        this.target = target;
        this.speedAfterTrajectory = speedAfterTrajectory;
        this.height = height;
        timeToReachTarget = time;
        projectileStarted = true;
        startPosition = transform.position;
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
                transform.position += diff.normalized * speedAfterTrajectory * Time.deltaTime;
            }
            else
            {
                Vector3 newPosition = Parabola(startPosition, target, height, timeElapsed / timeToReachTarget);
                transform.position = newPosition;

                Vector3 newDiff = newPosition - lastPosition;
                if (newDiff != Vector3.zero)
                {
                    diff = newDiff;
                }

                lastPosition = newPosition;
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
