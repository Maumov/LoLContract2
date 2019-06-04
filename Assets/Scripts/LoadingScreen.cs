using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadingScreen : MonoBehaviour
{
    public string scene;

    private void Start()
    {
        ChangeLevel();
    }

    public void ChangeLevel()
    {
        StartCoroutine(LoadBackgroundScene());
    }

    IEnumerator LoadBackgroundScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(scene);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}