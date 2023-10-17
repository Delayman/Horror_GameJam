using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour
{
    // declaring a private instance variable
    private static Singleton instance = null;

    // creating a public accessor that will get the instace
    public static Singleton Instance
    {
        get
        {
            // test if the instance is null
            // if so, try to get it using FindObjectOfType
            if (instance == null)
                instance = FindObjectOfType<Singleton>();

            // if the instance is null again
            // create a new game object
            // attached the Singleton class on it
            // set the instance to the new attached Singleton
            // call don't destroy on load
            if (instance == null)
            {
                GameObject gObj = new GameObject();
                gObj.name = "Singleton";
                instance = gObj.AddComponent<Singleton>();
                DontDestroyOnLoad(gObj);
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
