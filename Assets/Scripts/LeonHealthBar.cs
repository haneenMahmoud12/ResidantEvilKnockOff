using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class LeonHealthBar : MonoBehaviour
{
    //public InventoryScript inventory;
    public int health = 8;
    public Slider slider;

    private void Start()
    {
        slider.maxValue = 8;
        slider.minValue = 0;
        slider.value = health;
    }

    public void Health(int healthVal)
    {
        slider.value = healthVal;
    }

    /*public void HealthUp()
    {
        if (health < 8)
            health++;
        slider.value = health;
    }*/
}
