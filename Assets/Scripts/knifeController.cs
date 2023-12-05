using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knifeController : MonoBehaviour
{
    public GameObject enemy;
    public int durability;
    // Start is called before the first frame update
    void Start()
    {
        durability = 10;
        enemy = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        bool check = CheckCloseToTag("enemy", 5);
        if (durability == 1 && Input.GetKeyDown(KeyCode.E) && check)
        {

        }
        if (durability>1 && Input.GetKeyDown(KeyCode.E) && check )
        {

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
