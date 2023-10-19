using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    public float maxHealth = 100;
    public float maxSanity = 100;
    public Slider sanitySlider;
    public float maxStamina = 100;
    public Slider staminaSlider;

    public Slider qteSlider;

    public float sanityDrainRate;
    private float savedSanityDrainLvl;

    public bool IsbetweenQte;
    public bool IsRunning;

    private float sanity;
    private float health;
    public float stamina;
    private PlayerInteraction playerInteract;

    //Sigleton
    public static GameManager instance;

    private void Awake() 
    {
        GameManager.instance.ResetSoulShardCount();
    }

    private void Start() 
    {
        sanity = maxSanity;
        health = maxHealth;
        stamina = maxStamina;

        qteSlider = GetComponentInChildren<Slider>();
        qteSlider.gameObject.SetActive(false);

        playerInteract = GetComponent<PlayerInteraction>();

        float deathCount =  GameManager.instance.GetDeath();
        
        if(deathCount > 0)
        {
            sanityDrainRate += deathCount/10;
            savedSanityDrainLvl = sanityDrainRate;
        }

        if(deathCount >= 5)
        {
            sanityDrainRate = 1.5f;
            savedSanityDrainLvl = sanityDrainRate;
        }

        if(savedSanityDrainLvl == 0) 
            savedSanityDrainLvl = sanityDrainRate;
    }

    private void Update() 
    {
        if(IsRunning)
        {
            stamina -= 10f * Time.deltaTime;
        }else
        {
            if(stamina >= 100) return;

            stamina += 5f * Time.deltaTime;
        }
    }

    private void FixedUpdate() 
    {
        sanitySlider.value = sanity;
        staminaSlider.value = stamina;

        if(sanityDrainRate == 0) return;

        if(sanity < 0)
        {
            GameManager.instance.IncreaseDeath(1);
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
        sanity += 40f;

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
