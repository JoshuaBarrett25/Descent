using Ink.Runtime;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class DialogueManager : MonoBehaviour
{
    [Header("Scripts")]
    [SerializeField] private ActionMapManager _actionMapManager;
    [SerializeField] private CameraLookAt _cameraLookAt;

    [Header("Dialogue")]
    [SerializeField] private GameObject _dialoguePanel;
    [SerializeField] private TextMeshProUGUI _dialogueText;
    [SerializeField] private float _advanceCooldown;

    private float _advanceTimer;

    private Story _currentStory;
    private static DialogueManager _instance;

    private bool _dialogueIsPlaying;
    private bool _canAdvance = true;

    private void Start()
    {
        _advanceTimer = _advanceCooldown;
        _dialogueIsPlaying = false;
        _dialoguePanel.SetActive(false);
    }


    private void Awake()
    {
        if (_instance != null)
        {
            Debug.Log("Found more than one dialogue manager");
        }
        _instance = this;
    }

    private void FixedUpdate()
    {
        if (!_dialogueIsPlaying)
        {
            return;
        }

        if (!_canAdvance)
        {
            TextAdvanceTimer();
        }
    }


    private void TextAdvanceTimer()
    {
        _advanceTimer -= Time.deltaTime;
        if (_advanceTimer <= 0f)
        {
            _advanceTimer = _advanceCooldown;
            _canAdvance = true;
        }
    }


    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.performed && _canAdvance)
        {
            ContinueStory();
            _canAdvance = false;
        }
    }


    public static DialogueManager GetInstance()
    {
        return _instance;
    }


    public void EnterDialogueMode(TextAsset inkJSON)
    {
        _currentStory = new Story(inkJSON.text);
        _dialogueIsPlaying = true;
        _dialoguePanel.SetActive(true);

        ContinueStory();
    }

    private void ExitDialogueMode()
    {
        _dialogueIsPlaying = false;
        _dialoguePanel.SetActive(false);
        _dialogueText.text = "";
    }

    private void ContinueStory()
    {
        if (_currentStory.canContinue)
        {
            _dialogueText.text = _currentStory.Continue();
        }
        else
        {
            _actionMapManager.SetActionMap(0);
            _cameraLookAt.SwitchToPlayerLookAt();
            ExitDialogueMode();
        }
    }
}
