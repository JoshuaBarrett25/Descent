using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.UI;
using UnityEngine.InputSystem;

public class MenuOptionsSelected : MonoBehaviour
{
    [Header("EventSystem")]
    [SerializeField] private EventSystem _eventSystem;

    [Header("InputSystem")]
    [SerializeField] private InputSystemUIInputModule _inputSystem;

    [Header("Next Selected")]
    public GameObject newSelected;

    private bool switched = false;

    private void Start()
    {
        switched = true;
    }

    private void FixedUpdate()
    {
        if (switched)
        {
            if (_inputSystem.submit.action.phase == InputActionPhase.Waiting)
            {
                _eventSystem.SetSelectedGameObject(newSelected);
                switched = false;
            }
        }
    }

    public void SetNewSelected(GameObject selected)
    {
        newSelected = selected;
        switched = true;
    }
}
