using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchItem : Interactable
{
    private QTESystem qTESystem;

    private void Start() 
    {
        qTESystem = GetComponent<QTESystem>();
    }

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
        this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        qTESystem.CastRandomKeys();
    }
}
