using UnityEngine;
using System.Collections;

public class Daruma : MonoBehaviour
{
    public GameObject daruma;
    public Transform player;
    public Vector2 toPlayerDirection;
    public SpriteRenderer spriteRenderer;
    public GameObject findMarker;
    public Vector2 darumaDirection;
    public Sprite normalSprite;
    public Sprite findSprite;
    GameObject Timer;
    Timer timerScript;
    public bool isFacingBack = false;
    public float player_x = 0.0f;
    public float player_y = 0.0f;

    // Flag to check if Daruma is facing back
    // Prefab for the Daruma object
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    void Start()
    {
        
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = normalSprite;
        Timer = GameObject.Find("Timer");
        timerScript = Timer.GetComponent<Timer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timerScript.isFound && GameManager.Instance.isGameOver == false)
        {
            SwitchSpriteFind();
            CheckPlayerMoving();
        }
        else if (GameManager.Instance.isGameOver == false)
        {
            // If the game is over, switch to the normal sprite
            SwitchSpriteNormal();
        }
        
    }

    public void DarumaDiscard()
    {
        if (Vector2.Distance(player.position, daruma.transform.position) < 2.0f)
        {
            //playerdirection
            Vector2 direction = (daruma.transform.position - player.position).normalized;
            // Check if the player is close enough to interact with the Daruma
            PlayerMoving pc = player.GetComponent<PlayerMoving>();
            

            
            if (Input.GetKeyDown(KeyCode.Return) && Vector2.Dot(pc.direction, direction) > 0.9f && GameManager.Instance.ohudaCount > 0)
            {
                // Check if the player is in front of the Daruma and presses the space key
                
                GameManager.Instance.ohudaCount--; // Decrement the ohudaCount in GameManager
                Destroy(daruma); // Destroy the Daruma game object
            }
        }
    }
    public void CheckPlayerMoving()
    {
        if (player_x == 0.0f || player_y == 0.0f)
        {
            player_x = player.position.x;
            player_y = player.position.y;
        }
        toPlayerDirection = (player.position - transform.position).normalized;
        float dot = Vector2.Dot(darumaDirection, toPlayerDirection);
        float distance = Vector2.Distance(player.position, transform.position);
        if (distance < 10.0f && dot > 0.965f && (player.position.x != player_x || player.position.y != player_y))
        {
            // If the player is close enough and facing the Daruma

            findMarker.SetActive(true);
            SoundManager.Instance.PlaySE(SESoundData.SE.Find);
            GameManager.Instance.isGameOver = true; // Set the game over flag
            
        }
        
    }

    private void SwitchSpriteFind()
    {
        isFacingBack = true;
        spriteRenderer.sprite = findSprite;
    }
    private void SwitchSpriteNormal()
    {
        isFacingBack = false;
        spriteRenderer.sprite = normalSprite;
        player_x = 0.0f; // Reset player_x to 0
        player_y = 0.0f; // Reset player_y to 0
    }

}
