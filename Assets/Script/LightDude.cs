using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightDude : MonoBehaviour
{
    private Light2D lightSfx;

    public int SoulShardCount;

    private void Start() 
    {
        lightSfx = GetComponentInChildren<Light2D>();
    }

    private void FixedUpdate() 
    {
        SoulShardCount = PlayerPrefs.GetInt("SoulShard");

        lightSfx.intensity = (SoulShardCount+1) * 2;
    }
}
