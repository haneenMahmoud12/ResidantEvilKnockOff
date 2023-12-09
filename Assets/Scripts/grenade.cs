using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grenade : MonoBehaviour
{
    [Header("Explosion prefab")]
    [SerializeField] private GameObject explosionEffectPrefab;
    [SerializeField] private Vector3 explosionParticleOffset = new Vector3(0, 1, 0);

    [Header("Explosion Settings")]
    [SerializeField] private float explosionDelay = 3f;
    [SerializeField] private float explosionForce = 700f;
    [SerializeField] private float explosionRadius = 5f;

    [Header("Audio effects")]

    private float countdown;
    private bool hasExploded = false;


    // Start is called before the first frame update
    void Start()
    {
        countdown = explosionDelay;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasExploded)
        {
            countdown -= Time.deltaTime;
            if(countdown <= 0f)
            {
                Explode();
                hasExploded = true;
            }
        }

        void Explode()
        {
            GameObject explosionEffect = Instantiate(explosionEffectPrefab, transform.position + explosionParticleOffset, Quaternion.identity);

            NearbyForceApply();
            Destroy(explosionEffect, 4f);
            Destroy(gameObject);



        }

        void NearbyForceApply()
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);

            foreach(Collider nearbyObject in colliders)
            {
                Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
                if(rb != null)
                {
                    rb.AddExplosionForce(explosionForce,transform.position,explosionRadius);
                }
            }
        }
    }
}
