using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProjectile : MonoBehaviour
{

    private Rigidbody rb;
    public int damage;
    public float speed = 50;

    Animator anim;
    // Start is called before the first frame update
    /*void Start()
    {

    }*/

    public void OnTriggerEnter(Collider other)
    {

        if (other.GetComponent<EnemyStats>() != null)
        {
            EnemyStats enemy = other.GetComponent<EnemyStats>();
            enemy.TakeDamage(damage);
            enemy.hit();
            // anim = other.GetComponent<Animator>();
            //anim.SetBool("weapon hit", true);
            Debug.Log(other.GetComponent<EnemyStats>().tag);
            Destroy(gameObject);




        }
    }





    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
    }

    // Update is called once per frame
   /* void Update()
    {
        //  Destroy(gameObject,4);
    }*/


}
