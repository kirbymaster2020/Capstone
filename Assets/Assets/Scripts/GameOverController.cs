using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    // Function to load the TestingScene (Restart)
    public void RestartGame()
    {
        Debug.Log("Restarting the game...");
        SceneManager.LoadScene("Level 1"); // Make sure your scene is named "TestingScene"
    }

    // Function to load the MainMenu scene
    public void GoToMainMenu()
    {
        Debug.Log("Going to Main Menu...");
        SceneManager.LoadScene("Main Menu"); // Make sure your scene is named "Main Menu"
    }
}
