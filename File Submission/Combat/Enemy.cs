using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Stats stats;
    public LayerMask platforms;
    public float range = 4f;

    private Rigidbody2D rb;
    private BoxCollider2D box;
    private Vector2 destination;
    private bool playerFound;
    private int cooldown;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        destination = new Vector2(1f, 0f);
    }

    private void FixedUpdate()
    {
        if(stats.health <= 0f)
        {
            Destroy(gameObject, 0.5f);
        }

        bool grounded = GameHandler.Instance.GroundedCheck(gameObject.transform.position, platforms);

        #region Movement
        if (!playerFound)
        {
            if (!grounded) destination = -destination;

            rb.velocity = new Vector2(destination.x, rb.velocity.y);

            RaycastHit2D hit = Physics2D.Raycast(transform.position, destination, range);
            playerFound = hit.collider != null && hit.collider.CompareTag("Player");
        }
        #endregion

        if (playerFound)
        {
            if (cooldown > 0) cooldown--;
            GameObject player = GameObject.FindWithTag("Player");

            if (Vector2.Distance(transform.position, player.transform.position) > 2f)
            {
                float newPos = Mathf.Lerp(transform.position.x, player.transform.position.x,
                    Time.deltaTime * 2f);

                if (GameHandler.Instance.GroundedCheck(new Vector2(newPos, rb.position.y), platforms))
                {
                    rb.MovePosition(new Vector2(newPos, rb.position.y));
                }
            } else if (cooldown <= 0)
            {
                GameHandler.Instance.playerStats.health -= stats.damage;
                cooldown = 60;
            }
        }
    }
}
