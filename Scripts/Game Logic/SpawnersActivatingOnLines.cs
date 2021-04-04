using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnersActivatingOnLines : MonoBehaviour
{
    [SerializeField] private AttackerSpawner[] 
        attackerSpawners = new AttackerSpawner[5];

    [SerializeField] [Range(1,5)] private int activeLinesStartCount = 2;
    [SerializeField] [Range(1,5)] private int activeLinesCount = 5;
    [SerializeField] private float activationDuration = 10f;
    [SerializeField] private int[] linesOrder = { 0, 1, 2, 3, 4};

    private void Awake()
    {
        for (int i = 0; i < linesOrder.Length; i++)
        {
            linesOrder[i] = i;
        }
        foreach(AttackerSpawner attackerSpawner in attackerSpawners)
        {
            attackerSpawner.StopSpawning();
        }
    }

    private void Start()
    {
        SetActivationQueue();
        StartCoroutine(ActivateLines());
    }

    private void SetActivationQueue()
    {
        //Debug for creating lines array
        /*
        foreach (int num in linesOrder)
        {
            Debug.LogWarning(num);
        }
        */
        Shuffler shuffler = new Shuffler();
        shuffler.Shuffle(linesOrder);
        
        //Debug for lines order
        /*
        foreach(int num in linesOrder)
        {
            Debug.LogWarning(num);
        }
        */
    }

    public class Shuffler
    {
        /// <summary>Creates the shuffler with a "MersenneTwister" as the random number generator.</summary>

        public Shuffler()
        {
            _rng = new System.Random();
        }

        /// <summary>Shuffles the specified array.</summary>
        /// <typeparam name="T">The type of the array elements.</typeparam>
        /// <param name="array">The array to shuffle.</param>

        public void Shuffle<T>(IList<T> array)
        {
            for (int n = array.Count; n > 1;)
            {
                int k = _rng.Next(n);
                --n;
                T temp = array[n];
                array[n] = array[k];
                array[k] = temp;
            }
        }

        private System.Random _rng;
    }

    private IEnumerator ActivateLines()
    {
        int lastActivated = 0;
        for(int i = 0; i < activeLinesStartCount; i++)
        {
            attackerSpawners[linesOrder[i]].StartSpawning();
            lastActivated = i;
        }
        yield return new WaitForSeconds(activationDuration);
        if (lastActivated < activeLinesCount - 1)
        {
            for (int i = lastActivated; i < activeLinesCount; i++)
            {
                attackerSpawners[linesOrder[i]].StartSpawning();
                lastActivated = i;
                yield return new WaitForSeconds(activationDuration);
            }
        }
    }
}
