using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddingSpot : Interactable
{
    private GameObject hidingArea;
    private GameObject player;

    private bool isHiding;

    private void Start() 
    {
        hidingArea = this.gameObject;
    }

    public override bool GetInteractBool()
    {
        return true;
    }

    public override void Interact()
    {
        isHiding = !isHiding;

        if(isHiding)
        {
            Activate();
        }else
        {
            Deactivate();
        }
        
    }

    private void Activate()
    {
        player.GetComponent<SpriteRenderer>().enabled = false;
        player.GetComponent<Animator>().SetBool("isRun", false);
        player.GetComponent<PlayerControl>().enabled = false;
        player.GetComponent<Rigidbody2D>().velocity = new Vector2(0f,  player.GetComponent<Rigidbody2D>().velocity.y);

    }

    private void Deactivate()
    {
        player.GetComponent<SpriteRenderer>().enabled = true;
        player.GetComponent<Animator>().SetBool("isRun", false);
        player.GetComponent<PlayerControl>().enabled = true;
        player.GetComponent<Rigidbody2D>().velocity = new Vector2(0f,  player.GetComponent<Rigidbody2D>().velocity.y);
    }

    private void OnTriggerStay2D(Collider2D _col) 
    {
        if(_col.gameObject.tag != "Player") return;
        
        player = _col.gameObject;
        
    }
}
