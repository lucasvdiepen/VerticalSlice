using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class CombatLogic : MonoBehaviour
{
    private Vector2 movement;
    private int deadSliderCount;
    public GameObject test;
    [HideInInspector] public bool isInCombat = false;
    [SerializeField] private GameObject[] sliders;
    [SerializeField] private Transform[] spawnPositions;
    [SerializeField] private Vector2 spawnArea;
    [SerializeField] private float moveSpeed;
    public void StartCombat() {
        isInCombat = true;
        for (int i = 0; i < sliders.Length; i++) {
            sliders[i].SetActive(true);
            sliders[i].transform.position = spawnPositions[i].position + new Vector3(UnityEngine.Random.Range(0, 10), 0, 0);
        }
    }
    private void Update() 
    {
        movement = new Vector2(-moveSpeed, 0);
        if (isInCombat && sliders[0] != null && sliders[1] != null) 
        {
            sliders[0].transform.position = new Vector3(sliders[0].transform.position.x - moveSpeed * Time.deltaTime, sliders[0].transform.position.y, 0);
            sliders[1].transform.position = new Vector3(sliders[1].transform.position.x - moveSpeed * Time.deltaTime, sliders[1].transform.position.y, 0);
            sliders[2].transform.position = new Vector3(sliders[2].transform.position.x - moveSpeed * Time.deltaTime, sliders[2].transform.position.y, 0);
        }
        if (Input.GetKeyDown(KeyCode.Backspace) && !isInCombat) 
        {
            StartCombat();
        }
        if (Input.GetKeyDown(KeyCode.Space)) {
            try {
                GameObject obj = GetNearestSlider();
                obj.GetComponent<CombatSlider>().canHit = true;
                obj.GetComponent<CombatSlider>().checkHit();
            }
            catch {

            }
        }
    }

    public void SliderDied(GameObject slider) 
    {
        slider.SetActive(false);
        deadSliderCount++;
        if(deadSliderCount >= 3) 
        {
            isInCombat = false;
            for (int i = 0; i < sliders.Length; i++) 
            {
                sliders[i].transform.position = spawnPositions[i].position;
                deadSliderCount = 0;
            }
        }
    }
    public GameObject GetNearestSlider() {
        GameObject nearestSlider = null;
        for (int i = 0; i < sliders.Length; i++) {
            if (sliders[i].gameObject.activeSelf) {
                if (nearestSlider == null) {
                    nearestSlider = sliders[i];
                }
                else {
                    if (sliders[i].GetComponent<RectTransform>().anchoredPosition.x < nearestSlider.GetComponent<RectTransform>().anchoredPosition.x) {
                        nearestSlider = sliders[i];
                    }
                }
            }
        }
        test = nearestSlider;
        return nearestSlider;
    }
}
        
       

