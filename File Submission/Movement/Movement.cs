using UnityEngine;

//The movement of player
[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    //The rigidbody
    private Rigidbody2D rb;
    //Some bools
    private bool doubleJump, canJump;
    //The collider to check ground
    private BoxCollider2D boxCollider;
    //The jump count
    private int jumpCount;

    //The platorm layer be sure to create it in layers and set platforms to layer
    [SerializeField] LayerMask platforms;

    /// <summary>
    /// Awake method
    /// </summary>
    private void Awake()
    {
        //Set the values
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();

        rb.drag = 5f;
        rb.gravityScale = 30f;
    }

    /// <summary>
    /// Fixed Update method
    /// </summary>
    private void FixedUpdate()
    {
        //Check if player can move in the first place
        if (GameHandler.Instance.canMove)
        {
            //Ground check
            GroundCheck();

            //Get the position to go to
            Vector3 destination = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
            destination = destination.normalized * GameHandler.Instance.speed * Time.fixedDeltaTime;

            //Move horizontaly
            rb.MovePosition(transform.position + destination);

            //Jump
            if (canJump)
            {
                jumpCount = 0;

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    rb.AddForce(Vector2.up * GameHandler.Instance.jumpForce, ForceMode2D.Impulse);
                    jumpCount++;
                    return;
                }
            }

            //Double jump
            if (Input.GetKeyDown(KeyCode.Space) && jumpCount <= 1)
            {
                rb.AddForce(Vector2.up * GameHandler.Instance.jumpForce, ForceMode2D.Impulse);
                jumpCount++;
            }
        }
    }

    /// <summary>
    /// Grounded check
    /// </summary>
    private void GroundCheck()
    {
        //raycast
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, 0.1f, platforms);
        canJump = hit.collider != null;
    }
}
