using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knife : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "enemy")
            Debug.Log("Entered collision with " + collision.gameObject.name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
