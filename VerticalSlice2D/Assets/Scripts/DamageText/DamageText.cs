using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DamageText : MonoBehaviour
{
    [SerializeField] private Canvas canvasToSpawn;
    [SerializeField] private GameObject textHolder;
    [SerializeField] private TextMeshProUGUI damageTextPrefab;

    //example use case:
    //CreateDamageText(120, placeToSpawn.anchoredPosition, GetCorrectColor("ralsei"), 52);
    public void CreateDamageText(float damage, Vector3 rectTransformSpawnPos, Color textColor, float fontSize = 52) 
    {
        //offset for animation
        rectTransformSpawnPos += new Vector3(80, 0, 0);
        //empty gameObject for animation
        GameObject textHolder_ = Instantiate(textHolder, transform.position, Quaternion.identity);
        TextMeshProUGUI displayText = Instantiate(damageTextPrefab, rectTransformSpawnPos, Quaternion.identity);
        //setting the text component parent to the empty gameobject and to the canvas
        displayText.transform.SetParent(textHolder_.transform);
        textHolder_.transform.SetParent(canvasToSpawn.transform);
        //setting the correct position
        displayText.GetComponent<RectTransform>().anchoredPosition = rectTransformSpawnPos;
        textHolder_.GetComponent<RectTransform>().anchoredPosition = rectTransformSpawnPos;
        //using the damage text settings
        displayText.color = textColor;
        displayText.fontSize = fontSize;
        displayText.text = damage.ToString();
    }

    public Color GetCorrectColor(string character) 
    {
        //susie 255, 0, 223, 255
        //kris 44, 198, 225, 255
        //ralsei 21, 255, 0, 255
        character.ToLower();
        Color result = Color.white;
        switch (character) 
        {
            case "kris":
                result = new Color32(44, 198, 225, 255);
                break;
            case "susie":
                result = new Color32(255, 0, 223, 255);
                break;
            case "ralsei":
                result = new Color32(21, 255, 0, 255);
                break;
            default:
                Debug.LogError("Please only use color characte: 'kris', 'susie or 'ralsei'", this);
                result = Color.black;
                break;
        }
        return result;
    }
}