using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // Function to start the game, loading the first scene
    public void StartGame()
    {
        Debug.Log("Starting the game: " + gameObject.name);
        SceneManager.LoadScene(1);  
    }

    // Function to load the OptionsMenu scene
    public void GoToOptionsMenu()
    {
        Debug.Log("Going to Options Menu");
        SceneManager.LoadScene("OptionsMenu"); 
    }

    // Function to close the game
    public void CloseGame()
    {
        Debug.Log("Exiting game");
        Application.Quit();  // Exits the game
    }
}
