using UnityEngine;

public class Flag : MonoBehaviour
{
    public AudioClip winSound;
    void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(winSound, transform.position);
            FindAnyObjectByType<GameManagement>().WinGame();
        }

    }
}
