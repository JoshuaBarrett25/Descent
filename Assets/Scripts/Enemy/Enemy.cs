using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : WeaponTypes
{
    [SerializeField] private float health;
    [SerializeField] private float stamina;

    [SerializeField] private float attackDamage;
    [SerializeField] private float attackRange;
    [SerializeField] private float attackMultiplier;
    [SerializeField] private float attackDelay;
    [SerializeField] private float range;

    [SerializeField] private float[] vulnerabilityScales;

    private float healthCap;

    public void CalculateTotalDamage(DamageTypes type , float damage)
    {
        TakeDamage(damage * vulnerabilityScales[(int)type]);
    }

    public void TakeDamage(float damageValue)
    {

    }

    public void GainHealth(float healthToGain)
    {
        if (health + healthToGain >= healthCap)
        {
            health = healthCap;
        }

        else
        {
            health += healthToGain;
        }
    }
}
