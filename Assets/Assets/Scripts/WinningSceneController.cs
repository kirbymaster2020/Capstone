using UnityEngine;
using UnityEngine.SceneManagement;

public class WinningSceneController : MonoBehaviour
{
    // This method is for going back to the main menu
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    // This method is for restarting the game and going to the TestingScene
    public void PlayAgain()
    {
        SceneManager.LoadScene("Level 1");
    }

    // This method is for quitting the game
    public void QuitGame()
    {
        Application.Quit();
    }
}
