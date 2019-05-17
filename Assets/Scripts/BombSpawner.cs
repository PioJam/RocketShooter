
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject bombRocket;
    [SerializeField]
    private bool stopSpawning = false;
    [SerializeField]
    private float spawnTime;
    [SerializeField]
    private float spawnDelay;

    private void Start()
    {
        InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
    }

    public void SpawnObject()
    {
        Vector2 vector2 = new Vector2(Random.Range(4, 26), this.transform.position.y);
        ObjectPooler.Instance.SpawnFromPool("BombRocket", vector2, transform.rotation);
        if (stopSpawning)
        {
            CancelInvoke("SpawnObject");
        }
        transform.rotation = Quaternion.Euler(0, 0, Random.Range(150,210));
    }
}
