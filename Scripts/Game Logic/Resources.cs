using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable] public class Resources
{
    public int stars;

    public bool SpendStars(int starsToSpend)
    {
        if (starsToSpend <= stars)
        {
            stars -= starsToSpend;
            return true;
        }
        else return false;
    }

    public void AddStars(int starsToAdd)
    {
        stars += starsToAdd;
    }

}
