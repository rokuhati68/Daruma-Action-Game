using UnityEngine;

public class Ohuda : MonoBehaviour
{
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter2D(Collider2D other)
    {
        // This method is called when another collider enters the trigger collider attached to this GameObject
        // Check if the other collider has the tag "Player"
        if (other.CompareTag("Player"))
        {
            SoundManager.Instance.PlaySE(SESoundData.SE.Get);
            // Player has entered the trigger zone
            
            GameManager.Instance.ohudaCount++; // Increment the ohudaCount in GameManager
            Destroy(gameObject); // Destroy the game object this script is attached to
        }
    }
}


