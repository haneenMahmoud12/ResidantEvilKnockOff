using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade1 : MonoBehaviour
{
    public float grenadeTimer = 3f;
    float countDown;
    public float radius = 2.5f;
    public int giveDamage = 4;
    public GameObject explosionEffect;
    public int buyPrice = 15;
    public int sellPrice = 10;
    bool hasExploded = false;
    public GameObject sharpnelsEffect;
    //public AudioSource Explosion;
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
        //Explosion.Play();
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider nearbyObject in colliders)
        {
            EnemyStats obj = nearbyObject.GetComponent<EnemyStats>();
            PlayerStats player = nearbyObject.GetComponent<PlayerStats>();
            if (player != null)
                player.TakeDamage(giveDamage);
            if (obj != null)
            {
                if (gameObject.tag == "handGrenade")
                {
                    Instantiate(sharpnelsEffect, transform.position, transform.rotation);
                    obj.TakeDamage(giveDamage);

                }
                if (gameObject.tag == "flashGrenade")
                {
                    Instantiate(explosionEffect, transform.position, transform.rotation);

                    obj.objectKnockedDown();

                }
            }
        }

        Destroy(gameObject);
    }
}