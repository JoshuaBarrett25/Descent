using UnityEngine;


public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private GameObject parent;

    [Header("Scripts")]
    [SerializeField] private DialogueManager _dialogueManager;
    [SerializeField] private ActionMapManager _actionMapManager;
    [SerializeField] public CameraLookAt cameraLookAt;
    [SerializeField] private PlayerVariables _playerVariables;

    [Header("Assets")]
    [SerializeField] public TextAsset inkAsset;

    [Header("Object References")]
    [SerializeField] private GameObject _visualCue;
    [SerializeField] public GameObject npcLookLocation;

    private bool _playerInRange;

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            _playerVariables.dialogue = this;
            _playerVariables.interactRange = _playerInRange = true;
            _dialogueManager.currentNpc = parent;
        }
    }


    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            _playerVariables.dialogue = null;
            _playerVariables.interactRange = _playerInRange = false;
            _dialogueManager.currentNpc = null;
        }
    }


    private void Awake()
    {
        _playerInRange = false;
        _visualCue.SetActive(false);
    }


    private void FixedUpdate()
    {
        _visualCue.SetActive(_playerInRange);
    }


}
