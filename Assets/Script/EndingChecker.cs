using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingChecker : MonoBehaviour
{
    public static GameManager instance;

    private int soulShardCount;

    private void Awake() 
    {
        soulShardCount = GameManager.instance.GetSoulShardCount();
    }

    private void Start() 
    {
        Invoke("CalculateEnding", 3f);
    }

    private void CalculateEnding()
    {
        if(soulShardCount >= 6)
        {
            SceneManager.LoadScene("Bad-END");
        }else if (soulShardCount < 6)
        {
            SceneManager.LoadScene("Good-END");
        }
    }
}
