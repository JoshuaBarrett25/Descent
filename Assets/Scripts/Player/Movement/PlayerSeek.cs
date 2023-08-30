using UnityEngine;
using UnityEngine.InputSystem;
using Pathfinding;

public class PlayerSeek : MonoBehaviour
{
    [Header("Player")]
    public PlayerActions playerActions;

    [Header("Pathfinding")]
    private float _pathUpdateSeconds = 0.5f;
    public Transform listenLocation;
    private Seeker _seeker;
    private Path _path;
    private int _currentWaypoint;
    private bool _directionLookEnabled;
    private bool _isPathing;
    private bool _isGrounded;

    [Header("Physics")]
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private float _speed = 200f;
    [SerializeField] private float _nextWayPointDistance = 3f;

    public bool interactable;
    public bool inConvo;

    public void Start()
    {
        _seeker = GetComponent<Seeker>();
        _rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0f, _pathUpdateSeconds);
    }


    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.canceled && interactable)
        {
            _isPathing = true;
            playerActions.PLAY.Disable();
            playerActions.UI.Enable();
        }
    }

    private void FixedUpdate()
    {
        if (_isPathing)
        {
            PathFollow();
        }
    }

    private void UpdatePath()
    {
        if (_isPathing && _seeker.IsDone())
        {
            _seeker.StartPath(_rb.position, listenLocation.position, OnPathComplete);
        }
    }

    private void PathFollow()
    {
        if (_path == null)
        {
            return;
        }

        //Path end point reached
        if (_currentWaypoint >= _path.vectorPath.Count)
        {
            _isPathing = false;
            playerActions.PLAY.Enable();
            playerActions.UI.Disable();
            return;
        }

        Vector2 direction = ((Vector2)_path.vectorPath[_currentWaypoint] - _rb.position).normalized;
        Vector2 force = direction * _speed * Time.deltaTime;

        _rb.AddForce(force);

        float distance = Vector2.Distance(_rb.position, _path.vectorPath[_currentWaypoint]);
        if (distance < _nextWayPointDistance)
        {
            _currentWaypoint++;
        }

        if (_directionLookEnabled)
        {
            if (_rb.velocity.x > 0.05f)
            {
                transform.localScale = new Vector3(-1f * Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }

            else if (_rb.velocity.x < -0.05f)
            {
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
        }
    }

    private void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            _path = p;
            _currentWaypoint = 0;
        }
    }
}
