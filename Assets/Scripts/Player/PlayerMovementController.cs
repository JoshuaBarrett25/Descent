using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementController : MonoBehaviour
{
    public Player player;

    [SerializeField] private D_Player playerData;
    protected Vector2 input;

    private bool _isJumping;
    private bool _isDashing;
    private bool _isFalling;

    private float _jumpCooldown;
    private float _velocityDelta;

    private bool _hasDashed;


    private void Start()
    {
        player = gameObject.GetComponent<Player>();
    }

    private void FixedUpdate()
    {
        player.playerActions.Play.Jump.performed += OnJump;

        if (player.CheckGround())
        {
            _isFalling = false;
            _isJumping = false;

            _hasDashed = false;
        }

        if (_isJumping)
        {
            if (_velocityDelta < player.rigid.position.y)
            {
                _velocityDelta = player.rigid.position.y;
            }

            else
            {
                _isJumping = false;
                _isFalling = true;
            }
        }

        if (_jumpCooldown > 0)
        {
            _isJumping = true;
            _jumpCooldown = Time.deltaTime;

            if (player.CheckGround())
            {
                _jumpCooldown = 0;
            }
        }

        OnMove();
    }

    public void OnMove()
    {
        input = player.playerActions.Play.Move.ReadValue<Vector2>();
        if (!_isDashing)
        {
            player.rigid.velocity = new Vector2(input.x * playerData.speed, player.rigid.velocity.y);
        }

        if (player.rigid.velocity.x > 0f && !player.facingRight)
        {
            player.FlipPlayer();
        }

        if (player.rigid.velocity.x < 0f && player.facingRight)
        {
            player.FlipPlayer();
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.started && !_isJumping && player.CheckGround())
        {
            _jumpCooldown += Time.deltaTime;
            _isJumping = true;
            _velocityDelta = player.rigid.velocity.y;
            player.rigid.velocity = new Vector2(player.rigid.velocity.x, playerData.maxJumpingPower);
        }

        if (context.canceled && _isJumping && !_isFalling)
        {
            _isFalling = true;
            player.rigid.velocity = new Vector2(player.rigid.velocity.x, 0f);
        }
    }

    public void OnDash(InputAction.CallbackContext context)
    {
        if (context.started && !_hasDashed && _isFalling && !_isDashing)
        {
            StartCoroutine(Dashing(1f));
            _hasDashed = true;
        }
    }

    IEnumerator Dashing(float direction)
    {
        if (!player.facingRight)
        {
            direction = -direction;
        }
        _isDashing = true;
        player.rigid.gravityScale = 0f;
        player.rigid.velocity = new Vector2(playerData.dashSpeed * direction, 0);
        yield return new WaitForSeconds(0.1f);
        player.rigid.gravityScale = 0.5f;
        player.rigid.AddForce(new Vector2(playerData.dashSpeed * -direction, 0), ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.15f);
        _isDashing = false;
        player.rigid.gravityScale = playerData.gravityScale;
    }
}
