using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnApples : MonoBehaviour {
    float timeBetweenSpawn = 10f;
    float nextSpawnTime;

    private void Start()
    {
        SpawnApple();
        nextSpawnTime = Time.time + timeBetweenSpawn;
    }
    private void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            SpawnApple();
            nextSpawnTime = Time.time + timeBetweenSpawn;
        }
    }
    void SpawnApple()
    {
        GameObject g = ObjectPool.Instance.GetFromPool("Apple", AppleRandomPosition.GetPosition(), Quaternion.identity);
    }
}
