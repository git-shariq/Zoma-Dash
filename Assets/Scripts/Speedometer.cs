using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speedometer : MonoBehaviour
{
    public Driver driver;
    public Transform needle;

    public float maxSpeed = 40f; 
    public float minNeedleAngle = 135f;  
    public float maxNeedleAngle = -135f; 

    void Update()
    {
        if (driver != null && needle != null)
        {
            float speed = driver.GetSpeed();
            float speedFraction = Mathf.Clamp01(speed / maxSpeed);
            float needleAngle = Mathf.Lerp(minNeedleAngle, maxNeedleAngle, speedFraction);
            needle.localEulerAngles = new Vector3(0, 0, needleAngle);
        }
    }
}