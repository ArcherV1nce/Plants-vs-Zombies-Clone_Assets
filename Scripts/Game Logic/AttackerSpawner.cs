﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] private bool spawning = true;
    [SerializeField] private float minSpawnDelay = 1f;
    [SerializeField] private float maxSpawnDelay = 5f;
    [SerializeField] private ResourcesController resourcesController;
    [SerializeField] private string lineName = "Line ";

    [Header("Objects")]
    [SerializeField] private Attacker atackerPrefab = null;

    [Header("Debug")]
    [SerializeField] private List<Attacker> enemiesSpawnedOnLine = null;

    private void Awake()
    {
        resourcesController = FindObjectOfType<ResourcesController>();
    }

    private void Start()
    {
        StartCoroutine(SpawnAtacker());
    }

    private IEnumerator SpawnAtacker()
    {
        yield return new WaitUntil(() => spawning);
        while(spawning)
        {
            if (atackerPrefab != null)
            {
                Attacker atk = Instantiate(atackerPrefab, transform.position, transform.rotation);
                atk.GetComponent<Health>().SetResourcesController(resourcesController);
                enemiesSpawnedOnLine.Add(atk);
                atk.SetSpawner(this);
                atk.transform.parent = transform;
            }
            
            yield return new WaitForSeconds
                (UnityEngine.Random.Range(minSpawnDelay, maxSpawnDelay));
        }
        /*this.StopCoroutine(SpawnAtacker());
         * Stop Coroutine without destroying gameObject.
         */
    }

    public void RemoveAttackerFormList(Attacker atk)
    {
        enemiesSpawnedOnLine.Remove(atk);
    }

    public string GetLineName()
    {
        return lineName;
    }

    public bool IsAttackOngoing()
    {
        if (enemiesSpawnedOnLine.Count < 1)
        {
            return false;
        }
        else return true;

        //Alternative way to do it
        /*
        if (transform.childCount < 1)
        {
            return false;
        }
        else return true;
        */

    }

    public void StartSpawning()
    {
        spawning = true;
    }

    public void StopSpawning ()
    {
        spawning = false;
    }

}
