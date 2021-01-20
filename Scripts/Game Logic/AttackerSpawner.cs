using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] private bool spawning = true;
    [SerializeField] private float minSpawnDelay = 1f;
    [SerializeField] private float maxSpawnDelay = 5f;
    [Header("Objects")]
    [SerializeField] private Attacker atackerPrefab = null;

    private void Start()
    {
        StartCoroutine(SpawnAtacker());
    }

    private IEnumerator SpawnAtacker()
    {
        while(spawning)
        {
            if (atackerPrefab != null)
            {
                Instantiate(atackerPrefab, transform.position, transform.rotation);
            }
            
            yield return new WaitForSeconds
                (UnityEngine.Random.Range(minSpawnDelay, maxSpawnDelay));
        }
        /*this.StopCoroutine(SpawnAtacker());
         * Stop Coroutine without destroying gameObject.
         */
    }

}
