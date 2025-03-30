using UnityEngine;
using UnityEngine.UI;  // สำหรับ UI

public class PlayerHealthUI : MonoBehaviour
{
    public Image hitBorder;
    public float hitDuration = 0.5f;
    private bool isHit = false;

    void Start()
    {
        if (hitBorder != null)
        {
            hitBorder.enabled = false;
        }
    }

    public void ShowHitBorder()
    {
        if (hitBorder != null)
        {
            hitBorder.enabled = true;
            Invoke("HideHitBorder", hitDuration);
        }
    }

    void HideHitBorder()
    {
        if (hitBorder != null)
        {
            hitBorder.enabled = false;
        }
    }
}
