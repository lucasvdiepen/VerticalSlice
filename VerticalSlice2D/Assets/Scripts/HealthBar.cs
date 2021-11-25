using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

	public Slider slider;
	public Gradient gradient;
	public Image fill;

	public void SetMaxHealth(int health, int maxHealth)
	{
		slider.value = health / maxHealth * 100;

		fill.color = gradient.Evaluate(1f);
	}

	public void SetHealth(float health, float maxHealth)
	{
		slider.value = health / maxHealth * 100;

		fill.color = gradient.Evaluate(slider.normalizedValue);
	}

}