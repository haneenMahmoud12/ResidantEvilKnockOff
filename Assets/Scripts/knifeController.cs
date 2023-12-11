using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knifeController : MonoBehaviour
{
    public GameObject enemy;
    public int durability;
    public Animator EnemyAnim;
    public Animator LeonAnim;
    GrenadeDamageScript obj;
    // Start is called before the first frame update
    void Start()
    {
        durability = 10;
        enemy = GetComponent<GameObject>();
        EnemyAnim = GetComponent<Animator>();
        LeonAnim = GetComponent<Animator>();
        obj = GetComponent<GrenadeDamageScript>();
    }

    // Update is called once per frame
    void Update()
    {
        bool check = CheckCloseToTag("enemy", 2);
        if (durability == 1 && Input.GetKeyDown(KeyCode.E) && check)
        {
            if (obj.isEnemyKnockedDown)
            {
                //stab knocked down enemy
                durability -= 1;

            }
        }
        //if (durability> 1 && Input.GetKeyDown(KeyCode.E) && check)
        //{
            //Debug.Log("ALOOOOO");
            //Debug.Log("stabbing"+LeonAnim.GetCurrentAnimatorStateInfo(0).IsName("Smash"));

            //if (obj.isEnemyKnockedDown)
            //{

                //durability -= 1;
                //LeonAnim.SetBool("stabKnockedDown", true);
                //play stab animation
            //}
            if (LeonAnim.GetCurrentAnimatorStateInfo(0).IsName("TakenHostage"))
            {
                if (Input.GetKeyDown(KeyCode.E) && check)
                {
                    Debug.Log("helloooo");
                //play stab animation
                    LeonAnim.SetBool("stab", true);
                    LeonAnim.SetBool("isGrappled", false);
                //StartCoroutine(stabEnemy());
                    //LeonAnim.SetBool("stab", true);
                    durability -= 2;

                }
            }

        //}
       


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
    IEnumerator stabEnemy()
    {
        LeonAnim.SetBool("stab", true);
        LeonAnim.SetBool("isGrappled", false);
        yield return new WaitForSeconds(1f);
        LeonAnim.SetBool("stab", false);
        //yield return new WaitForSeconds(1f);

    }
}
