using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneButtonsUI : MonoBehaviour
{
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(
            "MainMenu"
        );
    }

    public void LoadExplosionScene()
    {
        SceneManager.LoadScene(
            "ExplosionScene"
        );
    }

    public void LoadDominoScene()
    {
        SceneManager.LoadScene(
            "DominoScene"
        );
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(
            SceneManager.GetActiveScene().name
        );
    }

    public void ExitApplication()
    {
        Application.Quit();

        Debug.Log("Exit");
    }
}