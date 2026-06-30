using UnityEditor.Build.Content;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            FindAnyObjectByType<GameManagement>().AddScore();
            Destroy(gameObject);
        }
    }
}
