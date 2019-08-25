using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public Rigidbody2D rb;
    //public int Speed;
    public int Speed,JumpForce;

    bool Doublejump, CanJump;

    private void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {

        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            rb.AddForce(Vector2.right * Speed);
        }
        if (Input.GetKey("a") || Input.GetKey("left"))
        {
            rb.AddForce(Vector2.left * Speed);
        }
        if (CanJump == true)
        {
            Debug.Log("Can Jump");
            if (Input.GetButtonDown("Jump"))
            {
                rb.AddForce(Vector2.up * JumpForce);
                //Doublejump = true;
            }           
        }
        if (Doublejump == true)
        {
            if (Input.GetButtonDown("Jump"))
            {
                rb.AddForce(Vector2.up * JumpForce * 1.4f);
                Doublejump = false;
                Debug.Log("double jumped");
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        CanJump = true;
        Doublejump = false;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        CanJump = false;
        Doublejump = true;
    }
}
