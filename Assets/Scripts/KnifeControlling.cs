using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class knifeControlling : MonoBehaviour
{
   // public int durability;
    public Animator anim;
    EnemyStats obj;
    public InventoryScript inventoryScript;
    public GameObject knife;
   
    // Start is called before the first frame update
    void Start()
    {
        
        anim = GetComponent<Animator>();
        obj = GetComponent<EnemyStats>();
    }

    // Update is called once per frame
    void Update()
    {
        //GrenadeDamageScript[] enemies = GrenadeDamageScript.t("enemy");
       // bool check = CheckCloseToTag("enemy", 2);
        //bool knockedDown = isEnemyKnockedDown("enemy", 2);


        
            
            
            if (inventoryScript.leonKniefDurability >= 1 && Input.GetKeyDown(KeyCode.E))

            {
            bool knockedDown = isEnemyKnockedDown(2);
            if (knockedDown)
            {

                knife.SetActive(true);
                //stab knocked down enemy
                inventoryScript.DecreaseKniefDurability(1);
                //durability -= 1;
                Debug.Log("knockeddown");

                StartCoroutine(stabKnockedDownEnemy());
                //deplete all enemy's health
               


            }
            


        }


        //if (anim.GetCurrentAnimatorStateInfo(0).IsName("TakenHostage"))
        if(anim.GetBool("isGrappled"))
        {
            knife.SetActive(true);
            bool check = CheckCloseToTag( 2);
            if (inventoryScript.leonKniefDurability > 1 && Input.GetKeyDown(KeyCode.E) && check)
            {

                anim.SetBool("stab", true);
                anim.SetBool("isGrappled", false);
                inventoryScript.DecreaseKniefDurability( 2);

            }
        }
    }
    IEnumerator stabKnockedDownEnemy()
    {
        Debug.Log("animation");
        anim.SetBool("stabKnockedDown", true);
        anim.SetLayerWeight(2, 1);
        yield return new WaitForSeconds(2f);
        anim.SetBool("stabKnockedDown", false);
        anim.SetLayerWeight(2, 0);
        //yield return new WaitForSeconds(1f);


    }
    bool CheckCloseToTag( float minimumDistance)
    {
        EnemyStats[] goWithType = FindObjectsOfType<EnemyStats>();
           
        for (int i = 0; i < goWithType.Length; ++i)
        {
            if (Vector3.Distance(transform.position, goWithType[i].transform.position) <= minimumDistance)
                return true;
        }

        return false;
    }
    bool isEnemyKnockedDown(float minimumDistance)
    {
        EnemyStats[] goWithType = FindObjectsOfType<EnemyStats>();

        for (int i = 0; i < goWithType.Length; ++i)
        {
            if (Vector3.Distance(transform.position, goWithType[i].transform.position) <= minimumDistance)
            {
                EnemyStats obj = goWithType[i].GetComponent<EnemyStats>();
                if (obj != null)
                {
                    obj.Die();
                  
                    return obj.isEnemyKnockedDown;
                }

            }
        }

        return false;
    }
}