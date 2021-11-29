using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//shows how much health the player has on a sliding bar
public class HealthBar : MonoBehaviour
{

    // these variable make a slidable health bar
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void SetMaxHealth(int health)
    {
        //reset health
        slider.maxValue = health;
        slider.value = health;
        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(int health)
    {
        //set the amount of health on a bar
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }


}
