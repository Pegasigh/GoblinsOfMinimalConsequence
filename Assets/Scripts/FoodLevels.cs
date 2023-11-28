using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FoodLevels : MonoBehaviour
{
    [SerializeField]
    private int foodLevel;

    void AddFood(int foodvalue)
    {
        
        foodLevel += foodvalue;
    }

    void SubtractFood(int foodvalue)
    {
        
        foodLevel -= foodvalue;
        if (foodLevel < 0) { foodLevel = 0; }
        
    }

    


}
