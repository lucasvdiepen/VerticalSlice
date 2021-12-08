using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Mercy : MonoBehaviour
{
    public TextMeshProUGUI mercyText;
    public Slider slider;
    private int curMercy;
    public int maxMercy;

    public void Start()
    {
        slider.value = 0;
        UpdateText();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            slider.value = 100f;
            UpdateText();
        }
    }
    private void MercyBarFill()
    {
        UpdateText();
        slider.value = (float)curMercy / (float)maxMercy;
    }

    private void UpdateText()
    {
        mercyText.text = slider.value.ToString() + " % ";
    }
}
