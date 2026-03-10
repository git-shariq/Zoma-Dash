using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelStation : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Driver driver = other.GetComponent<Driver>();
        if (driver != null)
        {
            driver.Refuel();
            Destroy(gameObject); // The fuel station disappears after use
        }
    }
}
