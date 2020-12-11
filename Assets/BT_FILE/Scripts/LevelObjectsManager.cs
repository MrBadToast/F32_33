using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelObjectsManager : MonoBehaviour
{
    private static LevelObjectsManager instance = null;
    
    public static LevelObjectsManager Instance
    {
        get
        { 
            return instance; 
        }
    }
     
    public delegate void OnPlayerHurt();
    
    private void Awake()
    {
        if (instance != null && instance != this) 
        {
            Destroy(this.gameObject);
        }
 
        instance = this;
    }

    
}
