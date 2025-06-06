using UnityEngine;

public class DudeController : MonoBehaviour
{
    [SerializeField] float moveForce = 500;
    Vector2 move = Vector2.zero;
    Rigidbody2D rb;

    Animator anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        move.x = Input.GetAxis("Horizontal");
        UpdateAnimationState();
    }

    private void FixedUpdate()
    {
        rb.AddForce(move * moveForce * Time.deltaTime);
    }

    private void UpdateAnimationState()
    {
        if (rb.linearVelocity.x > 0.1)
        {
            anim.Play("DudeWalkRight");
        }
        else if (rb.linearVelocity.x < -0.1)
        {
            anim.Play("DudeWalkLeft");
        }
        else
        {
            anim.Play("DudeIdle");
        }

    }
}
