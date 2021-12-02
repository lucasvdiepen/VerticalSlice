using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundWaveSpawner : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float spawnDelay = 0.05f;
    [SerializeField] private float soundWaveDelay = 3f;
    [SerializeField] private int soundWaves = 8;

    private bool isAttacking = false;
    private float lastSpawnTime = 0;
    private float lastSoundWaveSpawnTime = 0;
    private int soundWaveCount = 0;
    private Vector2 currentTarget;

    private void Start()
    {
        StartAttack();
    }

    public void StartAttack()
    {
        UpdateTarget();
        isAttacking = true;
    }

    public void StopAttack()
    {
        isAttacking = false;
    }

    private void Update()
    {
        HandleAttack();
    }

    private void UpdateTarget()
    {
        currentTarget = target.position;
    }

    private void HandleAttack()
    {
        if (isAttacking)
        {
            if(soundWaveCount >= soundWaves)
            {
                if(Time.time >= lastSoundWaveSpawnTime + soundWaveDelay)
                {
                    soundWaveCount = 0;
                    UpdateTarget();
                }
            }
            else
            {
                if(Time.time >= lastSpawnTime + spawnDelay)
                {
                    SpawnBullet();
                    soundWaveCount += 1;
                    lastSpawnTime = Time.time;
                    if(soundWaveCount >= soundWaves) lastSoundWaveSpawnTime = Time.time;
                }
            }
        }
    }

    private void SpawnBullet()
    {
        GameObject newBall = Instantiate(bullet, spawnPoint.position, Quaternion.identity);
        newBall.GetComponent<SoundWave>().StartSoundWave(currentTarget, speed);
    }
}
