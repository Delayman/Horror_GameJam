using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    private void Start() 
    {
        Invoke("LoadLevel",81f);
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene("test");
    }
}
