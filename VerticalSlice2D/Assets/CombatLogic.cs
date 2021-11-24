using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatLogic : MonoBehaviour
{
    private Vector2 movement;
    private Rigidbody2D[] rb2ds;
    [HideInInspector] public bool isInCombat = false;
    [SerializeField] private GameObject[] sliders;
    [SerializeField] private Transform[] spawnPositions;
    [SerializeField] private float moveSpeed;
    private void Awake() {
        for (int i = 0; i < rb2ds.Length; i++) 
        {
            rb2ds[i] = sliders[i].GetComponent<Rigidbody2D>();
        }
    }
    public void StartCombat() 
    {
        isInCombat = true;
        for (int i = 0; i < sliders.Length; i++) 
        {
            sliders[i].SetActive(true); 
            sliders[i].transform.position = spawnPositions[i].position;
        }
    }
    private void FixedUpdate() 
    {
        movement = new Vector2(-moveSpeed, 0);
        if (isInCombat && sliders[0] != null && sliders[1] != null) 
        {
            rb2ds[0].MovePosition(rb2ds[0].position + movement * moveSpeed * Time.fixedDeltaTime);
            rb2ds[1].MovePosition(rb2ds[1].position + movement * moveSpeed * Time.fixedDeltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            StartCombat();
        }
    }
}
