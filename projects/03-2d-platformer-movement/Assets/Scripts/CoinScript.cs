using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public AudioClip collectSound;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(collectSound, transform.position);
            FindAnyObjectByType<GameManagement>().AddScore();
            gameObject.SetActive(false);
        }
    }
}
