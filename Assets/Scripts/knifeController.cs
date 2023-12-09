using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knifeController : MonoBehaviour
{
    public GameObject enemy;
    public int durability;
    public Animator EnemyAnim;
    public Animator LeonAnim;
    // Start is called before the first frame update
    void Start()
    {
        durability = 10;
        enemy = GetComponent<GameObject>();
        EnemyAnim = GetComponent<Animator>();
        LeonAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        bool check = CheckCloseToTag("enemy", 5);
        if (durability == 1 && Input.GetKeyDown(KeyCode.E) && check)
        {
            if (EnemyAnim.GetCurrentAnimatorStateInfo(0).IsName("KnockedDown"))
            {

                durability -= 1;

            }
        }
        if (durability>1 && Input.GetKeyDown(KeyCode.E) && check)
        {
            if (EnemyAnim.GetCurrentAnimatorStateInfo(0).IsName("Stunned"))
            {

                durability -= 1;
                LeonAnim.SetBool("stabKnockedDown", true);
                //play stab animation
            }
            if (LeonAnim.GetCurrentAnimatorStateInfo(0).IsName("grappled"))
            {
                //play stab animation
                LeonAnim.SetBool("stabEnemy", true);
                durability -= 2;

            }

        }
       


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
}
