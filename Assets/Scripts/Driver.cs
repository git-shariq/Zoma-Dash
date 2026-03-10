using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 70.00f;
    [SerializeField] float moveSpeed = 5.00f;
    [SerializeField] float slowSpeed = 3f;
    [SerializeField] float boostSpeed = 30f;

    [SerializeField] float fuelAmount = 100f;
    [SerializeField] float maxFuel = 100f;
    [SerializeField] float fuelConsumptionRate = 5f;
    [SerializeField] float boostFuelConsumptionRate = 15f;

    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveInput = Input.GetAxis("Vertical");
        float moveAmount = 0;

        if (fuelAmount > 0)
        {
            if (moveInput != 0)
            {
                if (moveSpeed == boostSpeed)
                {
                    fuelAmount -= boostFuelConsumptionRate * Time.deltaTime;
                }
                else
                {
                    fuelAmount -= fuelConsumptionRate * Time.deltaTime;
                }
            }
            moveAmount = moveInput * moveSpeed * Time.deltaTime;
        }

        fuelAmount = Mathf.Clamp(fuelAmount, 0, maxFuel);
        
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }
    
    void OnCollisionEnter2D(Collision2D other)
    {
        moveSpeed = slowSpeed;
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Boost")
        {
            moveSpeed = boostSpeed;
        }
    }

    public float GetSpeed()
    {
        // Only show speed if there is fuel
        if (fuelAmount > 0)
        {
            return Mathf.Abs(Input.GetAxis("Vertical") * moveSpeed);
        }
        return 0;
    }

    public float GetFuelFraction()
    {
        return fuelAmount / maxFuel;
    }

    public void Refuel()
    {
        fuelAmount = maxFuel;
    }
}
