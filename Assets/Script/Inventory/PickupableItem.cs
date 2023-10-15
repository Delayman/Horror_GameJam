using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupableItem : Interactable
{
    public GameObject itemButton;

    private GameObject player;
    private InventorySystem invSystem;

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
        invSystem = player.GetComponent<InventorySystem>();

        for(int i = 0; i < invSystem.slots.Length; i++)
        {
            if(invSystem.isFilled[i] == false)
            {
                invSystem.isFilled[i] = true;
                var itemButtonVal = Instantiate(itemButton, invSystem.slots[i].transform, false);
                itemButtonVal.GetComponent<SanityBottleButton>().slotNum = i;
                Destroy(this.gameObject);
                break;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D _col) 
    {
        if(_col.gameObject.tag != "Player") return;
        
        player = _col.gameObject;
        
    }
}
