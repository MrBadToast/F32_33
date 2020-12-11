using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class PlayerHarm : MonoBehaviour
{
    private LevelObjectsManager loManager;

    private void Awake()
    {
        loManager = LevelObjectsManager.Instance;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == loManager.playerLayer.value) // 버그 가능성 있음
        {
            loManager.ONPlayerHurt();
        }
    }
}
