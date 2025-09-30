using UnityEngine;

public class Timer : MonoBehaviour
{
    public float DarumaSpawnerLimit = 15f; // Time limit in seconds
    private float darumaSoundTimer;
    public bool isFound = false; // Flag to check if Daruma is found
    public bool isTurned = false;
    GameObject darumaSpawner;
    DarumaSpawner darumaSpawnerScript;
    public float gameTime = 0f;
    public bool endflag = false; // Flag to check if the game has ended
    public GameManager gameManager;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        gameTime = 0f; // Initialize the game time
        DarumaSpawnerLimit = 15f; // Initialize the timer
        darumaSpawner = GameObject.Find("DarumaSpawner");
        darumaSpawnerScript = darumaSpawner.GetComponent<DarumaSpawner>(); // Initialize the timer
        darumaSoundTimer = Random.Range(15f, 25f); // Random sound interval between 15 and 25 seconds
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        endflag = gameManager.endflag; // Get the end flag from GameManager
        if (endflag)
        {
            CancelInvoke();
            return; // Skip the timer update if the game is over or cleared
        }
        gameTime += Time.deltaTime;
        if (!isFound)
        {
            DarumaSpawnerLimit -= Time.deltaTime;
            darumaSoundTimer -= Time.deltaTime;
            if (DarumaSpawnerLimit <= 0)
            {
                DarumaSpawnerLimit = 15f; // Reset the timer
                darumaSpawnerScript.RightspawnDarumaCheck(); // Call the method to spawn Daruma
                darumaSpawnerScript.LeftspawnDarumaCheck();
                darumaSpawnerScript.UpspawnDarumaCheck();
                darumaSpawnerScript.DownspawnDarumaCheck();
            }
            if (darumaSoundTimer <= 0)
            { // Reset the sound timer
                if (!isTurned)
                {
                    SoundManager.Instance.PlaySE(SESoundData.SE.Turn1);  // Play the sound
                    isTurned = true; // Set the flag to true when Daruma is found
                }
                Invoke(nameof(Gofront), 2.5f); // Call the method to go front after the sound finishes
                Invoke(nameof(TurnBackDaruma), 10f); // Call the method to turn back Daruma
            }
        }
    }
    private void Gofront()
    { // Set the flag to true when Daruma is found
        isFound = true; // Set the flag to true when Daruma is found
        SoundManager.Instance.StopBGM(BGMSoundData.BGM.MainBGM);
    }
    private void TurnBackDaruma()
    {
        isFound = false; // Reset the flag to false when Daruma turns back
        DarumaSpawnerLimit = 15f;
        darumaSoundTimer = Random.Range(15f, 25f); // Reset the sound timer
        SoundManager.Instance.PlayBGM(BGMSoundData.BGM.MainBGM);
        Debug.Log("turn");
        isTurned = false; // Reset the flag to false when Daruma turns back
    }

    
}



