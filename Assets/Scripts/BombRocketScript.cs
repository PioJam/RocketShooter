using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BombRocketScript : MonoBehaviour, IPooledObject
{
    ObjectPooler objectPooler;
    [SerializeField]
    private float force = 100f;
    [SerializeField]
    private GameObject explosionEffect;

    private void Start()
    {
        objectPooler = ObjectPooler.Instance;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        Base baseObject = collision.GetComponent<Base>();
        if (baseObject != null)
        {
            baseObject.TakeDamage(10);
        }
        objectPooler.ReturnToPool("BombRocket",gameObject);
        Instantiate(explosionEffect, transform.position, transform.rotation);
    }

    public void OnObjectSpawn()
    {
        GetComponent<Rigidbody2D>().velocity = transform.up*Time.deltaTime*force;
    }
    public void DestroyOnExplosion()
    {
        objectPooler.ReturnToPool("BombRocket", gameObject);
        Instantiate(explosionEffect, transform.position, transform.rotation);
        FindObjectOfType<GameStatus>().AddToScore();
    }
}
