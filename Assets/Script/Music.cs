using UnityEngine;

public class Music : MonoBehaviour
{
    public static Music BgInstance;


    private void Awake()
    {
        if (BgInstance != null && BgInstance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        BgInstance = this;
        DontDestroyOnLoad(this);
    }
}