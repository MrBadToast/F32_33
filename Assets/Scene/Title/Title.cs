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
    private SpriteRenderer startSprite;
    [SerializeField]
    private Button quitBtn;
    [SerializeField]
    private SpriteRenderer quitSprite;

    private GameObject selectUI;

    [SerializeField]
    private Transform startBtnPos;
    [SerializeField]
    private Transform quitBtnPos;

    [SerializeField]
    private SoundModule_Base soundModule;

    private void Start()
    {
        soundModule.Play("MainMenu");
    }

    private void Update()
    {
        if (selectUI != null && EventSystem.current.currentSelectedGameObject == null)
        {
            if (selectUI.Equals(startBtn.gameObject))
                startBtn.Select();
            else if (selectUI.Equals(quitBtn.gameObject))
                quitBtn.Select();
        }
        else
            selectUI = EventSystem.current.currentSelectedGameObject;

        if(selectUI != null)
        {
            startSprite.color = Color.white;
            quitSprite.color = Color.white;

            if (selectUI.Equals(startBtn.gameObject))
                startSprite.color = Color.red;
            else if (selectUI.Equals(quitBtn.gameObject))
                quitSprite.color = Color.red;
        }
    }
    public void StartGame()
    {
        if(SceneMove.instance.SceneCanMove())
            SceneMove.instance.ChangeMaskPos(startBtnPos.position);
        SceneMove.instance.SceneChange(SceneName.InGame);
    }

    public void QuitGame()
    {
        if (SceneMove.instance.SceneCanMove())
            SceneMove.instance.ChangeMaskPos(quitBtnPos.position);
        SceneMove.instance.SceneChange(SceneName.GameQuit);
    }

}
