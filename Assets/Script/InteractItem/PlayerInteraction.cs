using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerInteraction : MonoBehaviour
{
    public GameObject interactionIcon;

    private GameObject currentObj;
    private bool successfulHit;
    private bool isInZone;

    private void Start()
    {
        interactionIcon = GameObject.FindGameObjectWithTag("InteractTextField");
    }

    private void Update() 
    {
        if(isInZone)
        {
            var interactable = currentObj.GetComponent<Interactable>();
            // var objCheck = currentObj.gameObject;
            // Debug.Log(objCheck.name);
        
            if (interactable != null)
            {
                interactionIcon.SetActive(interactable.GetInteractBool());
                HandleInteraction(interactable);
                successfulHit = true;
            }
        }else
        {
            successfulHit = false;

            if (!successfulHit && interactionIcon != null) interactionIcon.SetActive(false);
        }
    }

    private void HandleInteraction(Interactable interactable)
    {
        const KeyCode key = KeyCode.E;

        switch (interactable.interactionType)
        {
            case Interactable.InteractionType.Click:
                if (Input.GetKeyDown(key))
                {
                    interactable.Interact();
                }
                break;
            case Interactable.InteractionType.Hold:
                if (Input.GetKey(key))
                {
                    interactable.IncreaseHoldTime();
                    if (interactable.GetHoldTime() > 1f) 
                    {
                        interactable.Interact();
                        interactable.ResetHoldTime();
                    }
                }
                else
                {
                    interactable.ResetHoldTime();
                }
                break;
            default:
                throw new System.Exception("Unsupported type of interactable.");
        }
    }

    private void OnTriggerStay2D(Collider2D _col) 
    {
        if(_col.gameObject.tag != "InteractArea") return;

        currentObj = _col.gameObject;
        isInZone = true;
    }

    private void OnTriggerExit2D(Collider2D _col)
    {
        if(_col.gameObject.tag != "InteractArea") return;

        isInZone = false;

        
    }
}