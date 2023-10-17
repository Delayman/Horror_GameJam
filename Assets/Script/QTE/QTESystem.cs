using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QTESystem : MonoBehaviour
{
    private string keyForQTE;
    public enum QTEKeys
    {
        w,a,s,d
    }

    public GameObject itemPrefab;
    public float cdQteTimeMin, cdQteTimeMax;
    public float QteTime = 2f;
    public bool isFailedQte;

    private bool isStartedQte;
    private float QteTimeleft;
    private QTEKeys qTEKeys;

    private void Start() 
    {
        QteTimeleft = QteTime;
    }

    private void Update() 
    { 
        if(!isStartedQte) return;

        player.GetComponent<PlayerStatus>().qteSlider.gameObject.SetActive(true);

        if(QteTimeleft < 0)
        {
            // Debug.Log("Failed to pressed QTE");
            
            player.GetComponent<PlayerStatus>().DecreaseSanityOnFailed();
            player.GetComponent<PlayerStatus>().qteSlider.gameObject.SetActive(false);

            HideQTEKey();

            isFailedQte = true;
            isStartedQte = false;
            QteTimeleft = QteTime; 
            return;
        }

        if(Input.GetKeyDown(keyForQTE))
        {
            // Debug.Log("Successfully to pressed QTE");

            Instantiate(itemPrefab,this.gameObject.transform.position, Quaternion.identity);
            player.GetComponent<PlayerStatus>().qteSlider.gameObject.SetActive(false);

            HideQTEKey();

            isFailedQte = false;
            isStartedQte = false;
            QteTimeleft = QteTime;
        }

        QteTimeleft -= Time.deltaTime;

        player.GetComponent<PlayerStatus>().qteSlider.value = QteTimeleft;
    }

    public void CastRandomKeys()
    {
        qTEKeys = (QTEKeys)UnityEngine.Random.Range(0, 3);
        keyForQTE = qTEKeys.ToString();
        
        StartCoroutine(CountDownQTE());
    }

    private IEnumerator CountDownQTE()
    {
        var cdQteTime = UnityEngine.Random.Range(cdQteTimeMin, cdQteTimeMax);

        yield return new WaitForSeconds(cdQteTime);

        ShowQTEKey();
        // Debug.Log($"Press : {keyForQTE}");
        isStartedQte = true;
    }

    private void ShowQTEKey()
    {
        player.GetComponent<PlayerStatus>().ManageQTESprite(keyForQTE);
    }

    private void HideQTEKey()
    {
        player.GetComponent<PlayerStatus>().HideQTEButton();
    }

    private GameObject player;

    private void OnTriggerStay2D(Collider2D _col) 
    {
        if(_col.gameObject.tag != "Player") return;
        
        player = _col.gameObject;
    }
}
