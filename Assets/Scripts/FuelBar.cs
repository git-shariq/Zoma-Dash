using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelBar : MonoBehaviour
{
    public Driver driver;
    public Image fuelBarFill; // Changed from RectTransform to Image

    void Update()
    {
        if (driver != null && fuelBarFill != null)
        {
            // Changed to use the fillAmount property of the Image component
            fuelBarFill.fillAmount = driver.GetFuelFraction();
        }
    }
}