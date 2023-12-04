using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy")]
public class Enemy : ScriptableObject
{
    public int health = 5;
    public int goldCoins;
    public bool isWalking;
    public int action; // 0=>Swing, 1=>Throw, 2=>Punch, 3=>Grapple
}
