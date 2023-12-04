using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MapEnemy : MonoBehaviour
{
    [SerializeField] Enemy enemy1;
    [SerializeField] Enemy enemy2;
    [SerializeField] int health = 5;
    [SerializeField] int goldCoins;
    [SerializeField] bool isWalking;
    [SerializeField] int action;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    /*void Update()
    {
        
    }*/
}
