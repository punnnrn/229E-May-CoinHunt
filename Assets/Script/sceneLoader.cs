using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Restart
    public void RestartScene()
    {
        ShowCursor();
        SceneManager.LoadScene(1);
    }

    // MainMenu
    public void LoadMainMenu()
    {
        ShowCursor();
        SceneManager.LoadScene(0);
    }

    private void ShowCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}