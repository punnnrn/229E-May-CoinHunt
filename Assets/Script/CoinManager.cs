using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;
    public int totalCoins = 25;
    private int currentCoins = 0;

    public Text coinText;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        UpdateCoinUI();
    }

    void Update()
    {
        // ทดสอบเพิ่มเหรียญ
        if (Input.GetKeyDown(KeyCode.G))
        {
            CollectCoin();
        }
    }

    public void CollectCoin()
    {
        currentCoins++;
        UpdateCoinUI();

        if (currentCoins >= totalCoins)
        {
            Win();
        }
    }

    void UpdateCoinUI()
    {
        coinText.text = "Coins: " + currentCoins + " / " + totalCoins;
    }


    // Win
    public void Win()
    {
        ShowCursor();
        SceneManager.LoadScene(2);
    }

    private void ShowCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
