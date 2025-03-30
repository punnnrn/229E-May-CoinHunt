using UnityEngine;

public class Coin : MonoBehaviour
{
    public AudioClip collectSound;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (collectSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(collectSound);
            }

            CoinManager.instance.CollectCoin();
            Destroy(gameObject);
        }
    }
}
