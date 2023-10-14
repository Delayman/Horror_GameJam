using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.EditorTools;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [Tooltip("Set the speed of player movement")]
    public float PlayerSpeed = 10;

    [Tooltip("Set the celling of player speed")]
    public float PlayerCellingSpeed = 5;

    private Rigidbody2D rb;

    private void Start() 
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if(rb.velocity.x > PlayerCellingSpeed || rb.velocity.x < -PlayerCellingSpeed ) return;

        MovePlayer();
    }

    private void MovePlayer()
    {
        if(Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector2.left * PlayerSpeed);
        }else
        if(Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector2.right * PlayerSpeed);
        }else
        {
            StopPlayer();
        }
    }

    private void StopPlayer()
    {
        rb.velocity = new Vector2(0f,rb.velocity.y);
    }
}
