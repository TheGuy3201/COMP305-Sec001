using Unity.Cinemachine;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float movementSpeed = 5f;
    [SerializeField] float jumpForce = 10f;
    [SerializeField] Transform groundChecker;
    [SerializeField] float groundCheckDistance = 0.2f; // Adjust as needed
    [SerializeField] LayerMask groundLayer; // Set this in the Inspector

    private Rigidbody2D rb;

    private SpriteRenderer spriteRenderer;

    [SerializeField] float originGravity;

    [SerializeField] CinemachineCamera cam1;
    [SerializeField] CinemachineCamera cam2;
    bool cam1Active = true; 
    public bool IsGrounded
    {
        //get => true;
        get => Physics2D.OverlapCircle(groundChecker.position, groundCheckDistance, groundLayer);
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        FlipCamera();
    }

    void Update()
    {
        // Get Horizontal Input
        float movementDirection = Input.GetAxis("Horizontal");

        // Apply Movement
        rb.linearVelocity = new Vector2(movementDirection * movementSpeed, rb.linearVelocity.y);
        spriteRenderer.flipX = rb.linearVelocity.x < 0;

        // Jump
        if (Input.GetButtonDown("Jump") && IsGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            FlipCamera();
        }
    }

    private void FlipCamera()
    {
        if (cam1Active)
        {
            cam1Active = false;
            cam1.gameObject.SetActive(false);
            cam2.gameObject.SetActive(true);
        }
        else
        {
            cam1Active = true;
            cam1.gameObject.SetActive(true);
            cam2.gameObject.SetActive(false);
        }
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    GameObject gb = collision.gameObject;
    //    if (gb.CompareTag("Ceiling"))
    //    {
    //        originGravity = gb.GetComponent<Rigidbody2D>().gravityScale;
    //        gb.GetComponent<Rigidbody2D>().gravityScale = 0;
    //    }
    //}
    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    GameObject gb = collision.gameObject;
    //    if (gb.CompareTag("Ceiling"))
    //    {
    //        gb.GetComponent<Rigidbody2D>().gravityScale = 0;
    //    }
    //}
}