using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats
{
    [SerializeField] public int damage;
    [SerializeField] public float attackSpeed;
    [SerializeField] public bool canAttack;
    public bool killZombie;
    void Start()
    {
        InitVariables();
    }

    public override void CheckHealth()
    {
        if (health <= 0)
        {
            health = 0;
            Die();
        }
        if (health >= maxHealth)
        {
            health = maxHealth;
        }
    }

    public override void Die()
    {
        killZombie = true;
        base.Die();
    }
    public override void InitVariables() 
    {
        maxHealth = 5;
        SetHealthTo(maxHealth);
        isDead = false;
        damage = 1;
        attackSpeed = 3f;
        canAttack = true;
        killZombie = false;
    }

    public void DealDamage(CharacterStats stats)
    {
        stats.TakeDamage(damage);
    }
}
