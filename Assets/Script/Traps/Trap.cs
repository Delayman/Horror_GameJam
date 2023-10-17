using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D _col) 
    {
        if(_col.gameObject.tag == "Player")
        {
            _col.gameObject.GetComponent<PlayerStatus>().DecreaseSanityOnFailed();
            Destroy(this.gameObject);
        }
    }
}
