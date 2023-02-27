using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void changeScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void QuitApp()
    {
        Application.Quit();
    }
}
