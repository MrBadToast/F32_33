using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadlySwamp : MonoBehaviour
{
    public float swampSpeed;
    public float stanbyTime = 2.0f;
    public bool startOnAwake = true;

    public Transform SwampHead;
    public Transform SwampMiddle;
    
    
    private void Start()
    {
        Debug.Log(LevelObjectsManager.Instance);
        LevelObjectsManager.Instance.ONPlayerHurt += StopSwamp;
        Debug.Log("d1");
        
        if (startOnAwake)
            StartCoroutine(Cor_SwampFillup());
        
    }
    

    private void OnDisable()
    {
        LevelObjectsManager.Instance.ONPlayerHurt -= StopSwamp;
    }

    public void StartSwamp()
    {
        StartCoroutine(Cor_SwampFillup());
    }

    public void StopSwamp()
    {
        StopAllCoroutines();
    }

    IEnumerator Cor_SwampFillup()
    {
        //a
        yield return new WaitForSeconds(stanbyTime);
        
        while (true)
        {
            yield return new WaitForFixedUpdate();
            SwampMiddle.localScale = new Vector2(SwampMiddle.localScale.x, SwampMiddle.localScale.y + swampSpeed);
            SwampHead.position = new Vector2(SwampHead.position.x,SwampHead.position.y + swampSpeed);
        }
    }
    
    
}
