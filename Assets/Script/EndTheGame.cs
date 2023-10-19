using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTheGame : Interactable
{
    private bool isIn;
    
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
        if(isIn)
        {
            SceneManager.LoadScene("Ending");
        }
    }

    private void OnTriggerEnter2D(Collider2D _col) 
    {
        if(_col.gameObject.tag != "Player") return;

        isIn = true;
    }

    private void OnTriggerExit2D(Collider2D _col) 
    {
        if(_col.gameObject.tag != "Player") return;

        isIn = false;
    }
}
