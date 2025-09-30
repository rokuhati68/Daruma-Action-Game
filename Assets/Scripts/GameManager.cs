using UnityEngine;
using TMPro;
using UnityEngine.UI;
using unityroom.Api;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public int ohudaCount = 0;
    public bool isGameOver = false;
    public bool isGameClear = false; // Flag to check if the game is cleared
    public bool endflag = false; // Flag to check if the game has ended
    public TextMeshProUGUI OhudaCountText;
    public GameObject GameOverPanel;
    public GameObject GameClearPanel; // Panel to show when the game is cleared
    public DarumaSpawner darumaSpawner;
    public PlayerMoving playerMoving;
    public Timer timerScript;
    public OhudaSpawner ohudaSpawner;
    public TextMeshProUGUI GameClearTime; // Text to show when the game is cleared
    public bool check = true; // Flag to check if the game is cleared
    public float gameClearTime = 0.0f; // Time taken to clear the game

    private void Awake()
    {
        Instance = this;
        Initialize();
    }

    public void Start()
    {
        gameClearTime = 0.0f; // Reset the game clear time at the start
        check = true; // Reset the check flag at the start
        GameOverPanel.SetActive(false); // Hide the game over panel at the start
        GameClearPanel.SetActive(false); // Hide the game clear panel at the start
        ohudaCount = 0; // Initialize the count of Ohuda
        isGameOver = false;
        isGameClear = false; // Initialize the game clear state
        SoundManager.Instance.PlayBGM(BGMSoundData.BGM.MainBGM);
        Debug.Log("start");
        endflag = false; // Reset the end flag at the start
    }
    // Update is called once per frame
    void Update()
    {
        OhudaCountText.text = ohudaCount.ToString();
        if (isGameOver && !endflag)
        {
            SoundManager.Instance.StopBGM(BGMSoundData.BGM.MainBGM);
            SoundManager.Instance.PlayBGM(BGMSoundData.BGM.GameOverBGM);
            GameOverPanel.SetActive(true);
            // Reset game clear state when game is over
            Debug.Log("Game Over!"); // Log game over message
            isGameOver = false; // Reset the game over state
            endflag = true; // Set the end flag to true when the game is over
        }
        if (ohudaCount >= 10 && !endflag)
        {
            endflag = true; // Set the end flag to true when Ohuda count reaches 10
            if (check)
            {
                gameClearTime = timerScript.gameTime; // Store the game clear time
                GameClearTime.text = timerScript.gameTime.ToString("F2"); // Display the game clear time
                check = false; // Set the check flag to false to prevent multiple plays
                UnityroomApiClient.Instance.SendScore(1, gameClearTime, ScoreboardWriteMode.HighScoreAsc);

            }
            // Set the game clear state when Ohuda count reaches 10
            GameClearPanel.SetActive(true); // Show the game clear panel
            SoundManager.Instance.StopBGM(BGMSoundData.BGM.MainBGM);
            SoundManager.Instance.PlayBGM(BGMSoundData.BGM.GameClearBGM);

        }
    }

    private void Initialize()
    {
        ohudaCount = 0;
    }

    public void OnclicResturtButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        SoundManager.Instance.PlaySE(SESoundData.SE.Click); // Play click sound when the restart button is clicked
    }
    public void OnClickTitleButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("TitleScene");
        SoundManager.Instance.PlaySE(SESoundData.SE.Click); // Play click sound when the title button is clicked
        // Load the title scene when the title button is clicked
    }

}
