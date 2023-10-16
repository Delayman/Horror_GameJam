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
        qTESystem.CastRandomKeys();
    }
}
