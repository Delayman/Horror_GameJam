using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public float maxSanity = 100;
    public int sanityDrainRate;
    private int savedSanityDrainLvl;

    private float sanity;

    private void Start() 
    {
        sanity = maxSanity;
    }

    private void FixedUpdate() 
    {
        if(sanityDrainRate == 0) return;

        if(sanity < 0)
        {
            Debug.Log("i died");
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
        savedSanityDrainLvl = sanityDrainRate;
        sanityDrainRate = 0;
    }
}
