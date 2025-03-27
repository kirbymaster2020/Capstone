using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsMenuController : MonoBehaviour
{
    // Function to go back to the main menu
    public void BackToMainMenu()
    {
        Debug.Log("Going back to Main Menu");
        SceneManager.LoadScene("Main Menu"); // Make sure the Main Menu scene is named exactly as "Main Menu"
    }
}
