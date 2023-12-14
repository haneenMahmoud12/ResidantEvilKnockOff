using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeDamageScript : MonoBehaviour
{
    public Animator anim;
    public float objectHealth = 5f;
    public bool isEnemyKnockedDown = false;
    // Start is called before the first frame update
    void Start()
    {
       // anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    //take damage
    public void objectHitDamage(float amount)
    {
        objectHealth -= amount;

        if (objectHealth <= 0)
        {
            DestroyObject();
        }
    }

    public void objectKnockedDown()
    {

        StartCoroutine(KnockingDownAnim());
    }
    void DestroyObject()
    {
        Destroy(gameObject);
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