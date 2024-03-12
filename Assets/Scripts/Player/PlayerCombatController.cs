using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCombatController : MonoBehaviour
{ 
    public Player player;
    public AttackDetails attackDetails;

    [SerializeField] private D_Player _playerData;
    [SerializeField] private D_Weapon _weaponData;
    
    [SerializeField] private LayerMask _whatIsEnemy;

    private float _damageWS;

    private bool _isLightAttacking;
    private bool _isHeavyAttacking;

    private float _attackCooldownWS;


    private void Start()
    {
        //TODO: Player animator
        attackDetails = new AttackDetails();
        attackDetails.position = player.attackbox.position;
        attackDetails.range = _weaponData.attackSize;
        attackDetails.damageValue = _weaponData.baseLightAttackDamageValue;
    }

    private void FixedUpdate()
    {
        if (_isLightAttacking)
        {
            _attackCooldownWS += Time.deltaTime;
            if (_attackCooldownWS >= player._weaponData.lightAttackCooldown)
            {
                _attackCooldownWS = 0;
                player._isAttacking = false;
                _isLightAttacking = false;
            }
        }

        if (_isHeavyAttacking)
        {
            _attackCooldownWS += Time.deltaTime;
            if (_attackCooldownWS >= player._weaponData.heavyAttackCooldown)
            {
                _attackCooldownWS = 0;
                player._isAttacking = false;
                _isHeavyAttacking = false;
            }
        }
    }

    public void OnLightAttack(InputAction.CallbackContext context)
    {
        if (context.started && !player._isAttacking && !_isLightAttacking)
        {
            TriggerLightAttack();
        }
    }

    public void OnHeavyAttack(InputAction.CallbackContext context)
    {
        if (context.started && !player._isAttacking && !_isHeavyAttacking)
        {
            TriggerHeavyAttack();
        }
    }
    
    private void TriggerLightAttack()
    {
        Debug.Log("Light attack!");
        player._isAttacking = true;
        _isLightAttacking = true;

        attackDetails.position = player.attackbox.position;
        attackDetails.damageValue = player._weaponData.baseLightAttackDamageValue;

        Collider2D[] detectedColliders = Physics2D.OverlapBoxAll(attackDetails.position, new Vector2 (attackDetails.range, attackDetails.range), 0, _whatIsEnemy);
        foreach (Collider2D collider in detectedColliders)
        {
            if (detectedColliders == null)
            {
                break;
            }
            else
            {
                collider.transform.SendMessage("Damaged", attackDetails);
            }
        }
    }

    private void TriggerHeavyAttack()
    {
        _isHeavyAttacking = true;
        player._isAttacking = true;

        attackDetails.position = player.attackbox.position;
        attackDetails.damageValue = player._weaponData.baseHeavyAttackDamageValue;

        Collider2D[] detectedColliders = Physics2D.OverlapBoxAll(attackDetails.position, new Vector2(attackDetails.range, attackDetails.range), 0, _whatIsEnemy);
        foreach (Collider2D collider in detectedColliders)
        {
            if (detectedColliders == null)
            {
                break;
            }
            else
            {
                
                collider.transform.SendMessage("Damaged", attackDetails);
            }
        }
    }


    private void Damaged(AttackDetails attack)
    {
        player.Damaged(attack);
    }

    private void OnDrawGizmos()
    {
        if (_isHeavyAttacking || _isLightAttacking)
        {
            Gizmos.DrawCube(attackDetails.position, new Vector3(attackDetails.range, attackDetails.range, attackDetails.range));
        }
    }
}
