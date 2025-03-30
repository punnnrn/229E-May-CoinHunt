using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float timeLimit = 300f;
    private float currentTime;

    public Text timerText;

    private bool isRunning = true;

    void Start()
    {
        currentTime = timeLimit;
        UpdateTimerUI();
    }

    void Update()
    {
        if (isRunning)
        {
            currentTime -= Time.deltaTime;
            UpdateTimerUI();

            if (currentTime <= 0)
            {
                GameOver();
            }
        }
    }

    void UpdateTimerUI()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void GameOver()
    {
        isRunning = false;
        currentTime = 0;
        UpdateTimerUI();
        RestartGame();
    }

    // Restart
    public void RestartGame()
    {
        ShowCursor();
        SceneManager.LoadScene(3);
    }

    private void ShowCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
