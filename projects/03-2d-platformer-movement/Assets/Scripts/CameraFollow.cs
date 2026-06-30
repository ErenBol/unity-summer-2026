using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Transform target;
    public Vector3 offset = new Vector3(0f, 1f, -10f);
    public float speed = 5f;

    // Update is called once per frame
    void Update()
    {
        Vector3 desiredPosition = offset + target.transform.position;     

        transform.position = Vector3.Lerp(
            transform.position,
            desiredPosition,
            speed * Time.deltaTime
        );
    }
}
