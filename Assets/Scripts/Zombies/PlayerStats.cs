using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : CharacterStats
{
    [SerializeField] private int damage;
    /*[SerializeField] private float attackSpeed;
    [SerializeField] private bool canAttack;*/
    public bool isGrappled;
    public bool isInvincible;
    public AudioSource leonDying;

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
        leonDying.Play();
        StartCoroutine(DelayDeath());
    }
    public override void InitVariables()
    {
        maxHealth = 8;
        SetHealthTo(maxHealth);
        isDead = false;
        damage = 1;
        /*attackSpeed = 1.5f;
        canAttack = true;*/
        isGrappled = false;
        isInvincible = false;
    }

    public void DealDamage(CharacterStats stats, int damagePoints)
    {
        stats.TakeDamage(damagePoints);
    }
    
    private IEnumerator DelayDeath()
    {
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene("GameOver");
    }


}
