using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathEnd : MonoBehaviour
{
    private void Start() 
    {
        Invoke("MainMenu",34f);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
