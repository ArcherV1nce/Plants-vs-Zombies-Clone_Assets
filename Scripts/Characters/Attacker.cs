using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Attacker : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] 
    //[Range(0f, 6f)] private float movementSpeed = 1f;
    [Range(0f, 6f)] private float currentSpeed = 1f;
    [SerializeField] [Range(0, 15)] private int starsValue = 1;
    //private enum state {spawn, walk, attack};
    [SerializeField] private int state = 1;

    [Header("Debug")]
    [SerializeField] private AttackerSpawner spawner = null;
    [SerializeField] private GameObject currentTarget = null;

    private void Awake()
    {
        starsValue = UnityEngine.Random.Range(1,5);
    }

    public void SetMovementSpeed(float speed)
    {
        currentSpeed = speed;
    }

    private void Update()
    {
        if (state == 1)
        { 
            transform.Translate(Vector2.left
                *  currentSpeed * Time.deltaTime);
        }
    }

    public int GetRewardOnDestroy()
    {
        return starsValue;
    }

    public void Attack(GameObject target)
    {
        GetComponent<Animator>().SetBool("isAttacking", true);
        currentTarget = target;
    }

    public void SetAnimatorToSpawned()
    {
        GetComponent<Animator>().SetBool("finishedSpawning", true);
    }

    public void SetSpawner(AttackerSpawner spawner)
    {
        this.spawner = spawner;
    }

    public void RemoveAtacker()
    {
        spawner.RemoveAttackerFormList(this);
    }

}
