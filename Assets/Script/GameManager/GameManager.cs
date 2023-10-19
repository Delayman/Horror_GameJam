using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int SoulShardCount;
    public float DeathCount;

    private void Awake() 
    {
         if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    private void Start() 
    {
        DeathCount = PlayerPrefs.GetInt("Death");
        SoulShardCount = PlayerPrefs.GetInt("SoulShard");
    }

    public int GetSoulShardCount()
    {
        return SoulShardCount;
    }

    public float GetDeath()
    {
        return DeathCount;
    }

    public void IncreaseSoulShard(int _count)
    {
        SoulShardCount += _count;
        PlayerPrefs.SetInt("SoulShard",SoulShardCount);
    }

    public void IncreaseDeath(int _count)
    {
        DeathCount += _count;
        PlayerPrefs.SetFloat("Death", DeathCount);
        SceneManager.LoadScene("Death-Menu");
    }

    public void ResetDeathCount()
    {
        PlayerPrefs.SetInt("Death", 0);
    }

    public void ResetSoulShardCount()
    {
        PlayerPrefs.SetInt("SoulShard", 0);
    }
}
