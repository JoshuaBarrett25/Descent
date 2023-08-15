using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuFunctionality : MonoBehaviour
{
    [SerializeField] private LoadingScreen _loadingScreen;

    public void OnResume()
    {
        _loadingScreen.LoadScene(1);
    }


    public void OnQuit()
    {
        Application.Quit();
    }
}
