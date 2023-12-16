using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knifeControlling : MonoBehaviour
{
    public int durability;
    public Animator anim;
    GrenadeDamageScript obj;
    //public GameObject knife;
    public GameObject enemy;
    bool stab = false;
    // Start is called before the first frame update
    void Start()
    {
        durability = 10;
        anim = GetComponent<Animator>();
        obj = GetComponent<GrenadeDamageScript>();
        //enemy = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        IsFacingObject();
        float angle = 0f;
        if (Vector3.Angle(enemy.transform.forward, transform.position - enemy.transform.position) == angle)
        {
             stab = true;
            Debug.Log("hellooo");
        }
        //GrenadeDamageScript[] enemies = GrenadeDamageScript.t("enemy");
        bool check = CheckCloseToTag("enemy", 1f);
        bool knockedDown = isEnemyKnockedDown("enemy", 2);
       
        
        if (knockedDown)
         {
            if (durability >= 1 && Input.GetKeyDown(KeyCode.E) && check)
            {//stab knocked down enemy
                durability -= 1;
              
                StartCoroutine(stabKnockedDownEnemy());
                //deplete all enemy's health
               


            }


         }
        

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("TakenHostage"))
        {
            if (durability>1 && Input.GetKeyDown(KeyCode.E) && check && IsFacingObject())
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
        yield return new WaitForSeconds(2f);
        anim.SetBool("stabKnockedDown", false);
        //yield return new WaitForSeconds(1f);

    }
    private bool IsFacingObject()
    {
        // Check if the gaze is looking at the front side of the object
        Vector3 forward = transform.forward;
        Vector3 toOther = (enemy.transform.position - transform.position).normalized;

        if (Vector3.Dot(forward, toOther) < 0.5f)
        {
            Debug.Log("Not facing the object");
            return false;
        }

        Debug.Log("Facing the object");
        return true;
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="enemy")
             Debug.Log("Entered collision with " + collision.gameObject.name);
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
                    GrenadeDamageScript obj = goWithTag[i].GetComponent<GrenadeDamageScript>();
                    if (obj != null)
                    {
                    return obj.isEnemyKnockedDown;
                    }
                    
            }
        }

        return false;
    }
}
