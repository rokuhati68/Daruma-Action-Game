using UnityEngine;

public class TitleManager : MonoBehaviour
{

     // Reference to the GameManager script
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Play the title background music
        SoundManager.Instance.PlayBGM(BGMSoundData.BGM.TitleBGM);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnStartButtonClicked()
    {
        // Load the game scene when the start button is clicked
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
        SoundManager.Instance.PlaySE(SESoundData.SE.Click); // Play click sound when the start button is clicked
    }
}
