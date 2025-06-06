using System.Threading.Tasks;
using UnityEngine;
using Input = UnityEngine.Input;
public class DanController : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    [SerializeField] float xInput;
    [SerializeField] float moveSpeed = 8;
    [SerializeField] float jumpSpeed = 15;
    [SerializeField] bool isGrounded;
    [SerializeField] Transform groundChecker;
    [SerializeField] LayerMask groundLayer;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(xInput * moveSpeed, rb.linearVelocity.y);
        isGrounded = Physics2D.OverlapCircle(groundChecker.position, 0.1f, groundLayer);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpSpeed);
            animator.SetBool("IsJumping", true); // Set it here instead
        }

        // Reset jump bool if we're grounded again
        if (isGrounded && animator.GetBool("IsJumping"))
        {
            animator.SetBool("IsJumping", false);
        }

        UpdateAnimationState();
        FlipSprite();
    }


    void UpdateAnimationState()
    {
        print(rb.linearVelocity.x);
        if (rb.linearVelocity.x > 0.1 || rb.linearVelocity.x < -0.1)
        {
            animator.SetInteger("AnimationState", 1); //this is move_right state
            if (Input.GetKeyDown(KeyCode.Space))
            {
                animator.SetBool("IsJumping", true);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("IsJumping", true);
        }
        else
        {
            animator.SetInteger("AnimationState", 0); //this is idle state
        }
    }
    void FlipSprite()
    {
        if (rb.linearVelocity.x < 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (rb.linearVelocity.x > 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
    }
}