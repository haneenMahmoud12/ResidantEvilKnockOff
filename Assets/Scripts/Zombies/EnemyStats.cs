using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime;
using System;

public class EnemyStats : CharacterStats
{
    [SerializeField] public int damage;
    [SerializeField] public float attackSpeed;
    [SerializeField] public bool canAttack;
    public bool killZombie;
    public GameObject Coins;
    public Transform Transform;
    public int goldAmount=0;
    public Gold gold;
    public bool isHit=false;
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
        Destroy(gameObject,5);
        DropCoins();
        var rnd = new System.Random();
        goldAmount = rnd.Next(5, 50);
        gold.goldAmount = goldAmount;
    }
    private void DropCoins()
    {
        Vector3 position = transform.position;
        GameObject coin = Instantiate(Coins, position, Quaternion.identity);
        coin.SetActive(true);
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
        gold = Coins.GetComponent<Gold>();
    }

    public void DealDamage(CharacterStats stats)
    {
        stats.TakeDamage(damage);
    }
}
