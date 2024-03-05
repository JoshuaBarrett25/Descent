using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class P_Movement : MonoBehaviour
{
    public Player player;

    [SerializeField] private D_Player playerData;
    protected Vector2 input;

    private bool _isFalling;
    private float _jumpCooldown;
    private bool _isJumping;
    private bool _startingJump;

    private float _velocityDelta;
    private float _variableJumpPowerWS;

    private float _timeLastOnGround;

    private void Start()
    {
        player = gameObject.GetComponent<Player>();
        player.rigid.gravityScale = playerData.gravityScale;
    }

    private void FixedUpdate()
    {
        player.playerActions.Play.Jump.performed += OnJump;
        player.playerActions.Play.DoubleJump.performed += OnDoubleJump;

        if (player.CheckGround())
        {
            if (_isFalling)
            {
                _isFalling = false;
            }

            if (_isJumping)
            {
                _isJumping = false;
                player.rigid.gravityScale = playerData.gravityScale;
            }
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
        player.rigid.velocity = new Vector2(input.x * playerData.speed, player.rigid.velocity.y);

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

    public void OnDoubleJump(InputAction.CallbackContext context)
    {

    }
}
