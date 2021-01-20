using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender_Cactus : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] private float health = 100f;
    [SerializeField] private Transform muzzlePos = null;
    //[SerializeField] private Vector2 shootingMuzzlePosition;
    

    [Header("Objects")]
    [SerializeField] private GameObject projectile = null;
    


    public void Shoot()
    {
        Instantiate(projectile, muzzlePos.position, transform.rotation);
    }
}
