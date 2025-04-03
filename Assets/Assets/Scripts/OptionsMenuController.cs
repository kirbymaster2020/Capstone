using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsMenuController : MonoBehaviour
{
    public void BackToMainMenu()
    {
        Debug.Log("Going back to Main Menu");
        SceneManager.LoadScene("Main Menu");
    }

    public void GoToHowToPlay()
    {
        Debug.Log("Going to How To Play");
        SceneManager.LoadScene("HowToPlay");
    }

    public void BackToOptionsMenu()
    {
        Debug.Log("Going back to Options Menu");
        SceneManager.LoadScene("OptionsMenu");
    }
}
