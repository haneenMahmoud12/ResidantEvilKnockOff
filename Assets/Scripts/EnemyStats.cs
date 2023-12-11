using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [SerializeField] EnemyData enemyData;
    //[SerializeField] private int damage;
    //[SerializeField] public float attackSpeed;
    //[SerializeField] private bool canAttack;
    // Start is called before the first frame update
    void Start()
    {
        //InitVariables();
    }

    public void CheckHealth()
    {
        if (enemyData.health <= 0)
        {
            enemyData.health = 0;
            Die();
        }
        if (enemyData.health >= enemyData.maxHealth)
        {
            enemyData.health = enemyData.maxHealth;
        }
    }

    public void Die()
    {

        //Destroy(gameObject);
    }

    public void TakeDamage(int damage)
    {
        enemyData.health = enemyData.health - damage;
        Debug.Log(enemyData.health);


    }
}