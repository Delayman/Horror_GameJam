using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTest : Interactable
{
    private GameObject player;
    public GameObject teleportDown,teleportUp;
    
    private bool isTriggered;

    public override string GetDescription()
    {
        return "E";
    }

    public override void Interact()
    {
        Activate();
    }

    private void Activate()
    {
        isTriggered = !isTriggered;

        if(isTriggered)
        {
            player.transform.position = teleportDown.transform.position;
        }
        else
        {
            player.transform.position = teleportUp.transform.position;
        }
    }

    private void OnTriggerStay2D(Collider2D _col) 
    {
        if(_col.gameObject.tag != "Player") return;
        
        player = _col.gameObject;
        
    }
}
