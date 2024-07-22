using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("GameplayScene"); // Replace "GameplayScene" with the name of your gameplay scene
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
    public void OpenCredits()
    {
        SceneManager.LoadScene("CreditsScene");
    }
}
