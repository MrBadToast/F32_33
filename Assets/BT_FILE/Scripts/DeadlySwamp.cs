using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadlySwamp : MonoBehaviour
{
    public float swampSpeed;
    public bool startOnAwake = true;

    public Transform SwampHead;
    public Transform SwampMiddle;

    private void Start()
    {
        if (startOnAwake)
            StartCoroutine(Cor_SwampFillup());
    }

    public void StartSwamp()
    {
        StartCoroutine(Cor_SwampFillup());
    }

    public void StopSwamp()
    {
        StopCoroutine(Cor_SwampFillup());
    }

    IEnumerator Cor_SwampFillup()
    {
        while (true)
        {
            yield return new WaitForFixedUpdate();
            SwampMiddle.localScale = new Vector2(SwampMiddle.localScale.x, SwampMiddle.localScale.y + swampSpeed);
            SwampHead.position = new Vector2(SwampHead.position.x,SwampHead.position.y + swampSpeed);
        }
    }
}
