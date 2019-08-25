using UnityEngine;

//The movement of player
[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    /// <summary>
    /// The rigidbody
    /// </summary>
    private Rigidbody2D rb;

    /// <summary>
    /// The awake method
    /// </summary>
    private void Awake()
    {
        //The rigidbody init
        rb = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Gets input
    /// </summary>
    /// <returns>vector2</returns>
    private Vector2 GetInput()
    {
        //The input axis
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        //The value
        return new Vector2(horizontal, vertical);
    }

    /// <summary>
    /// Fixed Update
    /// </summary>
    private void FixedUpdate()
    {
        //The destination
        Vector3 destination = GetInput();
        destination = destination.normalized * Time.fixedDeltaTime * GameHandler.Instance.speed;

        //Move the player
        rb.MovePosition(destination + transform.position);
    }
}
