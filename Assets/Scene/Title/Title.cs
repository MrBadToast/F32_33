using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Title : MonoBehaviour
{
    [SerializeField]
    private Button startBtn;
    [SerializeField]
    private Button quitBtn;

    private GameObject selectUI;

    [SerializeField]
    private Transform startBtnPos;
    [SerializeField]
    private Transform quitBtnPos;

    private void Update()
    {
        if (EventSystem.current.currentSelectedGameObject == null)
        {
            if (selectUI.Equals(startBtn.gameObject))
                startBtn.Select();
            else if (selectUI.Equals(quitBtn.gameObject))
                quitBtn.Select();
        }
        else
            selectUI = EventSystem.current.currentSelectedGameObject;
    }
    public void StartGame()
    {
        SceneMove.instance.ChangeMaskPos(startBtnPos.position);
        SceneMove.instance.SceneChange(SceneName.InGame);
    }

    public void QuitGame()
    {
        SceneMove.instance.ChangeMaskPos(quitBtnPos.position);
        SceneMove.instance.SceneChange(SceneName.GameQuit);
    }

}
