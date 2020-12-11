using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class LevelObjectsManager : MonoBehaviour
{
    private static LevelObjectsManager _instance = null;
    
    public static LevelObjectsManager Instance
    {
        get
        { 
            return _instance; 
        }
    }
     
    public delegate void OnPlayerHurt();  

    public OnPlayerHurt ONPlayerHurt; // 여기에 플레이어가 피해를 입었을때 호출되는 함수들을 추가해주세요
    
    [InfoBox( "반드시 플레이어 레이어를 넣어주세요",InfoMessageType.Warning)]
    public LayerMask playerLayer;
    
    private void Awake()
    {
        if (_instance != null && _instance != this) 
        {
            Destroy(this.gameObject);
        }
 
        _instance = this;
    }
    
    
}
