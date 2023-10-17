using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D _col) 
    {
        if(_col.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("Ending");
        }
    }
}
