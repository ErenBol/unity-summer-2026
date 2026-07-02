using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerMovement2D : MonoBehaviour
{
    public float moveSpeed = 6f;
    public float jumpForce = 7f;

    public Transform groundCheck;
    public float groundCheckRadius = 0.15f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private float horizontalInput;
    private bool isGrounded;

    private bool allowDoubleJump = false;
    public Vector2 startPosition;

    private int HPRemaining = 3;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
    }

    void Update()
    {   
        if (FindAnyObjectByType<GameManagement>().isGameOver)
        {
            return;
        }

        horizontalInput = Input.GetAxisRaw("Horizontal");

        isGrounded = Physics2D.OverlapCircle(
            groundCheck.position,
            groundCheckRadius,
            groundLayer
        );

        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            
            if (isGrounded)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
                allowDoubleJump = true;
                
            }
            else if (allowDoubleJump)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
                allowDoubleJump = false;
            }
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontalInput * moveSpeed, rb.linearVelocity.y);
    }

    void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
    public void TakeDamage()
    {
        if (FindAnyObjectByType<GameManagement>().isGameOver)
        {
            return;
        }
        HPRemaining -= 1;
        FindAnyObjectByType<GameManagement>().UpdateHP(HPRemaining);
        if (HPRemaining <= 0)
        {
            FindAnyObjectByType<GameManagement>().LoseGame();
        }
        else
        {
            RespawnPlayer();
        }
    }

    void RespawnPlayer()
    {
        FindAnyObjectByType<GameManagement>().ResetScore();
        transform.position = startPosition;
        rb.linearVelocity = Vector2.zero;
    }
}