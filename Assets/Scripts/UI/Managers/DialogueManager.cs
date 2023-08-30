using Ink.Runtime;
using System.Transactions;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [Header("Object References")]
    [SerializeField] private GameObject player;
    public GameObject currentNpc;

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


    //Used to calculate the appropriate shadow direction for the dialogue panel
    //This is based from player position on either the right or left of the interact
    private void CalculatePlayerPosition()
    {
        if (currentNpc != null)
        {
            if (player.gameObject.transform.position.x < currentNpc.gameObject.transform.position.x)
            {
                _dialoguePanel.GetComponent<Shadow>().effectDistance = new Vector2(50,50);
            }

            if (player.gameObject.transform.position.x > currentNpc.gameObject.transform.position.x)
            {
                _dialoguePanel.GetComponent<Shadow>().effectDistance = new Vector2(-50, 50);
            }

            if (player.gameObject.transform.position.x == currentNpc.gameObject.transform.position.x)
            {
                _dialoguePanel.GetComponent<Shadow>().effectDistance = new Vector2(0, 0);
            }
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
        CalculatePlayerPosition();
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
            ExitDialogueMode();
        }
    }
}
