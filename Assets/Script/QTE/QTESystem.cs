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

    public float cdQteTimeMin, cdQteTimeMax;
    public float QteTime = 2f;
    public bool isFailedQte;

    private bool isStartedQte;
    private float QteTimeleft;
    private QTEKeys qTEKeys;

    private void Start() 
    {
        QteTimeleft = QteTime;

        // CastRandomKeys();
    }

    private void Update() 
    {
        if(!isStartedQte) return;

        if(QteTimeleft < 0)
        {
            Debug.Log("Failed to pressed QTE");

            //Decrease health of player


            isFailedQte = true;
            isStartedQte = false;
            QteTimeleft = QteTime;
            return;
        }

        QteTimeleft -= Time.deltaTime;

        if(Input.GetKeyDown(keyForQTE))
        {
            Debug.Log("Successfully to pressed QTE");

            //Spawn Item

            isFailedQte = false;
            isStartedQte = false;
            QteTimeleft = QteTime;
        }
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

        //ShowKey
        Debug.Log($"Press : {keyForQTE}");
        isStartedQte = true;
    }

    
}
