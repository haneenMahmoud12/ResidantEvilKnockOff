using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    [SerializeField] private int damage;
    /*[SerializeField] private float attackSpeed;
    [SerializeField] private bool canAttack;*/
    public bool isGrappled;
    public bool isInvincible;

    // Start is called before the first frame update
    void Start()
    {
        InitVariables();
    }
    public override void CheckHealth()
    {
        base.CheckHealth();
    }

    public override void Die()
    {
        base.Die();
        //Destroy(gameObject);
    }
    public override void InitVariables()
    {
        maxHealth = 15;
        SetHealthTo(maxHealth);
        isDead = false;
        damage = 1;
        /*attackSpeed = 1.5f;
        canAttack = true;*/
        isGrappled = false;
        isInvincible = false;
    }

    public void DealDamage(CharacterStats stats)
    {
        stats.TakeDamage(damage);
    }

    public void HealCheat()
    {
        health += 4; 
    }
    public void InvincibilityCheat()
    {
        isInvincible = true;
    }
    public void SloMoCheat()
    {
       //health += 4;
    }
    public void GoldCheat()
    {
        health += 4;
    }
    public void DoorCheat()
    {
        health += 4;
    }
}
