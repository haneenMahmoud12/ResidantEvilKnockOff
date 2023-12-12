using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

    [SerializeField]
    GameObject zombie;

    private PlayerStats stats = null;

    private void Start()
    {
        stats = GetComponent<PlayerStats>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            EnemyStats enemyStats = zombie.GetComponent<EnemyStats>();
            AttackTarget(enemyStats);
        }
    }

    private void AttackTarget(EnemyStats enemyStats)
    {
        if (!enemyStats.isDead)
        {
            stats.DealDamage(enemyStats);
            enemyStats.isHit = true;
        }
    }
}
