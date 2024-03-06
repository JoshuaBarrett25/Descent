using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Combat : MonoBehaviour
{
    public Player player;

    [SerializeField] private D_Player playerData;

    private float damageWS = 0;

    private void FixedUpdate()
    {
        
    }

    public void CalculateDamage(float baseDamage)
    {
        damageWS = baseDamage;
        player.TakeDamage(damageWS);
        damageWS = 0;
    }
}
