using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Player się ślizga
public class PlayerController : MonoBehaviour
{
    #region Declarations
    [Header("Components")]
    public Rigidbody2D playerRb;
    public Animator animator;
    public LayerMask groundLayer;

    [Header("General Movement")]
    public Vector2 direction;

    [Header("Horizontal Movement")]
    [SerializeField] float moveSpeed;
    private float horizontalInput;
    private bool facingRight;

    [Header("Vertical Movement")]
    [SerializeField] float jumpForce;
    [SerializeField] float jumpDelay = 0.25f;
    [SerializeField] float jumpTimer;
    private float verticallInput;

    [Header("Physics")]
    [SerializeField] float maxSpeed;
    [SerializeField] float linearDrag;
    [SerializeField] float gravity;
    [SerializeField] float fallMultiplier;

    [Header("Collisions")]
    [SerializeField] float groundLength = 0.3f;
    [SerializeField] bool isOnGround = false;
    public Vector3 colliderOffset;
    #endregion

    #region Management
    void Start()
    {
        playerRb = this.GetComponent<Rigidbody2D>();
        facingRight = true;
        maxSpeed = 2.5f;
        jumpForce = 10f;
        linearDrag = 4f;
        gravity = 1f;
        fallMultiplier = 5f;
        moveSpeed = 50f;
    }

    void Update()
    {
        // Get player input.
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticallInput = Input.GetAxisRaw("Vertical");
        direction = new Vector2(horizontalInput, verticallInput);

        isOnGround = Physics2D.Raycast(transform.position + colliderOffset, Vector2.down, groundLength, groundLayer) ||
            Physics2D.Raycast(transform.position - colliderOffset, Vector2.down, groundLength, groundLayer);
        if (Input.GetButtonDown("Jump"))
        {
            jumpTimer = Time.time + jumpDelay;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
           
        }
    }

    void FixedUpdate()
    {
        Move(direction.x);

        if (jumpTimer > Time.time && isOnGround)
        {
            Jump();
        }

        ModifyPhysics();
    }
    #endregion

    #region Movement
    private void Move(float horizontal)
    {
        //playerRb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
        playerRb.AddForce(Vector2.right * horizontal * moveSpeed);
        animator.SetFloat("horizontal", Mathf.Abs(playerRb.velocity.x));

        if ((horizontal > 0 && !facingRight) || horizontal < 0 && facingRight)
        {
            Flip();
        }

        if (Mathf.Abs(playerRb.velocity.x) > maxSpeed)
        {
            playerRb.velocity = new Vector2(Mathf.Sign(playerRb.velocity.x) * maxSpeed, playerRb.velocity.y);
        }
    }
    private void Jump()
    {
        playerRb.velocity = new Vector2(playerRb.velocity.x, 0);
        playerRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        jumpTimer = 0;
    }

    private void Flip()
    {
        facingRight = !facingRight;
        transform.rotation = Quaternion.Euler(0, facingRight ? 0 : 180, 0);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position + colliderOffset, transform.position + colliderOffset + Vector3.down * groundLength);
        Gizmos.DrawLine(transform.position - colliderOffset, transform.position - colliderOffset + Vector3.down * groundLength);
    }
    #endregion

    #region Physics
    void ModifyPhysics()
    {
        bool changingDirections = (direction.x > 0 && playerRb.velocity.x < 0) || (direction.x < 0 && playerRb.velocity.x > 0);

        if (isOnGround)
        {
            if (Mathf.Abs(direction.x) < 0.4f || changingDirections)
            {
                playerRb.drag = linearDrag;
            }
            else
            {
                playerRb.drag = 0f;
            }
            playerRb.gravityScale = 0;
        }
        else
        {
            playerRb.gravityScale = gravity;
            playerRb.drag = linearDrag * 0.15f;
            if (playerRb.velocity.y < 0)
            {
                playerRb.gravityScale = gravity * fallMultiplier;
            }
            else if (playerRb.velocity.y > 0 && !Input.GetButton("Jump"))
            {
                playerRb.gravityScale = gravity * (fallMultiplier / 2);
            }
        }
    }
    #endregion

    #region Collisions

    #endregion
}