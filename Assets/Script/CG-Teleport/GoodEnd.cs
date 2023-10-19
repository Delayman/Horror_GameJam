using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoodEnd : MonoBehaviour
{
    private void Start() 
    {
        Invoke("MainMenu",58f);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
