using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject itemPrefab;
    public float spawnRate = 2f;
    public float spawnAreaWidth = 10f;  
    private float nextSpawnTime = 0f;

    void Update()
    {
        
        if (Time.time >= nextSpawnTime)
        {          
            float randomX = Random.Range(-spawnAreaWidth / 2f, spawnAreaWidth / 2f);
           
            Instantiate(itemPrefab, new Vector3(randomX, 10f, 0f), Quaternion.identity);

            nextSpawnTime = Time.time + 1f / spawnRate;
        }
    }
}
