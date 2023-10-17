using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public float maxHealth = 100;
    public float maxSanity = 100;
    public int sanityDrainRate;
    private int savedSanityDrainLvl;

    private float sanity;
    private float health;

    private void Start() 
    {
        sanity = maxSanity;
        health = maxHealth;

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

    public void DecreaseHealth()
    {
        health -= 5f;
    }

    public void UseHealthBottle()
    {
        //ON HOLD

        health += 25f;

        if(health > 100f)
            health = 100f;
    }

    public void UseSanityBottle()
    {
        sanity += 25f;

        if(sanity > 100f)
            sanity = 100f;
    }
}
