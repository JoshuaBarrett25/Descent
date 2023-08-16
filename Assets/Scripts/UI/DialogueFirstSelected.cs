using UnityEngine;
using UnityEngine.EventSystems;

public class DialogueFirstSelected : MonoBehaviour
{
    [SerializeField] private EventSystem _eventSystem;
    public GameObject navigationButton;

    public void SetNavigationOption(GameObject navButton)
    {
        navigationButton = navButton;
        _eventSystem.firstSelectedGameObject = navigationButton;
    }

    public void EmptyButton()
    {
        navigationButton = null;
    }
}
