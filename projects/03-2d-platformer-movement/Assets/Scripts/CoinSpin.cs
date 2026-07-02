using UnityEngine;

public class CoinSpin : MonoBehaviour
{
    public float spinSpeed = 180f;

    void Update()
    {
        transform.Rotate(0, spinSpeed * Time.deltaTime, 0);
    }
}