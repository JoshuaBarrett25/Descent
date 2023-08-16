using UnityEngine;

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
