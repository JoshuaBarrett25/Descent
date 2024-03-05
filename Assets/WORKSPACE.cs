/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WORKSPACE : MonoBehaviour
{
    private Vector2 input;

    private bool _isFacingRight;
    private bool _isDashing;
    private bool _isJumping;
    private bool _isPreparingJump;
    private bool _isFalling;
    private bool _isDiving;

    private bool _dashed;
    private bool _hasDblJumped;

    private bool _canDBL;

    private float _jumpCooldown;
    private float _timeLastOnGround;

    private float dblJumpSpacer = 0.05f;
    private float dblJumpTimer = 0f;

    private float _variableJumpWS;

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
        actionMapManager.playerActions = new PlayerActions();
        actionMapManager.SetActionMap(0);
        actionMapManager.playerActions.PLAY.Jump.performed += OnJump;
        actionMapManager.playerActions.PLAY.DoubleJump.performed += OnDoubleJump;
    }

    private void FixedUpdate()
    {
        input = actionMapManager.playerActions.PLAY.Move.ReadValue<Vector2>();
        Flip(input);

        if (IsGrounded())
        {
            ResetJump();
        }

        if (_jumpCooldown > 0)
        {
            _isJumping = true;
            _jumpCooldown = Time.deltaTime;

            if (IsGrounded())
            {
                _jumpCooldown = 0;
            }
        }

        if (_isPreparingJump)
        {
            if (_variableJumpWS < playerData.maxJumpingPower)
            {
                _variableJumpWS += 1f;
            }

            else
            {
                _variableJumpWS = playerData.maxJumpingPower;
            }

        }


        if (rigid.velocity.y < -0.05 && !_isJumping)
        {
            _isFalling = true;
            _timeLastOnGround += Time.deltaTime;
        }

        if (_isJumping && playerData.DBLJUMPACQUIRED)
        {
            dblJumpTimer += Time.deltaTime;

            if (dblJumpTimer >= dblJumpSpacer)
            {
                _canDBL = true;
            }

            else
            {
                _canDBL = false;
            }
        }

        if (!_isDashing)
        {
            rigid.velocity = new Vector2(input.x * playerData.speed, rigid.velocity.y);
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
        return Physics2D.OverlapCircle(groundCheck.position, 0.05f, playerData.whatIsGround);
    }

    private void ResetJump()
    {
        _isFalling = false;
        _isDiving = false;
        _dashed = false;
        _isJumping = false;
        _hasDblJumped = false;
        _canDBL = false;
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
            _variableJumpWS = playerData.minJumpingPower;
            _isPreparingJump = true;
        }

        if (context.canceled && IsGrounded() && _isPreparingJump)
        {
            _jumpCooldown += Time.deltaTime;
            _isPreparingJump = false;
            _isJumping = true;
            rigid.velocity = new Vector2(rigid.velocity.x, _variableJumpWS);
        }


        if (context.started && !IsGrounded() && !_isJumping && _timeLastOnGround <= playerData.coyoteTime)
        {
            _isJumping = true;
            _jumpCooldown += Time.deltaTime;
            rigid.velocity = new Vector2(rigid.velocity.x, playerData.maxJumpingPower * 0.8f);
            _timeLastOnGround = 0;
        }

    }

    public void OnDoubleJump(InputAction.CallbackContext context)
    {
        if (playerData.DBLJUMPACQUIRED)
        {
            if (context.canceled && _canDBL && _isJumping && !_hasDblJumped)
            {
                rigid.velocity = new Vector2(rigid.velocity.x, rigid.velocity.y + 10);
                _hasDblJumped = true;
            }
        }
    }

    public void OnDive(InputAction.CallbackContext context)
    {
        if (playerData.DIVEACQUIRED && context.performed)
        {
            _isDiving = true;
            rigid.velocity = new Vector2(rigid.velocity.x, playerData.diveSpeed);
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
        rigid.velocity = new Vector2(rigid.velocity.x, 0f);
        rigid.AddForce(new Vector2(playerData.dashSpeed * direction, 0), ForceMode2D.Impulse);
        float gravity = rigid.gravityScale;
        rigid.gravityScale = 0;
        yield return new WaitForSeconds(0.15f);
        rigid.gravityScale = 0.5f;
        rigid.AddForce(new Vector2(playerData.dashSpeed * -direction, 0), ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.15f);
        _isDashing = false;
        rigid.gravityScale = gravity;
    }
}
*/