using UnityEngine;

public class Flag : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("Player"))
        {
            FindAnyObjectByType<GameManagement>().WinGame();
        }

    }
}
