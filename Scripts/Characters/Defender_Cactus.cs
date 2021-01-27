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


    [Header("Objects")]
    [SerializeField] private GameObject projectile = null;
    


    public void Shoot()
    {
        Instantiate(projectile, muzzlePos.position, transform.rotation).
            GetComponent<Projectile>().SetUpProjectile(damage, damageReciverTag);
    }

}
