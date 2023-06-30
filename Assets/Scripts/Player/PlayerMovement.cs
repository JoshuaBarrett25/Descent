using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Rendering;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{ 
    private float _jumpingPower = 16f;
    [Header("Object References")]
    [SerializeField] private PlayerAbilities _playerAbilities;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private Collider2D _wallCheck;
    [SerializeField] private LayerMask _groundLayer;
    public PlayerInput playerInput;
    public PlayerActions playerActions;

    public GameObject[] uiElements;

    [Header("Values")]
    [SerializeField] private float _speed;
    [SerializeField] private float _dashSpeed;

    private Vector2 input;
    private bool _isFacingRight;
    private bool _dashed;
    private bool _isDashing;
    private bool _isJumping;
    private bool _hasDblJumped;

    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("Hit");
        if (collision.gameObject.layer == 6)
        {
            _isDashing = false;
            StopCoroutine(Dashing(0f));
        }
    }

    private void Awake()
    {
        playerActions = new PlayerActions();
        playerActions.Play.Enable();

        playerActions.Play.Jump.performed += OnJump;
        playerActions.Play.DoubleJump.performed += OnDoubleJump;
    }

    private void FixedUpdate()
    {
        Debug.Log(playerActions.Play.Move.ReadValue<Vector2>());
        input = playerActions.Play.Move.ReadValue<Vector2>();
        Flip(input);

        if (IsGrounded())
        {
            ResetJump();
        }

        if (!IsGrounded())
        {
            _isJumping = true;
        }


        if (!_isDashing)
        {
            _rb.velocity = new Vector2(input.x * _speed, _rb.velocity.y);
        }
    }


    private void Flip(Vector2 input)
    {
        if (_isFacingRight && input.x < 0f || !_isFacingRight && input.x > 0f)
        {
            _isFacingRight = !_isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    /// <summary>
    /// MOVEMENT SECTION
    /// All functions contained within this section are related to player movement
    /// (For example, moving, jumping, dashing)
    /// </summary>

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.started && IsGrounded())
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpingPower);
        }

        if (context.started && _rb.velocity.y > 0f)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _rb.velocity.y * 0.5f);
        }
    }

    public void OnDoubleJump(InputAction.CallbackContext context)
    {
        if (_playerAbilities.DBLJUMPACQUIRED)
        {
            if (context.started && _isJumping && !_hasDblJumped)
            {
                _rb.velocity = new Vector2(_rb.velocity.x, _jumpingPower * 0.75f);
                _hasDblJumped = true;
            }
        }
    }


    private bool IsGrounded()
    {
        _dashSpeed = 11f;
        return Physics2D.OverlapCircle(_groundCheck.position, 0.2f, _groundLayer);
    }

    private void ResetJump()
    {
        _dashed = false;
        _isJumping = false;
        _hasDblJumped = false;
    }

    public void OnDash(InputAction.CallbackContext context)
    {
        if ((context.performed && _playerAbilities.DASHACQUIRED && _hasDblJumped && !IsGrounded() && !_dashed) 
            || 
            (context.performed && _playerAbilities.DASHACQUIRED && !_playerAbilities.DBLJUMPACQUIRED && !IsGrounded() & !_dashed))
        {
            StartCoroutine(Dashing(1f));
            _dashed = true;
        }
    }

    IEnumerator Dashing (float direction)
    {
        if (!_isFacingRight)
        {
            direction = -direction;
        }
        _isDashing = true;
        _rb.velocity = new Vector2(_rb.velocity.x, 0f);
        _rb.AddForce(new Vector2(_dashSpeed * direction, 0), ForceMode2D.Impulse);
        float gravity = _rb.gravityScale;
        _rb.gravityScale = 0;
        yield return new WaitForSeconds(0.15f);
        _rb.gravityScale = 0.5f;
        _rb.AddForce(new Vector2(_dashSpeed * -direction, 0), ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.15f);
        _isDashing = false;
        _rb.gravityScale = gravity;
    }


    /// <summary>
    /// Menu Related Inputs
    /// Any function that require player inputs to activate menus are contained within this section
    /// (For example, startmenu, inventory)
    /// </summary>

    public void OnStartMenu(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            playerActions.Play.Disable();
            playerActions.StartMenu.Enable();

            Debug.Log(playerInput.currentActionMap.name);
            uiElements[0].SetActive(true);
            uiElements[1].SetActive(false);
        }
    }
}
