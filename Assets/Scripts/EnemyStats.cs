using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats
{
    [SerializeField] private int damage;
    [SerializeField] public float attackSpeed;
    [SerializeField] public bool canAttack;
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
        base.Die();
        //Destroy(gameObject);
    }
    public override void InitVariables() 
    {
        maxHealth = 5;
        SetHealthTo(maxHealth);
        isDead = false;
        damage = 1;
        attackSpeed = 3f;
        canAttack = true;
    }

    public void DealDamage(CharacterStats stats)
    {
        stats.TakeDamage(damage);
    }
}
