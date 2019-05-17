using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    [SerializeField]
    private float speed = 40f;
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private GameObject explosionEffect;
    public float maxReach;
    
    void Start()
    {
        rb.velocity = transform.up * speed * Time.deltaTime;
    }

    void Update()
    {
        ExplodeOnReach();
    }
    private void ExplodeOnReach()
    {
        if (transform.position.y*60>= maxReach)
        {
            Explode();
            Destroy(this.gameObject);
        }
    }

    private void Explode()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 1f);
        foreach (Collider2D nearbyObject in colliders)
        {
            BombRocketScript bms = nearbyObject.GetComponent<BombRocketScript>();
            if (bms != null)
            {
                bms.DestroyOnExplosion();
            }
        }
        Instantiate(explosionEffect, transform.position, transform.rotation);
    }
}
