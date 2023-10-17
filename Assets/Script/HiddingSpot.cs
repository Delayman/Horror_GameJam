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
        player.GetComponent<PlayerControl>().enabled = false;

    }

    private void Deactivate()
    {
        player.GetComponent<SpriteRenderer>().enabled = true;
        player.GetComponent<PlayerControl>().enabled = true;
    }

    private void OnTriggerStay2D(Collider2D _col) 
    {
        if(_col.gameObject.tag != "Player") return;
        
        player = _col.gameObject;
        
    }
}
