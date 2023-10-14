using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSanity : MonoBehaviour
{
    private GameObject player;
    private PlayerStatus status;

    private void OnTriggerEnter2D(Collider2D _col) 
    {
        if(_col.gameObject.tag != "Player") return;
        
        player = _col.gameObject;
        status = player.GetComponent<PlayerStatus>();    

        status.StopSanityDrain();   
    }

    private void OnTriggerExit2D(Collider2D _col) 
    {
        if(_col.gameObject.tag != "Player") return;

        player = _col.gameObject;
        status = player.GetComponent<PlayerStatus>();    

        status.LoadSanityLevel();   
    }
}
