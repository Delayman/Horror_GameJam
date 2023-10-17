using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    public float maxHealth = 100;
    public float maxSanity = 100;
    public float maxStamina = 100;

    public Slider qteSlider;

    public int sanityDrainRate;
    private int savedSanityDrainLvl;

    public bool IsbetweenQte;

    private float sanity;
    private float health;
    private float stamina;
    private PlayerInteraction playerInteract;


    private void Start() 
    {
        sanity = maxSanity;
        health = maxHealth;
        stamina = maxStamina;

        qteSlider = GetComponentInChildren<Slider>();
        qteSlider.gameObject.SetActive(false);

        playerInteract = GetComponent<PlayerInteraction>();

        if(savedSanityDrainLvl == 0) 
            savedSanityDrainLvl = sanityDrainRate;
    }

    private void FixedUpdate() 
    {
        if(sanityDrainRate == 0) return;

        if(sanity < 0)
        {
            Debug.Log("i died lol");
            return;
        }

        sanity -= sanityDrainRate * Time.deltaTime;
    }

    public void LoadSanityLevel()
    {
        sanityDrainRate = savedSanityDrainLvl;
    }

    public void StopSanityDrain()
    {
        if(sanityDrainRate == 0) return;

        savedSanityDrainLvl = sanityDrainRate;
        sanityDrainRate = 0;
    }

    public void DecreaseSanityOnFailed()
    {
        sanity -= 5f;
    }

    public void UseSanityBottle()
    {
        sanity += 25f;

        if(sanity > 100f)
            sanity = 100f;
    }

    public void ManageQTESprite(string keyForQTE)
    {
        var keyArray = playerInteract.keyIconForQTE;
        var interactIcon = playerInteract.interactionIcon;

        switch (keyForQTE)
        {
            case "w": interactIcon.GetComponent<SpriteRenderer>().sprite = keyArray[1].sprite; break;
            case "a": interactIcon.GetComponent<SpriteRenderer>().sprite = keyArray[2].sprite; break;
            case "s": interactIcon.GetComponent<SpriteRenderer>().sprite = keyArray[3].sprite; break;
            case "d": interactIcon.GetComponent<SpriteRenderer>().sprite = keyArray[4].sprite; break;

            default: Debug.Log($"wtf something not right"); break;
        }

        IsbetweenQte = true;
        interactIcon.SetActive(true);
    }

    public void HideQTEButton()
    {
        IsbetweenQte = false;

        playerInteract.interactionIcon.GetComponent<SpriteRenderer>().sprite = playerInteract.keyIconForQTE[0].sprite;
        playerInteract.interactionIcon.SetActive(false);
    }
}
