using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    [SerializeField] public int health;
    [SerializeField] public int maxHealth;
    [SerializeField] public bool isDead;
    public InventoryScript inventoryScript;
    // Start is called before the first frame update
    void Start()
    {
        InitVariables();
    }

    public virtual void CheckHealth()
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

    public virtual void Die()
    {
        isDead = true;
    }

    public void SetHealthTo(int healthToSetTo)
    {
        health = healthToSetTo;
        CheckHealth();
    }

    public virtual void TakeDamage(int damage)
    {
        bool isDead = inventoryScript.DecreasePlayerHealth(damage);
        if (isDead)
        {
            Die();
        }
        //int healthAfterDamage = health - damage;
        //SetHealthTo(healthAfterDamage);
    }
    public void Heal(int heal)
    {
        int healthAfterHeal = health + heal;
        SetHealthTo(healthAfterHeal);
    }
    public virtual  void InitVariables()
    {
        maxHealth = inventoryScript.leonHealthPoints;
        SetHealthTo(maxHealth);
        isDead = false;
    }

}
