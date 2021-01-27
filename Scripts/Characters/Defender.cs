using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] private int defenderCost = 20;
    [SerializeField] private int defenderHealth = 100;

    public int GetDefenderPrice()
    {
        return defenderCost;
    }

    public int GetDefenderHealth()
    {
        return defenderHealth;
    }

}
