using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] private int defenderCost = 20;
    [SerializeField] private int defenderHealth = 100;

    [Header("Debug")]
    [SerializeField] private ResourcesController resController = null;

    public int GetDefenderPrice()
    {
        return defenderCost;
    }

    public int GetDefenderHealth()
    {
        return defenderHealth;
    }

    public void SetResourcesController(ResourcesController controller)
    {
        resController = controller;
    }

    public void AddStars(int stars)
    {
        if(resController)
        {
            resController.ResourcesAddStars(stars);           
        }
    }
}
