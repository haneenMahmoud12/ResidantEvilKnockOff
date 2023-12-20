using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenades : MonoBehaviour
{
    // Start is called before the first frame update
    public float throwForce = 10f;
    public Transform grenadeArea;
    public GameObject Flashgrenade;
    public GameObject Handgrenade;
    public Animator anim;
    public InventoryScript inventoryScript;
    private void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.G))
        {
            StartCoroutine(GrenadeAnim());

        }
    }

    void ThrowGrenade()
    {
        
            if (inventoryScript.leonEquippedGrenade.Equals("Hand Gernade"))
            {
                Handgrenade.SetActive(true);
                Flashgrenade.SetActive(false);
                GameObject grenade = Instantiate(Handgrenade, grenadeArea.transform.position, grenadeArea.transform.rotation);
                Rigidbody rb = grenade.GetComponent<Rigidbody>();
                rb.AddForce(grenadeArea.transform.forward * throwForce, ForceMode.VelocityChange);
                inventoryScript.ThrowGrenade();
            }
            else if (inventoryScript.leonEquippedGrenade.Equals("Flash Gernade"))
            {
                Handgrenade.SetActive(false);
                Flashgrenade.SetActive(true);
                GameObject grenade = Instantiate(Flashgrenade, grenadeArea.transform.position, grenadeArea.transform.rotation);
                Rigidbody rb = grenade.GetComponent<Rigidbody>();
                rb.AddForce(grenadeArea.transform.forward * throwForce, ForceMode.VelocityChange);
                inventoryScript.ThrowGrenade();
            }


            
        
    }
    IEnumerator GrenadeAnim()
    {
        if (inventoryScript.leonEquippedGrenade != "")
        {
            anim.SetBool("isThrowing", true);
        yield return new WaitForSeconds(3f);
        ThrowGrenade();
        anim.SetBool("isThrowing", false);
        yield return new WaitForSeconds(1f);
        }
        else
        {
            //sound effect that you donot have an equipped grenade
        }

    }
}
