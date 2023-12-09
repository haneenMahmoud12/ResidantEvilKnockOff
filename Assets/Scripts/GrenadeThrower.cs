using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float throwForce = 10f;
    public Transform grenadeArea;
    public GameObject grenadePrefab;
    public Animator anim;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            StartCoroutine(GrenadeAnim());
            
        }
    }

    void ThrowGrenade()
    {
        GameObject grenade = Instantiate(grenadePrefab, grenadeArea.transform.position, grenadeArea.transform.rotation);
        Rigidbody rb = grenade.GetComponent<Rigidbody>();
        rb.AddForce(grenadeArea.transform.forward * throwForce, ForceMode.VelocityChange);

    }
    IEnumerator GrenadeAnim()
    {
        anim.SetBool("isThrowing", true);
        yield return new WaitForSeconds(0.8f);
        ThrowGrenade();
        anim.SetBool("isThrowing", false);
        yield return new WaitForSeconds(1f);
        
    }
}
