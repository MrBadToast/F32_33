using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using TMPro.TextMeshPro;

[System.Serializable]
public class CutscenePair
{
    public Sprite image;
    public string text;
}

public class IntroCutscene : MonoBehaviour
{
    public CutscenePair[] cutsceneList;

    private int cutsceneCount = 0;
    
    
}
