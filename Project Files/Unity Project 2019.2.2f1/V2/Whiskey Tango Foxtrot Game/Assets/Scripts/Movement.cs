using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour 
{

    //Box Collider
    public BoxCollider2D boxCollider;
    
    //
    
    //Movement
    public float speed;
    public float jump;
    float moveVelocity;

    //Grounded Variable
    public bool grounded = true;
    
    //Double Jump
    public bool doublejump = false;

    void Update () 
    {
        //Jumping
        if (Input.GetKeyDown (KeyCode.W)) 
        {
            if(grounded)
            {
                GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, jump);
                grounded = false;
                doublejump = true;
            }
        }
        
        //Double Jumping
        if (doublejump == true)
        {
            if (Input.GetKeyDown(KeyCode.W))
            { 
                GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, jump);
                doublejump = false;
            }
            
        }

        moveVelocity = 0;

        //Left Right Movement
        if (Input.GetKey (KeyCode.A)) 
        {
            moveVelocity = -speed;
        }
        if (Input.GetKey (KeyCode.D)) 
        {
            moveVelocity = speed;
        }

        GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveVelocity, GetComponent<Rigidbody2D> ().velocity.y);

        //Check if Grounded
        void GroundCheck()
        {
            //raycast
            //RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, 0.1f, platforms);
            //grounded = hit.collider != null;
        }
    }
}