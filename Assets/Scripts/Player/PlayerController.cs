using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class PlayerController : MonoBehaviour
{
    public D_Player playerData;

    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private ActionMapManager _actionMapManager;

    [Header("Grounded Variables")]
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private Collider2D _wallCheck;
    [SerializeField] private LayerMask _groundLayer;

    private Vector2 input;

    private bool _isFacingRight;
    private bool _isDashing;
    private bool _isJumping;
    private bool _isPreparingJump;
    private bool _isFalling;
    private bool _isDiving;

    private bool _dashed;
    private bool _hasDblJumped;

    private bool canDBL;

    private float jumpCooldown;
    private float _timeLastOnGround;

    private float dblJumpSpacer = 0.05f;
    private float dblJumpTimer = 0f;

    private float variableJump;


    private void OnCollisionStay2D(Collision2D collision)
    {
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

        if (jumpCooldown > 0)
        {
            _isJumping = true;
            jumpCooldown = Time.deltaTime;

            if (IsGrounded())
            {
                jumpCooldown = 0;
            }
        }

        if (_isPreparingJump)
        {
            if (variableJump < playerData.maxJumpingPower)
            {
                variableJump += 1f;
            }

            else
            {
                variableJump = playerData.maxJumpingPower;
            }

        }

        
        if (_rb.velocity.y < -0.05 && !_isJumping)
        {
            _isFalling = true;
            _timeLastOnGround += Time.deltaTime;
        }

        if (_isJumping && playerData.DBLJUMPACQUIRED)
        {
            dblJumpTimer += Time.deltaTime;

            if (dblJumpTimer >= dblJumpSpacer)                            
            {
                canDBL = true;
            }

            else 
            {
                canDBL = false;
            }
        }

        if (!_isDashing)
        {
            _rb.velocity = new Vector2(input.x * playerData.speed, _rb.velocity.y);
        }
    }


    /// <summary>
    /// MOVEMENT SECTION
    /// All functions contained within this section are related to player movement
    /// (For example, moving, jumping, dashing)
    /// </summary>

    public bool IsGrounded()
    {
        playerData.dashSpeed = 25f;
        return Physics2D.OverlapCircle(_groundCheck.position, 0.05f, _groundLayer);
    }
                    
    private void ResetJump()
    {
        _isFalling = false;
        _isDiving = false;
        _dashed = false;
        _isJumping = false;
        _hasDblJumped = false;
        canDBL = false;
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
        if (context.started && !_isFalling && IsGrounded())
        {
            variableJump = playerData.minJumpingPower;
            _isPreparingJump = true;
        }

        if (context.canceled && IsGrounded() && _isPreparingJump)
        {
            jumpCooldown += Time.deltaTime;
            _isPreparingJump = false;
            _isJumping = true;
            _rb.velocity = new Vector2(_rb.velocity.x, variableJump);
        }

        
        if (context.started && !IsGrounded() && !_isJumping && _timeLastOnGround <= playerData.coyoteTime)
        {
            _isJumping = true;
            jumpCooldown += Time.deltaTime;
            _rb.velocity = new Vector2(_rb.velocity.x, playerData.maxJumpingPower * 0.8f);
            _timeLastOnGround = 0;
        }
        
    }

    public void OnDoubleJump(InputAction.CallbackContext context)
    {
        if (playerData.DBLJUMPACQUIRED)
        {
            if (context.canceled && canDBL && _isJumping && !_hasDblJumped)
            {
                _rb.velocity = new Vector2(_rb.velocity.x, _rb.velocity.y + 10);
                _hasDblJumped = true;
            }
        }
    }

    public void OnDive(InputAction.CallbackContext context)
    {
        if (playerData.DIVEACQUIRED && context.performed)
        {
            _isDiving = true;
            _rb.velocity = new Vector2(_rb.velocity.x, playerData.diveSpeed);
        }
    }

    public void OnDash(InputAction.CallbackContext context)
    {
        if ((context.performed && playerData.DASHACQUIRED && !_isDiving && _hasDblJumped && !IsGrounded() && !_dashed)
            ||
            (context.performed && playerData.DASHACQUIRED && !_isDiving && !playerData.DBLJUMPACQUIRED && !IsGrounded() & !_dashed))
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
        _rb.AddForce(new Vector2(playerData.dashSpeed * direction, 0), ForceMode2D.Impulse);
        float gravity = _rb.gravityScale;
        _rb.gravityScale = 0;
        yield return new WaitForSeconds(0.15f);
        _rb.gravityScale = 0.5f;
        _rb.AddForce(new Vector2(playerData.dashSpeed * -direction, 0), ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.15f);
        _isDashing = false;
        _rb.gravityScale = gravity;
    }
}
