using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndingScreen : MonoBehaviour
{
    [SerializeField] private Button mainMenuButton;
    [SerializeField] private Button exitButton;

    // Start is called before the first frame update
    void Start()
    {
        // Add click listeners to buttons
        if (mainMenuButton != null)
        {
            mainMenuButton.onClick.AddListener(GoToMainMenu);
        }

        if (exitButton != null)
        {
            exitButton.onClick.AddListener(ExitGame);
        }
    }

    // Go to main menu
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    // Exit the game
    public void ExitGame()
    {
#if UNITY_EDITOR
        // If we are running in the editor
        UnityEditor.EditorApplication.isPlaying = false;
#else
            // If we are running a build
            Application.Quit();
#endif

        Debug.Log("Game is exiting");
    }
}