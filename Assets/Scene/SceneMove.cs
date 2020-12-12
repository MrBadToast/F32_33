using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public enum SceneName
{
    Title,GameQuit,InGame
}

public class SceneMove : MonoBehaviour
{
    public static SceneMove instance;

    [SerializeField]
    private SpriteRenderer screenRenderer;
    [SerializeField]
    private GameObject mask;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
            Destroy(this.gameObject);
    }

    public void SceneChange(SceneName sceneName)
    {
        StartCoroutine(CaptureScreen(sceneName));
    }

    public void ChangeMaskPos(Vector2 pos)
    {
        mask.transform.position = pos;
    }

    IEnumerator CaptureScreen(SceneName sceneName)
    {
        Texture2D texture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        yield return new WaitForEndOfFrame();
        texture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0, false);
        texture.Apply();
        screenRenderer.sprite = Sprite.Create(texture, new Rect(Vector2.zero, new Vector2(texture.width, texture.height)),Vector2.zero);
        mask.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene(sceneName.ToString());
    }
}
