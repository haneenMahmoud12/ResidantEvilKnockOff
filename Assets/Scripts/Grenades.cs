using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using StarterAssets;

public class Grenades : MonoBehaviour
{
    // Start is called before the first frame update
    public float throwForce = 10f;
    public Transform grenadeArea;
    public GameObject Flashgrenade;
    public GameObject Handgrenade;

    public GameObject Shotgun;
    public GameObject Rifle;
    public GameObject Revolver;
    public GameObject pistol;
    public GameObject knife;
    public Animator anim;
    public bool throwingGrenade = false;
    public InventoryScript inventoryScript;
    public AudioSource explosion;
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

        throwingGrenade = false;


    }
    IEnumerator GrenadeAnim()
    {
        if (inventoryScript.leonEquippedGrenade != "")
        {
            throwingGrenade = true;
            anim.SetBool("isThrowing", true);
            yield return new WaitForSeconds(1f);
            ThrowGrenade();
            anim.SetBool("isThrowing", false);
            yield return new WaitForSeconds(1f);
            explosion.Play();

        }
        else
        {
            //sound effect that you donot have an equipped grenade
        }

    }
}
