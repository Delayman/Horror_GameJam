using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.EditorTools;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [Tooltip("Set the speed of player movement")]
    public float PlayerSpeed = 10;
    [Tooltip("Set the running speed of player")]
    public float PlayerSprintSpeed = 1.5f;
    [Tooltip("Set the celling of player speed")]
    public float PlayerCellingSpeed = 5;
    [Tooltip("Set the celling of player speed when running")]
    public float PlayerCellingSprintSpeed = 8;

    private Rigidbody2D rb;
    private GameObject interactButton;
    private Animator animator;
    private float savedCellingSpeed;

    private void Start() 
    {
        rb = GetComponent<Rigidbody2D>();
        interactButton = GetComponent<PlayerInteraction>().interactionIcon;
        animator =  GetComponent<Animator>();

        savedCellingSpeed = PlayerCellingSpeed;
    }

    private void FixedUpdate()
    {
        if(rb.velocity.x > PlayerCellingSpeed || rb.velocity.x < -PlayerCellingSpeed ) return;

        MovePlayer();
    }

    private void MovePlayer()
    {   
        // Debug.Log($"Current Speed : {rb.velocity}");
        if(Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector2.left * PlayerSpeed);
            animator.SetBool("isWalk", true);

            this.gameObject.transform.localScale = new Vector3(0.5f, this.gameObject.transform.localScale.y, this.gameObject.transform.localScale.z);
            interactButton.gameObject.transform.localScale = new Vector3(19f, 19, 19f);

            if(Input.GetKey(KeyCode.LeftShift))
            {
                rb.AddForce(Vector2.left * PlayerSpeed * PlayerSprintSpeed);
                PlayerCellingSpeed = PlayerCellingSprintSpeed;

                animator.SetBool("isRun", true);
                return;
            }else
            {
                PlayerCellingSpeed = savedCellingSpeed;
                rb.velocity = new Vector2(-19f,rb.velocity.y);

                animator.SetBool("isRun", false);
                return;
            }

        }else
        if(Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector2.right * PlayerSpeed);
            animator.SetBool("isWalk", true);

            this.gameObject.transform.localScale = new Vector3(-0.5f, this.gameObject.transform.localScale.y, this.gameObject.transform.localScale.z);
            interactButton.gameObject.transform.localScale = new Vector3(-19f, 19, 19f);

            if(Input.GetKey(KeyCode.LeftShift))
            {
                rb.AddForce(Vector2.right * PlayerSpeed * PlayerSprintSpeed);
                PlayerCellingSpeed = PlayerCellingSprintSpeed;

                animator.SetBool("isRun", true);
                return;
            }else
            {
                PlayerCellingSpeed = savedCellingSpeed;
                rb.velocity = new Vector2(19f,rb.velocity.y);

                animator.SetBool("isRun", false);
                return;
            }
            
        }else
        {
            StopPlayer();
        }
    }

    private void StopPlayer()
    {
        rb.velocity = new Vector2(0f,rb.velocity.y);
        PlayerCellingSpeed = savedCellingSpeed;

        animator.SetBool("isWalk", false);
        animator.SetBool("isRun", false);
    }
}
