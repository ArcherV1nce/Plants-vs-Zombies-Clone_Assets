using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesController : MonoBehaviour
{
    [SerializeField] private Resources resources;

    public int ResourcesGetStars()
    {
        return resources.stars;
    }

    public bool ResourcesSpendStars(int stars)
    {
        return resources.SpendStars(stars);
    }

    public void ResourcesAddStars(int stars)
    {
        resources.AddStars(stars);
    }

}
