using UnityEngine;

public class FallTrigger : MonoBehaviour
{
        
       void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerMovement2D>().TakeDamage();
        }
    }
    

}
