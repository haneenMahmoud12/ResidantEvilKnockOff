using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    //public GameObject grenade;
    [Header("Grenade prefab")]
    [SerializeField] private GameObject grenadePrefab;

    [Header("Grenade Force")]
    [SerializeField] private float throwForce = 10f;
    [SerializeField] private float maxForce = 20f;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {

        }
    }
    void startThrowing()
    {

    }
}