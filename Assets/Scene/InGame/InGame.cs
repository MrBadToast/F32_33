using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGame : MonoBehaviour
{
    [SerializeField]
    private SoundModule_Base soundModule;

    private void Start()
    {
        soundModule.Play("StageInGame");
    }

}
