using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatController : MonoBehaviour
{ 
    public Player player;

    public AttackDetails attackDetails;

    [SerializeField] private D_Player _playerData;
    [SerializeField] private D_Weapon _weaponData;

    [SerializeField] private bool _combatEnabled;
    
    [SerializeField] private LayerMask _whatIsEnemy;

    private float _damageWS;

    private void Start()
    {
        //TODO: Player animator
        attackDetails.position = player.attackbox.position;
        attackDetails.range = _weaponData.attackSize;
        attackDetails.damageValue = _weaponData.damageValue;
    }

    
    private void TriggerAttack()
    {
        Collider2D[] detectedColliders = Physics2D.OverlapBoxAll(attackDetails.position, new Vector2 (attackDetails.range, attackDetails.range), 0, _whatIsEnemy);

        foreach (Collider2D collider in detectedColliders)
        {
            collider.transform.SendMessage("Damaged", attackDetails);
        }
    }

    private void Damaged(AttackDetails attack)
    {

    }
}
