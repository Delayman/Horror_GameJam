using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : Interactable
{
    public GameObject warpPos1;
    public Animator  fade;

    private GameObject player;

    public override bool GetInteractBool()
    {
        return true;
    }

    public override void Interact()
    {
        Activate();
    }

    private void Activate()
    {
        fade.Play("Fade");
        player.GetComponent<Animator>().SetBool("isRun", false);
        player.GetComponent<PlayerControl>().enabled = false;
        player.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, player.GetComponent<Rigidbody2D>().velocity.y);

        Invoke("Teleport",0.5f);
    }

    private void Teleport()
    {
        player.transform.position = warpPos1.transform.position;
        player.GetComponent<PlayerControl>().enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D _col) 
    {
        if(_col.gameObject.tag != "Player") return;
        
        player = _col.gameObject;
    }
}
