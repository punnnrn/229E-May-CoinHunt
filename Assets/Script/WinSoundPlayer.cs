using UnityEngine;

public class WinSoundPlayer : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip winSound;

    void Start()
    {
        if (audioSource != null && winSound != null)
        {
            audioSource.PlayOneShot(winSound);
        }
    }
}