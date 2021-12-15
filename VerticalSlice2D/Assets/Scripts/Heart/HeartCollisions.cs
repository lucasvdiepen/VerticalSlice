using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartCollisions : MonoBehaviour
{
    [SerializeField] private int damage;
    private HeartInvisibility heartInvisibility;
    private PlayerHealth target;

    private void Start()
    {
        heartInvisibility = GetComponent<HeartInvisibility>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Ball"))
        {
            if(!heartInvisibility.IsInvisible())
            {
                //Deal damage here
                DealDamage();

                heartInvisibility.EnableInvisibility();

                Destroy(collision.gameObject);
            }
        }
    }

    public void SetRandomTarget()
    {
        PlayerHealth[] healthScripts = FindObjectsOfType<PlayerHealth>();
        target = healthScripts[Random.Range(0, healthScripts.Length)];
    }

    private void DealDamage()
    {
        target.TakeDamage(damage);
    }
}
