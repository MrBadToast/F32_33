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

    IEnumerator Cor_SwampFillup()
    {
        while (true)
        {
            yield return null;
        }
    }
}
