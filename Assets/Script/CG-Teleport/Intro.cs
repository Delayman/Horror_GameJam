using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    private void Start() 
    {
        Invoke("MainMenu",81f);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
