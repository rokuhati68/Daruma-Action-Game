using UnityEngine;
using System.Collections.Generic;

public class DarumaSpawner : MonoBehaviour
{
    public GameObject darumaRightPrefab;
    public GameObject darumaLeftPrefab;
    public GameObject darumaUpPrefab;
    public GameObject darumaDownPrefab;
    // Default prefab to use if no specific direction is set
    public  Transform[] RightspawnPoints;
    public  Transform[] LeftspawnPoints;
    public  Transform[] UpspawnPoints;
    public  Transform[] DownspawnPoints;
    public  bool[] RightDarumaSpawned;
    public  bool[] LeftDarumaSpawned;
    public  bool[] UpDarumaSpawned;
    public  bool[] DownDarumaSpawned;
    public List<GameObject> darumaList = new List<GameObject>();

    public int rightdarumaCount = 0;
    public int leftdarumaCount = 0;
    public int updarumaCount = 0;
    public int downdarumaCount = 0;
    public int rightspawnpoint = 0;
    public int leftspawnpoint = 0;
    public int upspawnpoint = 0;
    public int downspawnpoint = 0;
    public Transform player; // Reference to the player object

    // Prefab for the Daruma object
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        RightDarumaSpawned = new bool[RightspawnPoints.Length];
        LeftDarumaSpawned = new bool[LeftspawnPoints.Length];
        UpDarumaSpawned = new bool[UpspawnPoints.Length];
        DownDarumaSpawned = new bool[DownspawnPoints.Length];
        
        for (int i = 0; i < 5; i++)
        {
            RightspawnDarumaCheck();
            LeftspawnDarumaCheck();
            UpspawnDarumaCheck();
            DownspawnDarumaCheck(); // Initialize the array to false
        }
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RightspawnDarumaCheck()
    { // Randomly spawn between 1 and 3 Daruma
        while (true)
        {
            rightspawnpoint = Random.Range(1, RightspawnPoints.Length + 1);
            if (!RightDarumaSpawned[rightspawnpoint - 1]) // Check if the count is already used
            {
                RightDarumaSpawned[rightspawnpoint - 1] = true; // Mark this count as used
                rightdarumaCount++; // Increment the count of spawned Daruma
                RightspawnDaruma();
                break; // Exit the loop if a valid count is found
            }
            else if (rightdarumaCount >= RightspawnPoints.Length)
            {
                
                break; // Exit if all spawn points are used
            }
            else
            {
                continue; // If the count is already used, try again
            }
        }
    }
    public void RightspawnDaruma()
    {
        GameObject daruma = Instantiate(darumaRightPrefab, RightspawnPoints[rightspawnpoint - 1].position, Quaternion.identity);
        daruma.GetComponent<Daruma>().player = player;
        GameObject findMarker = daruma.transform.Find("!").gameObject;
        darumaList.Add(daruma); // Add the spawned Daruma to the list
    }
    public void LeftspawnDarumaCheck()
    {
        while (true)
        {
            leftspawnpoint = Random.Range(1, LeftspawnPoints.Length + 1);
            if (!LeftDarumaSpawned[leftspawnpoint - 1]) // Check if the count is already used
            {
                LeftDarumaSpawned[leftspawnpoint - 1] = true; // Mark this count as used
                leftdarumaCount++; // Increment the count of spawned Daruma
                LeftspawnDaruma();
                break; // Exit the loop if a valid count is found
            }
            else if (leftdarumaCount >= LeftspawnPoints.Length)
            {
                
                break; // Exit if all spawn points are used
            }
            else
            {
                continue; // If the count is already used, try again
            }
        }
    }
    public void LeftspawnDaruma()
    {
        GameObject daruma = Instantiate(darumaLeftPrefab, LeftspawnPoints[leftspawnpoint - 1].position, Quaternion.identity);
        daruma.GetComponent<Daruma>().player = player;
        GameObject findMarker = daruma.transform.Find("!").gameObject;
        darumaList.Add(daruma); // Add the spawned Daruma to the list
    }
    public void UpspawnDarumaCheck()
    {
        while (true)
        {
            upspawnpoint = Random.Range(1, UpspawnPoints.Length + 1);
            if (!UpDarumaSpawned[upspawnpoint - 1]) // Check if the count is already used
            {
                UpDarumaSpawned[upspawnpoint - 1] = true; // Mark this count as used
                updarumaCount++; // Increment the count of spawned Daruma
                UpspawnDaruma();
                break; // Exit the loop if a valid count is found
            }
            else if (updarumaCount >= UpspawnPoints.Length)
            {
                
                break; // Exit if all spawn points are used
            }
            else
            {
                continue; // If the count is already used, try again
            }
        }
    }
    public void UpspawnDaruma()
    {
        GameObject daruma = Instantiate(darumaUpPrefab, UpspawnPoints[upspawnpoint - 1].position, Quaternion.identity);
        daruma.GetComponent<Daruma>().player = player;
        GameObject findMarker = daruma.transform.Find("!").gameObject;
        darumaList.Add(daruma); // Add the spawned Daruma to the list
    }
    public void DownspawnDarumaCheck()
    {
        while (true)
        {
            downspawnpoint = Random.Range(1, DownspawnPoints.Length + 1);
            if (!DownDarumaSpawned[downspawnpoint - 1]) // Check if the count is already used
            {
                DownDarumaSpawned[downspawnpoint - 1] = true; // Mark this count as used
                downdarumaCount++; // Increment the count of spawned Daruma
                DownspawnDaruma();
                break; // Exit the loop if a valid count is found
            }
            else if (downdarumaCount >= DownspawnPoints.Length)
            {
                
                break; // Exit if all spawn points are used
            }
            else
            {
                continue; // If the count is already used, try again
            }
        }
    }
    public void DownspawnDaruma()
    {
        GameObject daruma = Instantiate(darumaDownPrefab, DownspawnPoints[downspawnpoint - 1].position, Quaternion.identity);
        daruma.GetComponent<Daruma>().player = player;
        GameObject findMarker = daruma.transform.Find("!").gameObject;
        darumaList.Add(daruma); // Add the spawned Daruma to the list
    }
}
