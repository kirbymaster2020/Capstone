using UnityEngine;
using UnityEngine.SceneManagement; 

public class YouWin : MonoBehaviour
{
    
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Main Menu"); // Ensure this is the correct name of your Main Menu scene
    }
}
