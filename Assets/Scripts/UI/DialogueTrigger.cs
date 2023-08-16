using UnityEngine;


public class DialogueTrigger : MonoBehaviour
{
    [Header("Scripts")]
    [SerializeField] private ActionMapManager _actionMapManager;
    [SerializeField] public CameraLookAt cameraLookAt;
    [SerializeField] private Player _player;

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
            _player._dialogue = this;
            _player.interactRange = _playerInRange = true;

        }
    }


    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            _player._dialogue = null;
            _player.interactRange = _playerInRange = false;
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
