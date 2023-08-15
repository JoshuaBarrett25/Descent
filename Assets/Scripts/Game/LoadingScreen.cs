using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    [Header("ScreenObject")]
    [SerializeField] private GameObject _loadingScreen;
    [SerializeField] private Image _loadingBarfill;

    [Header("MainMenuObject")]
    [SerializeField] private GameObject _main;

    public void LoadScene(int sceneID)
    {
        _main.SetActive(false);
        StartCoroutine(LoadSceneAsync(sceneID));
    }

    IEnumerator LoadSceneAsync(int sceneID)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneID);

        _loadingScreen.SetActive(true);

        while (!operation.isDone) 
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);

            _loadingBarfill.fillAmount = progress;

            yield return null;
        }
    }
}
