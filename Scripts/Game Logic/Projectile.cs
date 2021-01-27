using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] private float speed = 1.5f;
    [SerializeField] private int damage = 100;
    [SerializeField] 
    [Range(0.1f, 10f)] private float lifeTime = 3f;
    [SerializeField] private bool isPenetrating = false;
    [SerializeField] private List<string> damageReciverTag
        = new List<string>();

    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        //Debug.Log("I've hit " + otherCollider.tag);
        if(damageReciverTag.Contains(otherCollider.tag)) 
        {
            Health colliderObjectHealth = otherCollider.GetComponent<Health>();

            if (colliderObjectHealth != null)
            {
                colliderObjectHealth.ReciveDamage(damage);
                if (!isPenetrating) 
                { Destroy(gameObject); }
            }
        }
    }

    public void SetUpProjectile(int damage, List<string> damageRecieverTags)
    {
        this.damage = damage;
        this.damageReciverTag = damageRecieverTags;
    }

}
