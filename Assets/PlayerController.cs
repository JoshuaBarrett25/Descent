using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private PlayerVariables _playerVariables;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private ActionMapManager _actionMapManager;

    [Header("Grounded Variables")]
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private Collider2D _wallCheck;
    [SerializeField] private LayerMask _groundLayer;

    private Vector2 input;
    private bool _isFacingRight;
    private bool _dashed;
    private bool _isDashing;
    private bool _isJumping;
    private bool _hasDblJumped;
    private bool _isDiving;


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
        _actionMapManager.playerActions = new PlayerActions();
        _actionMapManager.SetActionMap(0);
        _actionMapManager.playerActions.PLAY.Jump.performed += OnJump;
        _actionMapManager.playerActions.PLAY.DoubleJump.performed += OnDoubleJump;
    }

    private void FixedUpdate()
    {
        input = _actionMapManager.playerActions.PLAY.Move.ReadValue<Vector2>();
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
            _rb.velocity = new Vector2(input.x * _playerVariables.speed, _rb.velocity.y);
        }
    }


    /// <summary>
    /// MOVEMENT SECTION
    /// All functions contained within this section are related to player movement
    /// (For example, moving, jumping, dashing)
    /// </summary>

    public bool IsGrounded()
    {
        _playerVariables.dashSpeed = 11f;
        return Physics2D.OverlapCircle(_groundCheck.position, 0.2f, _groundLayer);
    }

    private void ResetJump()
    {
        _isDiving = false;
        _dashed = false;
        _isJumping = false;
        _hasDblJumped = false;
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

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.started && IsGrounded())
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _playerVariables.jumpingPower);
        }

        if (context.started && _rb.velocity.y > 0f)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _rb.velocity.y * 0.5f);
        }
    }

    public void OnDoubleJump(InputAction.CallbackContext context)
    {
        if (_playerVariables.DBLJUMPACQUIRED)
        {
            if (context.performed && _isJumping && !_hasDblJumped)
            {
                _rb.velocity = new Vector2(_rb.velocity.x, _playerVariables.jumpingPower * 0.75f);
                _hasDblJumped = true;
            }
        }
    }

    public void OnDive(InputAction.CallbackContext context)
    {
        if (_playerVariables.DIVEACQUIRED && context.performed)
        {
            _isDiving = true;
            _rb.velocity = new Vector2(_rb.velocity.x, _playerVariables.diveSpeed);
        }
    }

    public void OnDash(InputAction.CallbackContext context)
    {
        if ((context.performed && _playerVariables.DASHACQUIRED && !_isDiving && _hasDblJumped && !IsGrounded() && !_dashed)
            ||
            (context.performed && _playerVariables.DASHACQUIRED && !_isDiving && !_playerVariables.DBLJUMPACQUIRED && !IsGrounded() & !_dashed))
        {
            StartCoroutine(Dashing(1f));
            _dashed = true;
        }
    }

    IEnumerator Dashing(float direction)
    {
        if (!_isFacingRight)
        {
            direction = -direction;
        }
        _isDashing = true;
        _rb.velocity = new Vector2(_rb.velocity.x, 0f);
        _rb.AddForce(new Vector2(_playerVariables.dashSpeed * direction, 0), ForceMode2D.Impulse);
        float gravity = _rb.gravityScale;
        _rb.gravityScale = 0;
        yield return new WaitForSeconds(0.15f);
        _rb.gravityScale = 0.5f;
        _rb.AddForce(new Vector2(_playerVariables.dashSpeed * -direction, 0), ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.15f);
        _isDashing = false;
        _rb.gravityScale = gravity;
    }
}
