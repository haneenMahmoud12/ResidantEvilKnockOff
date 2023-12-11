using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Enemy/EnemyData")]
public class EnemyData : ScriptableObject
{


    public int damage;
    public int health;
    public float attackSpeed;
    public bool canAttack;
    public int maxHealth;
}