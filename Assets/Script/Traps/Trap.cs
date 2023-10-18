using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    private bool isPlayerInArea;
    private void OnTriggerEnter2D(Collider2D _col) 
    {
        if(_col.gameObject.tag == "Player")
        {
            isPlayerInArea = true;
            StartCoroutine(DelayDamanged(_col));
        }
    }

    private void OnTriggerExit2D(Collider2D _col) 
    {
        if(_col.gameObject.tag == "Player")
        {
            isPlayerInArea = false;
        }
    }
    
    IEnumerator DelayDamanged(Collider2D _col)
    {
        yield return new WaitForSeconds(1f);
        
        if(isPlayerInArea)
        {
            _col.gameObject.GetComponent<PlayerStatus>().DecreaseSanityOnFailed();
        }

        Destroy(this.gameObject);
    }
}
