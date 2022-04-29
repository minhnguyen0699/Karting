using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawnManager : MonoBehaviour
{
    public GameObject[] asteroidPrefabs;
    private float spawnRangeX = 150;
    private float spawnPosZ = 150;
    private float startDelay = 0;
    private float spawnInterval = 1.0f;
   

    // Start is called before the first frame update
    void Start()
    {
       
        InvokeRepeating("SpawnRandomAsteroid", startDelay, spawnInterval );
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnRandomAsteroid()
    {
       
       
            int carIndex = Random.Range(0, asteroidPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-50, 80), transform.position.y, Random.Range(-spawnPosZ, spawnPosZ));
        Instantiate(asteroidPrefabs[carIndex], spawnPos, asteroidPrefabs[carIndex].transform.rotation);
        
    }
}
