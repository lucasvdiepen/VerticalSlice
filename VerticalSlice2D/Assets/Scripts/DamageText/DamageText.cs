using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageText : MonoBehaviour
{
    [SerializeField] private Canvas canvasToSpawn;
    [SerializeField] private GameObject textHolder;
    [SerializeField] private TextMeshProUGUI damageTextPrefab;
    public void CreateDamageText(float damage, Vector3 spawnPos, Color textColor) {
       GameObject textHolder_ = Instantiate(textHolder, transform.position, Quaternion.identity);
        TextMeshProUGUI displayText = Instantiate(damageTextPrefab, spawnPos, Quaternion.identity);
        displayText.transform.SetParent(textHolder_.transform);
        textHolder_.transform.SetParent(canvasToSpawn.transform);
        displayText.GetComponent<RectTransform>().anchoredPosition = spawnPos;
        textHolder_.GetComponent<RectTransform>().anchoredPosition = spawnPos;
        displayText.color = textColor;
        displayText.text = damage.ToString();
    }
    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            CreateDamageText(120, new Vector3(0, 0, 0), Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f));
        }
    }
}