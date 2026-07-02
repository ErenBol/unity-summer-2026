using UnityEngine;
using UnityEngine.SceneManagement;

public class Hazard : MonoBehaviour
{
    public AudioClip damageSound;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(damageSound, transform.position);
            other.GetComponent<PlayerMovement2D>().TakeDamage();
        }
    }

}
