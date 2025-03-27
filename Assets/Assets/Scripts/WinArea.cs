using UnityEngine;
using UnityEngine.SceneManagement; // For Scene management

public class WinArea : MonoBehaviour
{
    // This function is called when another collider enters the trigger area
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player has entered the trigger zone
        if (other.CompareTag("Player")) // Make sure your player has the "Player" tag
        {
            // Load the "You Win" scene
            SceneManager.LoadScene("WinningScene");
        }
    }
}
