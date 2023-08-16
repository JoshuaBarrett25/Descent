using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    [Header("Object References")]
    [SerializeField] private Player _player;
    [SerializeField] private ActionMapManager _actionMapManager;
    [SerializeField] private GameObject _startMenu;

    [Header("First Button Selected")]
    [SerializeField] private MenuOptionsSelected _optionsSelected;
    [SerializeField] private GameObject button;

    public static bool isPaused;

    public void OnEscape(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            //Go to UI map if paused
            if (isPaused)
            {
                _optionsSelected.SetNewSelected(button);
                _startMenu.SetActive(false);
                isPaused = false;
                _actionMapManager.SetActionMap(0);
                return;
            }

            //Return to PLAY map if unpaused
            else if (!isPaused)
            {
                _startMenu.SetActive(true);
                isPaused = true;
                _actionMapManager.SetActionMap(1);
                return;
            }
        }
    }
}
