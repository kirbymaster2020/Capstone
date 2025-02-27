using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private Button restartButton;
    [SerializeField] private Button mainMenuButton;

    // Start is called before the first frame update
    void Start()
    {
        // Add click listeners to buttons
        if (restartButton != null)
        {
            restartButton.onClick.AddListener(RestartGame);
        }

        if (mainMenuButton != null)
        {
            mainMenuButton.onClick.AddListener(GoToMainMenu);
        }
    }

    // Method to handle the Setup function
    public void Setup(GameOverScreen gameOverScreen)
    {
        // Any setup code you need goes here
        gameObject.SetActive(true);
    }

    // Restart the game (load the TestingScene)
    public void RestartGame()
    {
        SceneManager.LoadScene("TestingScene");
    }

    // Go to main menu
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    // Optional: If you want to test the buttons in the editor
    // You can use these methods
    void Update()
    {
        // For testing in the editor
        if (UnityEngine.Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
        if (UnityEngine.Input.GetKeyDown(KeyCode.M))
        {
            GoToMainMenu();
        }
    }
}