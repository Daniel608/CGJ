using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevationScript : MonoBehaviour
{
    public Rigidbody2D player_rb;
    GameObject player;

    public float elevation_force;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player_rb = player.GetComponent<Rigidbody2D>();
    }
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player_rb.AddForce(Vector2.up * elevation_force);
        }
    }
}
