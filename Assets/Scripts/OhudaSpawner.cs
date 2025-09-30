using UnityEngine;
using System.Collections.Generic;

public class OhudaSpawner : MonoBehaviour
{
    public GameObject ohudaPrefab;
    public Transform[] spawnPoints;
    public bool[] OhudaSpawned; // Array to track if Ohuda has been spawned at each point
    public int Ohudaindex;
    public int maxOhudaCount = 10;
    public int nowCount; // Current number of Ohuda spawned
    public List<GameObject> ohudaList = new List<GameObject>(); // List to keep track of spawned Ohuda
    // Maximum number of Ohuda to spawn
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        // Randomly select a spawn point index
        nowCount = 0; // Initialize the count of spawned Ohuda
        OhudaSpawned = new bool[spawnPoints.Length];
        // Initialize the array
        while (nowCount < maxOhudaCount)
        {
            Ohudaindex = Random.Range(0, spawnPoints.Length);
            if (!OhudaSpawned[Ohudaindex]) // Check if Ohuda has not been spawned at this point
            {
                GameObject ohuda = Instantiate(ohudaPrefab, spawnPoints[Ohudaindex].position, Quaternion.identity);
                OhudaSpawned[Ohudaindex] = true; // Mark this spawn point as used
                nowCount++;
                ohudaList.Add(ohuda);
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
