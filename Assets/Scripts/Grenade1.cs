using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade1 : MonoBehaviour
{
    public float grenadeTimer = 3f;
    float countDown;
    public float radius = 5f;
    public int giveDamage = 4;
    public GameObject explosionEffect;
    public int buyPrice = 15;
    public int sellPrice = 10;
    bool hasExploded = false;

    // Start is called before the first frame update
    void Start()
    {
        countDown = grenadeTimer;
    }

    // Update is called once per frame
    void Update()
    {
        countDown -= Time.deltaTime;

        if (countDown <= 0 && !hasExploded)
        {
            Explode();
            hasExploded = true;
        }
    }

    void Explode()
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);

        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider nearbyObject in colliders)
        {
            EnemyStats obj = nearbyObject.GetComponent<EnemyStats>();
            if (obj != null)
            {
                if (gameObject.tag == "handGrenade")
                {
                    //Debug.Log("hi");
                    obj.TakeDamage(giveDamage);
                    
                }
                if (gameObject.tag == "flashGrenade")
                {
                 

                    obj.objectKnockedDown();

                }
            }
        }

        Destroy(gameObject);
    }
}