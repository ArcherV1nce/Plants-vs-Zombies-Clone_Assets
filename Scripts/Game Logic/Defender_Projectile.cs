using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender_Projectile : MonoBehaviour
{
    [SerializeField] private float damage = 50f;
    [SerializeField] private float speed = 2f;

    private void Start()
    {
        this.gameObject.tag = "Defender_Projectile";
    }

    private void Update()
    {
        transform.Translate(Vector2.right * 
            speed * Time.deltaTime);
        
    }
}
