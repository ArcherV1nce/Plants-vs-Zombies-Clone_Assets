using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender_Cactus : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] private Transform muzzlePos = null;
    [SerializeField] private int damage = 100;
    [SerializeField]
    private List<string> damageReciverTag
        = new List<string> { "Attacker"};
    //[SerializeField] private Vector2 shootingMuzzlePosition;
    [SerializeField] private AttackerSpawner lineSpawner = null;

    [Header("Objects")]
    [SerializeField] private GameObject projectile = null;

    private void Awake()
    {
        SetLaneSpawner();
    }

    private void Update()
    {
        if(lineSpawner.IsAttackOngoing())
        {
            //Debug.Log("Pew-Pew");
            this.GetComponent<Animator>().SetBool("isAttacking", true);
        }
        else
        {
            this.GetComponent<Animator>().SetBool("isAttacking", false);
            //Debug.Log("On line " + lineSpawner.GetLineName() + " I rest.");
        }
    }

    private void SetLaneSpawner()
    {
        AttackerSpawner[] attackerSpawners;

        attackerSpawners = FindObjectsOfType<AttackerSpawner>();

        foreach(AttackerSpawner aS in attackerSpawners)
        {
            bool isCloseByEpsilon =
                (Mathf.Abs (aS.transform.position.y - transform.position.y)
                <= Mathf.Epsilon);
            if(isCloseByEpsilon)
            {
                lineSpawner = aS;
            }
        }
    }

    public void Shoot()
    {
        Instantiate(projectile, muzzlePos.position, transform.rotation).
            GetComponent<Projectile>().SetUpProjectile(damage, damageReciverTag);
    }

}
