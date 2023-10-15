using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SanityBottleButton : MonoBehaviour
{
    public int slotNum;

    private InventorySystem invSystem;

    private void Start() 
    {
        invSystem = GameObject.FindGameObjectWithTag("Player").GetComponent<InventorySystem>();
    }

    public void UseSanityBottle()
    {
        ConsumeSanityBottle();

        for(int i = 0; i < invSystem.slots.Length; i++)
        {
            if(i == slotNum)
            {
                invSystem.isFilled[i] = false;
                Destroy(this.gameObject);
                break;
            }
        }
    }

    private void ConsumeSanityBottle()
    {
        //Increase Sanity gague
        throw new NotImplementedException();
    }

    public void UseLightShard()
    {
        ConsumeLightShard();

        for(int i = 0; i < invSystem.slots.Length; i++)
        {
            if(i == slotNum)
            {
                invSystem.isFilled[i] = false;
                Destroy(this.gameObject);
                break;
            }
        }
    }

    private void ConsumeLightShard()
    {
        //Increase Level of light dude
        throw new NotImplementedException();
    }
}
