using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [SerializeField]  EnemyData enemyData;
    public Animator anim;
    public bool isEnemyKnockedDown = false;
    //[SerializeField] private int damage;
    //[SerializeField] public float attackSpeed;
    //[SerializeField] private bool canAttack;
    // Start is called before the first frame update
    private Animator animator;

    public HealthBar healthBar;
    void Start()
    {
        healthBar.SetMaxHealth(enemyData.maxHealth);
        //InitVariables();
        animator = GetComponent<Animator>();
    }

    public  void CheckHealth()
    {
        if (enemyData.health <= 0)
        {
            enemyData.health = 0;
            healthBar.SetHealth(0);
            Die();
        }
        if (enemyData.health >= enemyData.maxHealth)
        {
            enemyData.health = enemyData.maxHealth;
            healthBar.SetMaxHealth(enemyData.maxHealth);
        }
    }
   

    public  void Die()
    {
        enemyData.health = 0;
        healthBar.SetHealth(0);
        animator.SetBool("die", true);
        //Destroy(gameObject);
    }

    public void TakeDamage(int damage)
    {
        if (enemyData.health > 0)
        {
            enemyData.health = enemyData.health - damage;
            Debug.Log(enemyData.health);
            healthBar.SetHealth(enemyData.health);
        }
        if (enemyData.health == 0)
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
}
