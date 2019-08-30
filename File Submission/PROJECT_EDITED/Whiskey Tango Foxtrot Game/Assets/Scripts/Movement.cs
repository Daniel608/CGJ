using UnityEngine;

public class Movement : MonoBehaviour
{
    //Movement
    public float speed;
    public float jump;
    public LayerMask platforms;

    //The rigidbody
    private Rigidbody2D rb;
    //The collider
    private BoxCollider2D box;
    //Grounded Variable
    private bool grounded;
    //Jump Count
    private int jumpCount;
    //Animator
    private Animator animator;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        box = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }

    private float GetHorizontalInput()
    {
        float h = Input.GetAxisRaw("Horizontal");

        return h;
    }

    /// <summary>
    /// The Update Method
    /// </summary>
    private void Update()
    {
        //Grounded check
        GroundedCheck();

        //If there's player input
        if (Input.anyKey)
        {
            Vector2 destination = Vector2.zero;
            float horizontalV = GetHorizontalInput() * speed;

            //Jumping
            if (grounded)
            {
                jumpCount = 0;

                if (Input.GetKeyDown(KeyCode.W))
                {
                    destination = Jump(horizontalV);
                    Move(destination);
                    return;
                }
            }
            else if (jumpCount <= 1 && Input.GetKeyDown(KeyCode.W))
            {
                destination = Jump(horizontalV);
                Move(destination);
                return;
            }

            destination = new Vector2(horizontalV, rb.velocity.y);

            Move(destination);

            if (destination != Vector2.zero && !transform.localScale.x.Equals(Mathf.Sign(destination.x)))
                transform.localScale = new Vector3(Mathf.Sign(destination.x), 1f, 1f);
        }
    }

    private void Move(Vector2 destination)
    {
        rb.velocity = destination;
    }

    private Vector2 Jump(float horizontalV)
    {
        jumpCount++;
        Debug.Log("JUMP!");
        return new Vector2(horizontalV * speed, jump);
    }

    private void GroundedCheck()
    {
        RaycastHit2D hit = Physics2D.BoxCast(box.bounds.center, box.bounds.size, 0f, Vector2.down, 0.1f, platforms);
        grounded = hit.collider != null;
    }
}