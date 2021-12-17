using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallAttack : MonoBehaviour
{
    private Transform target;

    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject ball;

    [SerializeField] private float ballHeight;
    [SerializeField] private float timeToTarget;

    [SerializeField] private float spawnDelay;

    private bool isAttacking = false;
    private float lastSpawnTime = 0;

    private void Start()
    {
        //StartAttack();
    }

    public void StartAttack()
    {
        if(!GetComponent<Health>().IsDead())
        {
            target = GameObject.FindGameObjectWithTag("Heart").transform;
            isAttacking = true;
        }
    }

    public void StopAttack()
    {
        isAttacking = false;

        //Remove all bullets
        GameObject[] allBalls = GameObject.FindGameObjectsWithTag("Ball");

        for (int i = 0; i < allBalls.Length; i++)
        {
            Destroy(allBalls[i]);
        }
    }

    private void Update()
    {
        HandleAttack();
    }

    private void HandleAttack()
    {
        if(isAttacking)
        {
            if(Time.time >= lastSpawnTime + spawnDelay)
            {
                SpawnBall();
                lastSpawnTime = Time.time;
            }
        }
    }

    private void SpawnBall()
    {
        GameObject newBall = Instantiate(ball, spawnPoint.position, Quaternion.identity);
        newBall.GetComponent<Ball>().StartProjectile(target.position, ballHeight, timeToTarget);
    }
}
