using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FoodLevels : MonoBehaviour
{
    [SerializeField]
    private float foodLevel;

    void AddFood(float foodvalue)
    {
        
        foodLevel += foodvalue;
    }

    void SubtractFood(float foodvalue)
    {
        
        foodLevel -= foodvalue;
        if (foodLevel < 0.0f) { foodLevel = 0.0f; }
        
    }

    public float GetFoodLevels()
    {
        return foodLevel;
    }
}
