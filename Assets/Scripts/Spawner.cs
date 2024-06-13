using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject[] prefabs;
    public Transform[] spawnPoints;
    public float spawnTimer = 2; // how often a new object generates to user in seconds
    private float timer; // time that passes
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > spawnTimer)
        {
            // spawns object at a new random place 
            Transform randomPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            GameObject randomPrefab = prefabs[Random.Range(0, prefabs.Length)];

            GameObject spawnedPrefab = Instantiate(randomPrefab, randomPoint.position, randomPoint.rotation);

            // reset timer 
            timer -= spawnTimer;
        }
    }
}
