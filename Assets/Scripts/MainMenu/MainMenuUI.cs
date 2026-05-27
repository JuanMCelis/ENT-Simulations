using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
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

    public void ExitApplication()
    {
        Application.Quit();

        Debug.Log("Exit");
    }
}