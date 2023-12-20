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
    private Gold gold;
    public bool isHit=false;

    public Animator anim;
    public bool isEnemyKnockedDown = false;
    public HealthBar healthBar;

    void Start()
    {
        InitVariables();
        healthBar.SetMaxHealth(maxHealth);
        anim = GetComponent<Animator>();
    }

    public override void TakeDamage(int damage)
    {
        if (health > 0)
        {
            health = health - damage;
            //Debug.Log(health);
            healthBar.SetHealth(health);
        }
        if (health == 0)
            Die();
    }

    public void objectKnockedDown()
    {
        StartCoroutine(KnockingDownAnim());
    }


    IEnumerator KnockingDownAnim()
    {
        isEnemyKnockedDown = true;
        anim.SetBool("isKnockedDown", true);
        yield return new WaitForSeconds(5f);
        isEnemyKnockedDown = false;
        anim.SetBool("isKnockedDown", false);
    }

    public void hit()
    {
        StartCoroutine(hitAnim());
    }


    IEnumerator hitAnim()
    {
        anim.SetBool("weapon hit", true);
        yield return new WaitForSeconds(2f);

        anim.SetBool("weapon hit", false);
    }
    public override void CheckHealth()
    {
        if (health <= 0)
        {
            health = 0;
            healthBar.SetHealth(0);
            Die();
        }
        if (health >= maxHealth)
        {
            health = maxHealth;
            healthBar.SetMaxHealth(maxHealth);
        }
    }

    public override void Die()
    {
        killZombie = true;
        base.Die();
        Destroy(gameObject,5);
        var rnd = new System.Random();
        goldAmount = rnd.Next(5, 50);
        DropCoins(goldAmount);
        //inventoryScript.collectGold(goldAmount);
        health = 0;
        healthBar.SetHealth(0);
    }
    private void DropCoins(int amount)
    {
        Vector3 position = transform.position;
        Instantiate(Coins, position, Quaternion.identity);
        gold = Coins.GetComponent<Gold>();
        gold.goldAmount = amount;
        Debug.Log("EnenmyStats "+gold.goldAmount);
        //coin.SetActive(true);
    }
    public override void InitVariables() 
    {
        maxHealth = 4;
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
