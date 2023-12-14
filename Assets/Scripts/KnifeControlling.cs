using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class knifeControlling : MonoBehaviour
{
    public int durability;
    public Animator anim;
    EnemyStats obj;
    // Start is called before the first frame update
    void Start()
    {
        durability = 10;
        anim = GetComponent<Animator>();
        obj = GetComponent<EnemyStats>();
    }

    // Update is called once per frame
    void Update()
    {
        //GrenadeDamageScript[] enemies = GrenadeDamageScript.t("enemy");
        bool check = CheckCloseToTag("enemy", 2);
        bool knockedDown = isEnemyKnockedDown("enemy", 2);


        if (knockedDown)
        {
            if (durability >= 1 && Input.GetKeyDown(KeyCode.K))
            {//stab knocked down enemy
                durability -= 1;

                StartCoroutine(stabKnockedDownEnemy());
                //deplete all enemy's health



            }


        }


        if (anim.GetCurrentAnimatorStateInfo(0).IsName("TakenHostage"))
        {
            if (durability > 1 && Input.GetKeyDown(KeyCode.K) && check)
            {

                anim.SetBool("stab", true);
                anim.SetBool("isGrappled", false);
                durability -= 2;

            }
        }
    }
    IEnumerator stabKnockedDownEnemy()
    {
        anim.SetBool("stabKnockedDown", true);
        anim.SetLayerWeight(2, 1);
        yield return new WaitForSeconds(2f);
        anim.SetBool("stabKnockedDown", false);
        anim.SetLayerWeight(2, 0);
        //yield return new WaitForSeconds(1f);

    }
    bool CheckCloseToTag(string tag, float minimumDistance)
    {
        GameObject[] goWithTag = GameObject.FindGameObjectsWithTag(tag);

        for (int i = 0; i < goWithTag.Length; ++i)
        {
            if (Vector3.Distance(transform.position, goWithTag[i].transform.position) <= minimumDistance)
                return true;
        }

        return false;
    }
    bool isEnemyKnockedDown(string tag, float minimumDistance)
    {
        GameObject[] goWithTag = GameObject.FindGameObjectsWithTag(tag);

        for (int i = 0; i < goWithTag.Length; ++i)
        {
            if (Vector3.Distance(transform.position, goWithTag[i].transform.position) <= minimumDistance)
            {
                EnemyStats obj = goWithTag[i].GetComponent<EnemyStats>();
                if (obj != null)
                {
                    return obj.isEnemyKnockedDown;
                }

            }
        }

        return false;
    }
}