using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] private int healthPoints = 100;
    [SerializeField] private GameObject deathVFX = null;

    [Header("Debug")]
    [SerializeField] private ResourcesController resourcesController;


    public void ReciveDamage(int damage)
    {
        healthPoints -= damage;
        //Debug.Log(transform.name + "'s health = " + healthPoints);
        if(healthPoints <= 0)
        {
            if(deathVFX != null)
            {
                TriggerDeathVFX();
            }
            Destroy(gameObject);
        }
    }

    public void SetResourcesController(ResourcesController controller)
    {
        resourcesController = controller;
    }

    private void TriggerDeathVFX()
    {
        GameObject deathVFXObject = Instantiate(deathVFX, transform.position, Quaternion.identity);
        if(GetComponent<Attacker>())
        {
            resourcesController.ResourcesAddStars(GetComponent<Attacker>().GetRewardOnDestroy());
            GetComponent<Attacker>().RemoveAtacker();
        }
        Destroy(deathVFXObject, 2f);
    }
}
